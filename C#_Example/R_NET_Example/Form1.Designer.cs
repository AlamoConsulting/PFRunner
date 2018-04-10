namespace MyApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.messagesBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.crearClavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EncryptAES = new System.Windows.Forms.Button();
            this.DecryptAES = new System.Windows.Forms.Button();
            this.keyAES = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ivAES = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 64);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // messagesBox
            // 
            this.messagesBox.Location = new System.Drawing.Point(0, 132);
            this.messagesBox.Multiline = true;
            this.messagesBox.Name = "messagesBox";
            this.messagesBox.Size = new System.Drawing.Size(338, 233);
            this.messagesBox.TabIndex = 1;
            this.messagesBox.TextChanged += new System.EventHandler(this.messagesBox_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearClavesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // crearClavesToolStripMenuItem
            // 
            this.crearClavesToolStripMenuItem.Name = "crearClavesToolStripMenuItem";
            this.crearClavesToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.crearClavesToolStripMenuItem.Text = "Crear claves";
            this.crearClavesToolStripMenuItem.Click += new System.EventHandler(this.crearClavesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(403, 275);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(88, 23);
            this.Encrypt.TabIndex = 3;
            this.Encrypt.Text = "Encrypt RSA";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(497, 275);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(85, 23);
            this.Decrypt.TabIndex = 4;
            this.Decrypt.Text = "Decrypt RSA";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(403, 82);
            this.textBoxStart.Multiline = true;
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(191, 187);
            this.textBoxStart.TabIndex = 5;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(627, 82);
            this.textBoxEnd.Multiline = true;
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(204, 187);
            this.textBoxEnd.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Text To Encrypt / Decrypt";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EncryptAES
            // 
            this.EncryptAES.Location = new System.Drawing.Point(403, 317);
            this.EncryptAES.Name = "EncryptAES";
            this.EncryptAES.Size = new System.Drawing.Size(88, 23);
            this.EncryptAES.TabIndex = 8;
            this.EncryptAES.Text = "Encrypt AES";
            this.EncryptAES.UseVisualStyleBackColor = true;
            this.EncryptAES.Click += new System.EventHandler(this.EncryptAES_Click);
            // 
            // DecryptAES
            // 
            this.DecryptAES.Location = new System.Drawing.Point(497, 317);
            this.DecryptAES.Name = "DecryptAES";
            this.DecryptAES.Size = new System.Drawing.Size(88, 23);
            this.DecryptAES.TabIndex = 9;
            this.DecryptAES.Text = "Decrypt AES";
            this.DecryptAES.UseVisualStyleBackColor = true;
            this.DecryptAES.Click += new System.EventHandler(this.DecryptAES_Click);
            // 
            // keyAES
            // 
            this.keyAES.Location = new System.Drawing.Point(627, 320);
            this.keyAES.Name = "keyAES";
            this.keyAES.Size = new System.Drawing.Size(91, 20);
            this.keyAES.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Key AES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(723, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "IV AES";
            // 
            // ivAES
            // 
            this.ivAES.Location = new System.Drawing.Point(724, 320);
            this.ivAES.Name = "ivAES";
            this.ivAES.Size = new System.Drawing.Size(100, 20);
            this.ivAES.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 369);
            this.Controls.Add(this.ivAES);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keyAES);
            this.Controls.Add(this.DecryptAES);
            this.Controls.Add(this.EncryptAES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEnd);
            this.Controls.Add(this.textBoxStart);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.messagesBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox messagesBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem crearClavesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EncryptAES;
        private System.Windows.Forms.Button DecryptAES;
        private System.Windows.Forms.TextBox keyAES;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ivAES;
    }
}

