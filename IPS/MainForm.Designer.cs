namespace IPS
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonSendData;
		private System.Windows.Forms.Button buttonOpenFile;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Button buttonGetData;
		private System.Windows.Forms.Label labelOpenFile;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainData;
		private System.Windows.Forms.Label labelDate;
		private System.Windows.Forms.Label labelMainOr;
		
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelOpenFile = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainData = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelMainOr = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainAccounts = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGetData = new System.Windows.Forms.Button();
            this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelMainData.SuspendLayout();
            this.tableLayoutPanelMainAccounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonSendData
            // 
            this.buttonSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendData.Location = new System.Drawing.Point(11, 483);
            this.buttonSendData.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(885, 50);
            this.buttonSendData.TabIndex = 0;
            this.buttonSendData.Text = "Prześlij numery przesyłek do Sello";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.ButtonSendData_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFile.AutoSize = true;
            this.buttonOpenFile.Location = new System.Drawing.Point(0, 44);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(428, 67);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Otwórz plik danych przesyłek E-Nadawcy";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonOpenFile, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelOpenFile, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMainData, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelMainOr, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMainAccounts, 2, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(12, 284);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(884, 111);
            this.tableLayoutPanelMain.TabIndex = 5;
            // 
            // labelOpenFile
            // 
            this.labelOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOpenFile.AutoSize = true;
            this.labelOpenFile.Location = new System.Drawing.Point(3, 15);
            this.labelOpenFile.Name = "labelOpenFile";
            this.labelOpenFile.Size = new System.Drawing.Size(422, 13);
            this.labelOpenFile.TabIndex = 9;
            this.labelOpenFile.Text = "Wskaż plik, z którego mają zostać wczytane przesyłki";
            this.labelOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelMainData
            // 
            this.tableLayoutPanelMainData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMainData.ColumnCount = 2;
            this.tableLayoutPanelMainData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMainData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainData.Controls.Add(this.dateTimePicker, 1, 0);
            this.tableLayoutPanelMainData.Controls.Add(this.labelDate, 0, 0);
            this.tableLayoutPanelMainData.Location = new System.Drawing.Point(455, 0);
            this.tableLayoutPanelMainData.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMainData.Name = "tableLayoutPanelMainData";
            this.tableLayoutPanelMainData.RowCount = 1;
            this.tableLayoutPanelMainData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainData.Size = new System.Drawing.Size(429, 44);
            this.tableLayoutPanelMainData.TabIndex = 10;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.CustomFormat = "dd.MM.yyyy (ddd)";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(257, 12);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimePicker.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(172, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(3, 9);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(251, 26);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "Wskaż datę, od jakiej mają zostać pobrane dane przesyłek z API E-Nadawcy";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMainOr
            // 
            this.labelMainOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMainOr.AutoSize = true;
            this.labelMainOr.Location = new System.Drawing.Point(431, 71);
            this.labelMainOr.Name = "labelMainOr";
            this.labelMainOr.Size = new System.Drawing.Size(21, 13);
            this.labelMainOr.TabIndex = 11;
            this.labelMainOr.Text = "lub";
            this.labelMainOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelMainAccounts
            // 
            this.tableLayoutPanelMainAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMainAccounts.ColumnCount = 1;
            this.tableLayoutPanelMainAccounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainAccounts.Controls.Add(this.buttonGetData, 0, 1);
            this.tableLayoutPanelMainAccounts.Controls.Add(this.comboBoxAccounts, 0, 0);
            this.tableLayoutPanelMainAccounts.Location = new System.Drawing.Point(455, 44);
            this.tableLayoutPanelMainAccounts.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMainAccounts.Name = "tableLayoutPanelMainAccounts";
            this.tableLayoutPanelMainAccounts.RowCount = 2;
            this.tableLayoutPanelMainAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMainAccounts.Size = new System.Drawing.Size(429, 67);
            this.tableLayoutPanelMainAccounts.TabIndex = 12;
            // 
            // buttonGetData
            // 
            this.buttonGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetData.Location = new System.Drawing.Point(0, 26);
            this.buttonGetData.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGetData.Name = "buttonGetData";
            this.buttonGetData.Size = new System.Drawing.Size(429, 41);
            this.buttonGetData.TabIndex = 8;
            this.buttonGetData.Text = "Pobierz dane przesyłek z API E-Nadawcy";
            this.buttonGetData.UseVisualStyleBackColor = true;
            this.buttonGetData.Click += new System.EventHandler(this.ButtonGetData_Click);
            // 
            // comboBoxAccounts
            // 
            this.comboBoxAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccounts.FormattingEnabled = true;
            this.comboBoxAccounts.Location = new System.Drawing.Point(0, 0);
            this.comboBoxAccounts.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.comboBoxAccounts.Name = "comboBoxAccounts";
            this.comboBoxAccounts.Size = new System.Drawing.Size(429, 21);
            this.comboBoxAccounts.TabIndex = 9;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(11, 430);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(885, 47);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "Ustawienia programu";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(884, 266);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nazwa klienta";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nick klienta";
            this.columnHeader2.Width = 109;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Adres docelowy";
            this.columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Miasto docelowe";
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Numer przesyłki";
            this.columnHeader5.Width = 147;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 125;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(11, 401);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(885, 23);
            this.progressBar.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 545);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importer Przesyłek Sello";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Form_Closed);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelMainData.ResumeLayout(false);
            this.tableLayoutPanelMainData.PerformLayout();
            this.tableLayoutPanelMainAccounts.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainAccounts;
        private System.Windows.Forms.ComboBox comboBoxAccounts;
    }
}

