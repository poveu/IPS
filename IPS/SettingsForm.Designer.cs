namespace IPS
{
    partial class SettingsForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        
        private System.Windows.Forms.ComboBox comboBoxDb;
        private System.Windows.Forms.TextBox textBoxDbUsr;
        private System.Windows.Forms.Label labelDbUsr;
        private System.Windows.Forms.Label labelDbSrv;
        private System.Windows.Forms.Label labelDb;
        private System.Windows.Forms.GroupBox groupBoxDb;
        private System.Windows.Forms.Label labelDbPass;
        private System.Windows.Forms.TextBox textBoxDbPass;
        private System.Windows.Forms.ComboBox comboBoxDbSrv;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.CheckBox checkBoxSetAsSent;
        private System.Windows.Forms.Label labelSetAsSent;
        private System.Windows.Forms.GroupBox groupBoxENadawca;
        private System.Windows.Forms.Label labelENadawcaPass;
        private System.Windows.Forms.TextBox textBoxENadawcaPass1;
        private System.Windows.Forms.Label labelENadawcaEmail;
        private System.Windows.Forms.TextBox textBoxENadawcaEmail1;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.Label labelModeXML;
        private System.Windows.Forms.RadioButton radioButtonModeXML;
        private System.Windows.Forms.Label labelModeIntegrated;
        private System.Windows.Forms.RadioButton radioButtonModeIntegrated;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBoxDb = new System.Windows.Forms.GroupBox();
            this.comboBoxDbSrv = new System.Windows.Forms.ComboBox();
            this.labelDbPass = new System.Windows.Forms.Label();
            this.textBoxDbPass = new System.Windows.Forms.TextBox();
            this.labelDb = new System.Windows.Forms.Label();
            this.comboBoxDb = new System.Windows.Forms.ComboBox();
            this.labelDbSrv = new System.Windows.Forms.Label();
            this.labelDbUsr = new System.Windows.Forms.Label();
            this.textBoxDbUsr = new System.Windows.Forms.TextBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.checkBoxSetAsSent = new System.Windows.Forms.CheckBox();
            this.labelSetAsSent = new System.Windows.Forms.Label();
            this.groupBoxENadawca = new System.Windows.Forms.GroupBox();
            this.labelENadawcaAcc2 = new System.Windows.Forms.Label();
            this.textBoxENadawcaPass2 = new System.Windows.Forms.TextBox();
            this.textBoxENadawcaEmail2 = new System.Windows.Forms.TextBox();
            this.labelENadawcaAcc1 = new System.Windows.Forms.Label();
            this.labelENadawcaPass = new System.Windows.Forms.Label();
            this.textBoxENadawcaPass1 = new System.Windows.Forms.TextBox();
            this.labelENadawcaEmail = new System.Windows.Forms.Label();
            this.textBoxENadawcaEmail1 = new System.Windows.Forms.TextBox();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.labelModeXML = new System.Windows.Forms.Label();
            this.radioButtonModeXML = new System.Windows.Forms.RadioButton();
            this.labelModeIntegrated = new System.Windows.Forms.Label();
            this.radioButtonModeIntegrated = new System.Windows.Forms.RadioButton();
            this.groupBoxDb.SuspendLayout();
            this.groupBoxENadawca.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDb
            // 
            this.groupBoxDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDb.Controls.Add(this.comboBoxDbSrv);
            this.groupBoxDb.Controls.Add(this.labelDbPass);
            this.groupBoxDb.Controls.Add(this.textBoxDbPass);
            this.groupBoxDb.Controls.Add(this.labelDb);
            this.groupBoxDb.Controls.Add(this.comboBoxDb);
            this.groupBoxDb.Controls.Add(this.labelDbSrv);
            this.groupBoxDb.Controls.Add(this.labelDbUsr);
            this.groupBoxDb.Controls.Add(this.textBoxDbUsr);
            this.groupBoxDb.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDb.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxDb.Name = "groupBoxDb";
            this.groupBoxDb.Size = new System.Drawing.Size(534, 129);
            this.groupBoxDb.TabIndex = 8;
            this.groupBoxDb.TabStop = false;
            this.groupBoxDb.Text = "Dane bazy danych Sello";
            // 
            // comboBoxDbSrv
            // 
            this.comboBoxDbSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDbSrv.FormattingEnabled = true;
            this.comboBoxDbSrv.Location = new System.Drawing.Point(123, 70);
            this.comboBoxDbSrv.Name = "comboBoxDbSrv";
            this.comboBoxDbSrv.Size = new System.Drawing.Size(405, 21);
            this.comboBoxDbSrv.TabIndex = 3;
            this.comboBoxDbSrv.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDbSrv_SelectedIndexChanged);
            this.comboBoxDbSrv.Leave += new System.EventHandler(this.ComboBoxDbSrv_Leave);
            // 
            // labelDbPass
            // 
            this.labelDbPass.Location = new System.Drawing.Point(6, 48);
            this.labelDbPass.Name = "labelDbPass";
            this.labelDbPass.Size = new System.Drawing.Size(111, 23);
            this.labelDbPass.TabIndex = 17;
            this.labelDbPass.Text = "Hasło serwera:";
            // 
            // textBoxDbPass
            // 
            this.textBoxDbPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDbPass.Location = new System.Drawing.Point(123, 45);
            this.textBoxDbPass.Name = "textBoxDbPass";
            this.textBoxDbPass.PasswordChar = '*';
            this.textBoxDbPass.Size = new System.Drawing.Size(405, 20);
            this.textBoxDbPass.TabIndex = 2;
            this.textBoxDbPass.TextChanged += new System.EventHandler(this.TextBoxDbPass_TextChanged);
            // 
            // labelDb
            // 
            this.labelDb.Location = new System.Drawing.Point(6, 100);
            this.labelDb.Name = "labelDb";
            this.labelDb.Size = new System.Drawing.Size(111, 23);
            this.labelDb.TabIndex = 15;
            this.labelDb.Text = "Baza danych Sello:";
            // 
            // comboBoxDb
            // 
            this.comboBoxDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDb.Enabled = false;
            this.comboBoxDb.FormattingEnabled = true;
            this.comboBoxDb.Location = new System.Drawing.Point(123, 97);
            this.comboBoxDb.Name = "comboBoxDb";
            this.comboBoxDb.Size = new System.Drawing.Size(405, 21);
            this.comboBoxDb.TabIndex = 4;
            this.comboBoxDb.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDb_SelectedIndexChanged);
            // 
            // labelDbSrv
            // 
            this.labelDbSrv.Location = new System.Drawing.Point(6, 74);
            this.labelDbSrv.Name = "labelDbSrv";
            this.labelDbSrv.Size = new System.Drawing.Size(111, 23);
            this.labelDbSrv.TabIndex = 13;
            this.labelDbSrv.Text = "Serwer:";
            // 
            // labelDbUsr
            // 
            this.labelDbUsr.Location = new System.Drawing.Point(6, 22);
            this.labelDbUsr.Name = "labelDbUsr";
            this.labelDbUsr.Size = new System.Drawing.Size(111, 23);
            this.labelDbUsr.TabIndex = 10;
            this.labelDbUsr.Text = "Użytkownik serwera:";
            // 
            // textBoxDbUsr
            // 
            this.textBoxDbUsr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDbUsr.Location = new System.Drawing.Point(123, 19);
            this.textBoxDbUsr.Name = "textBoxDbUsr";
            this.textBoxDbUsr.Size = new System.Drawing.Size(405, 20);
            this.textBoxDbUsr.TabIndex = 1;
            this.textBoxDbUsr.Text = "sa";
            this.textBoxDbUsr.TextChanged += new System.EventHandler(this.TextBoxDbUsr_TextChanged);
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveSettings.Location = new System.Drawing.Point(12, 476);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(534, 39);
            this.buttonSaveSettings.TabIndex = 9;
            this.buttonSaveSettings.Text = "Zapisz ustawienia";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.ButtonSaveSettings_Click);
            // 
            // checkBoxSetAsSent
            // 
            this.checkBoxSetAsSent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSetAsSent.Location = new System.Drawing.Point(21, 410);
            this.checkBoxSetAsSent.Name = "checkBoxSetAsSent";
            this.checkBoxSetAsSent.Size = new System.Drawing.Size(520, 24);
            this.checkBoxSetAsSent.TabIndex = 11;
            this.checkBoxSetAsSent.Text = "Przesłane paczki oznaczaj automatycznie w Sello jako \"Wysłane\"";
            this.checkBoxSetAsSent.UseVisualStyleBackColor = true;
            this.checkBoxSetAsSent.CheckedChanged += new System.EventHandler(this.CheckBoxSetAsSent_CheckedChanged);
            // 
            // labelSetAsSent
            // 
            this.labelSetAsSent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSetAsSent.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelSetAsSent.Location = new System.Drawing.Point(18, 437);
            this.labelSetAsSent.Margin = new System.Windows.Forms.Padding(0);
            this.labelSetAsSent.Name = "labelSetAsSent";
            this.labelSetAsSent.Size = new System.Drawing.Size(522, 36);
            this.labelSetAsSent.TabIndex = 12;
            this.labelSetAsSent.Text = resources.GetString("labelSetAsSent.Text");
            // 
            // groupBoxENadawca
            // 
            this.groupBoxENadawca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxENadawca.Controls.Add(this.labelENadawcaAcc2);
            this.groupBoxENadawca.Controls.Add(this.textBoxENadawcaPass2);
            this.groupBoxENadawca.Controls.Add(this.textBoxENadawcaEmail2);
            this.groupBoxENadawca.Controls.Add(this.labelENadawcaAcc1);
            this.groupBoxENadawca.Controls.Add(this.labelENadawcaPass);
            this.groupBoxENadawca.Controls.Add(this.textBoxENadawcaPass1);
            this.groupBoxENadawca.Controls.Add(this.labelENadawcaEmail);
            this.groupBoxENadawca.Controls.Add(this.textBoxENadawcaEmail1);
            this.groupBoxENadawca.Location = new System.Drawing.Point(12, 153);
            this.groupBoxENadawca.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxENadawca.Name = "groupBoxENadawca";
            this.groupBoxENadawca.Size = new System.Drawing.Size(534, 92);
            this.groupBoxENadawca.TabIndex = 14;
            this.groupBoxENadawca.TabStop = false;
            this.groupBoxENadawca.Text = "Dane E-Nadawcy";
            // 
            // labelENadawcaAcc2
            // 
            this.labelENadawcaAcc2.Location = new System.Drawing.Point(327, 9);
            this.labelENadawcaAcc2.Name = "labelENadawcaAcc2";
            this.labelENadawcaAcc2.Size = new System.Drawing.Size(195, 23);
            this.labelENadawcaAcc2.TabIndex = 25;
            this.labelENadawcaAcc2.Text = "Drugie konto";
            this.labelENadawcaAcc2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxENadawcaPass2
            // 
            this.textBoxENadawcaPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxENadawcaPass2.Location = new System.Drawing.Point(327, 61);
            this.textBoxENadawcaPass2.Name = "textBoxENadawcaPass2";
            this.textBoxENadawcaPass2.PasswordChar = '*';
            this.textBoxENadawcaPass2.Size = new System.Drawing.Size(201, 20);
            this.textBoxENadawcaPass2.TabIndex = 24;
            // 
            // textBoxENadawcaEmail2
            // 
            this.textBoxENadawcaEmail2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxENadawcaEmail2.Location = new System.Drawing.Point(327, 35);
            this.textBoxENadawcaEmail2.Name = "textBoxENadawcaEmail2";
            this.textBoxENadawcaEmail2.Size = new System.Drawing.Size(201, 20);
            this.textBoxENadawcaEmail2.TabIndex = 23;
            // 
            // labelENadawcaAcc1
            // 
            this.labelENadawcaAcc1.Location = new System.Drawing.Point(123, 9);
            this.labelENadawcaAcc1.Name = "labelENadawcaAcc1";
            this.labelENadawcaAcc1.Size = new System.Drawing.Size(195, 23);
            this.labelENadawcaAcc1.TabIndex = 22;
            this.labelENadawcaAcc1.Text = "Pierwsze konto";
            this.labelENadawcaAcc1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelENadawcaPass
            // 
            this.labelENadawcaPass.Location = new System.Drawing.Point(6, 64);
            this.labelENadawcaPass.Name = "labelENadawcaPass";
            this.labelENadawcaPass.Size = new System.Drawing.Size(111, 23);
            this.labelENadawcaPass.TabIndex = 21;
            this.labelENadawcaPass.Text = "Hasło:";
            // 
            // textBoxENadawcaPass1
            // 
            this.textBoxENadawcaPass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxENadawcaPass1.Location = new System.Drawing.Point(123, 61);
            this.textBoxENadawcaPass1.Name = "textBoxENadawcaPass1";
            this.textBoxENadawcaPass1.PasswordChar = '*';
            this.textBoxENadawcaPass1.Size = new System.Drawing.Size(201, 20);
            this.textBoxENadawcaPass1.TabIndex = 19;
            // 
            // labelENadawcaEmail
            // 
            this.labelENadawcaEmail.Location = new System.Drawing.Point(6, 38);
            this.labelENadawcaEmail.Name = "labelENadawcaEmail";
            this.labelENadawcaEmail.Size = new System.Drawing.Size(111, 23);
            this.labelENadawcaEmail.TabIndex = 20;
            this.labelENadawcaEmail.Text = "E-mail:";
            // 
            // textBoxENadawcaEmail1
            // 
            this.textBoxENadawcaEmail1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxENadawcaEmail1.Location = new System.Drawing.Point(123, 35);
            this.textBoxENadawcaEmail1.Name = "textBoxENadawcaEmail1";
            this.textBoxENadawcaEmail1.Size = new System.Drawing.Size(201, 20);
            this.textBoxENadawcaEmail1.TabIndex = 18;
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMode.Controls.Add(this.labelModeXML);
            this.groupBoxMode.Controls.Add(this.radioButtonModeXML);
            this.groupBoxMode.Controls.Add(this.labelModeIntegrated);
            this.groupBoxMode.Controls.Add(this.radioButtonModeIntegrated);
            this.groupBoxMode.Location = new System.Drawing.Point(12, 257);
            this.groupBoxMode.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(534, 144);
            this.groupBoxMode.TabIndex = 15;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Tryb pracy";
            // 
            // labelModeXML
            // 
            this.labelModeXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelModeXML.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelModeXML.Location = new System.Drawing.Point(6, 107);
            this.labelModeXML.Name = "labelModeXML";
            this.labelModeXML.Size = new System.Drawing.Size(522, 32);
            this.labelModeXML.TabIndex = 3;
            this.labelModeXML.Text = "Zaznacz powyższą opcję, jeśli najpierw generujesz z poziomu Sello plik XML, który" +
    " następnie importujesz w E-Nadawcy (dzięki czemu możliwe jest powiązanie przesył" +
    "ek po ich unikatowym indeksie GUID)";
            // 
            // radioButtonModeXML
            // 
            this.radioButtonModeXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonModeXML.Location = new System.Drawing.Point(9, 80);
            this.radioButtonModeXML.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.radioButtonModeXML.Name = "radioButtonModeXML";
            this.radioButtonModeXML.Size = new System.Drawing.Size(519, 24);
            this.radioButtonModeXML.TabIndex = 2;
            this.radioButtonModeXML.Text = "Korzystam w E-Nadawcy z importu wygenerowanego w Sello pliku XML";
            this.radioButtonModeXML.UseVisualStyleBackColor = true;
            // 
            // labelModeIntegrated
            // 
            this.labelModeIntegrated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelModeIntegrated.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelModeIntegrated.Location = new System.Drawing.Point(6, 46);
            this.labelModeIntegrated.Name = "labelModeIntegrated";
            this.labelModeIntegrated.Size = new System.Drawing.Size(522, 43);
            this.labelModeIntegrated.TabIndex = 1;
            this.labelModeIntegrated.Text = resources.GetString("labelModeIntegrated.Text");
            // 
            // radioButtonModeIntegrated
            // 
            this.radioButtonModeIntegrated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonModeIntegrated.Location = new System.Drawing.Point(9, 19);
            this.radioButtonModeIntegrated.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.radioButtonModeIntegrated.Name = "radioButtonModeIntegrated";
            this.radioButtonModeIntegrated.Size = new System.Drawing.Size(519, 24);
            this.radioButtonModeIntegrated.TabIndex = 0;
            this.radioButtonModeIntegrated.Text = "Korzystam z wbudowanego w E-Nadawcę importu przesyłek z Allegro";
            this.radioButtonModeIntegrated.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(553, 525);
            this.Controls.Add(this.labelSetAsSent);
            this.Controls.Add(this.checkBoxSetAsSent);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.groupBoxENadawca);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupBoxDb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ustawienia";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.groupBoxDb.ResumeLayout(false);
            this.groupBoxDb.PerformLayout();
            this.groupBoxENadawca.ResumeLayout(false);
            this.groupBoxENadawca.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label labelENadawcaAcc2;
        private System.Windows.Forms.TextBox textBoxENadawcaPass2;
        private System.Windows.Forms.TextBox textBoxENadawcaEmail2;
        private System.Windows.Forms.Label labelENadawcaAcc1;
    }
}