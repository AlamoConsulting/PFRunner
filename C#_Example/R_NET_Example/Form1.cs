﻿using System;
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

            var group = engine.Evaluate("source('C:/Desarrollo/AlamoConsulting/PFRunner/R_Example/test.r')");
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void messagesBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                keyAES.Text = System.Text.ASCIIEncoding.UTF32.GetString(myRijndael.Key);
                ivAES.Text = System.Text.ASCIIEncoding.ASCII.GetString(myRijndael.IV);
                var key = System.Text.ASCIIEncoding.ASCII.GetBytes(keyAES.Text);
                var iv = System.Text.ASCIIEncoding.ASCII.GetBytes(ivAES.Text);
                // Encrypt the string to an array of bytes.
                byte[] encrypted = Encrypting.AES.EncryptStringToBytes(textBoxStart.Text, myRijndael.Key, myRijndael.IV);
                textBoxEnd.Text = System.Text.Encoding.ASCII.GetString(encrypted);
            }
        }

        private void DecryptAES_Click(object sender, EventArgs e)
        {
            var texto = System.Text.Encoding.ASCII.GetBytes(textBoxStart.Text);
            var key = System.Text.Encoding.ASCII.GetBytes(keyAES.Text);
            var iv = System.Text.Encoding.ASCII.GetBytes(ivAES.Text);
            string roundtrip = Encrypting.AES.DecryptStringFromBytes(texto, key, iv);
            textBoxEnd.Text = roundtrip;
        }
    }
}
