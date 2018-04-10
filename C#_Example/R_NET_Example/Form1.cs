using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using RDotNet;

namespace MyApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();
            string textoCifrado = Encrypting.Hashmd5.Encript("3+5");
            string texto = Encrypting.Hashmd5.Decrypt(textoCifrado);

            var group1 = engine.Evaluate(texto);

            var group = engine.Evaluate("source('C:/Desarrollo/AlamoConsulting/PFRunner/R_Example_Test/test.r')");
            var a = engine.GetSymbol("a").AsNumeric();
            var b = engine.GetSymbol("b").AsNumeric();
            messagesBox.Text = string.Format("Secuencia de Entrada: [{0}]", string.Join(", ", a));
            messagesBox.Text += Environment.NewLine + string.Format("Raíz cuadrada: [{0}]", string.Join(", ", b));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            REngine engine = REngine.GetInstance();
            engine.Dispose();
        }

        private void crearClavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            Encrypting.RSAProvider rsa = new Encrypting.RSAProvider();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderName = browserDialog.SelectedPath;

                FileStream fileStream = new FileStream(Path.Combine(folderName, "PublicKey.xml"), FileMode.Create, FileAccess.Write);
                byte[] publicBytes = rsa.CreatePublicKey();
                fileStream.Write(publicBytes, 0, publicBytes.Length);
                fileStream.Close();

                fileStream = new FileStream(Path.Combine(folderName, "PrivateKey.xml"), FileMode.Create, FileAccess.Write);
                byte[] privateBytes = rsa.CreatePrivateKey();
                fileStream.Write(privateBytes, 0, privateBytes.Length);
                fileStream.Close();
            }
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's necessary a XML publickey to encrypt the data, please select one");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Public Key (*.xml) |.xml)";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream tempStream;
                if((tempStream = openFileDialog.OpenFile()) != null)
                {
                    string xmlFile = new StreamReader(tempStream).ReadToEnd();
                    byte[] encryptedData = Encrypting.RSAProvider.EncryptText(textBoxStart.Text, xmlFile);
                    textBoxEnd.Text = Convert.ToBase64String(encryptedData);
                }
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's necessary a XML private key to decrypt the data, please select one");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Private Key (*.xml) |.xml)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream tempStream;
                if ((tempStream = openFileDialog.OpenFile()) != null)
                {
                    string xmlFile = new StreamReader(tempStream).ReadToEnd();
                    byte[] encryptedData = Encrypting.RSAProvider.DecryptText(textBoxStart.Text, xmlFile);
                    textBoxEnd.Text = System.Text.Encoding.UTF8.GetString(encryptedData);
                }
            }

        }

        private void EncryptAES_Click(object sender, EventArgs e)
        {

            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                myRijndael.GenerateKey();
                myRijndael.GenerateIV();
                keyAES.Text = System.Text.Encoding.Default.GetString(myRijndael.Key);
                ivAES.Text = System.Text.Encoding.Default.GetString(myRijndael.IV);

                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes(textBoxStart.Text, myRijndael.Key, myRijndael.IV);
                textBoxEnd.Text = System.Text.Encoding.Default.GetString(encrypted);
            }
        }

        private void DecryptAES_Click(object sender, EventArgs e)
        {
            var texto = System.Text.Encoding.Default.GetBytes(textBoxStart.Text);
            var key = System.Text.Encoding.Default.GetBytes(keyAES.Text);
            var iv = System.Text.Encoding.Default.GetBytes(ivAES.Text);
            string roundtrip = DecryptStringFromBytes2(texto, key, iv);
            textBoxEnd.Text = roundtrip;

            try
            {

                string original = "Here is some data to encrypt!";

                // Create a new instance of the RijndaelManaged
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (RijndaelManaged myRijndael = new RijndaelManaged())
                {

                    myRijndael.GenerateKey();
                    myRijndael.GenerateIV();
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

                    // Decrypt the bytes to a string.
                    string roundtrip2 = DecryptStringFromBytes2(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip2);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }


        static string DecryptStringFromBytes2(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }
    }
}
