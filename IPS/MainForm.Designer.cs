namespace IPS
{
	partial class MainForm
	{
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPagePocztaPolska = new System.Windows.Forms.TabPage();
            this.listViewPocztaPolska = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripCopyNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.labelOpenFile = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainData = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePickerPocztaPolska = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelMainOr = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainAccounts = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGetDataPocztaPolska = new System.Windows.Forms.Button();
            this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDHL = new System.Windows.Forms.TabPage();
            this.buttonGetDataDHL = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePickerDHL = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewDHL = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.tabPagePocztaPolska.SuspendLayout();
            this.contextMenuList.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelMainData.SuspendLayout();
            this.tableLayoutPanelMainAccounts.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageDHL.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPagePocztaPolska
            // 
            this.tabPagePocztaPolska.Controls.Add(this.listViewPocztaPolska);
            this.tabPagePocztaPolska.Controls.Add(this.tableLayoutPanelMain);
            this.tabPagePocztaPolska.Location = new System.Drawing.Point(4, 22);
            this.tabPagePocztaPolska.Name = "tabPagePocztaPolska";
            this.tabPagePocztaPolska.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePocztaPolska.Size = new System.Drawing.Size(1062, 384);
            this.tabPagePocztaPolska.TabIndex = 0;
            this.tabPagePocztaPolska.Text = "Poczta Polska";
            this.tabPagePocztaPolska.UseVisualStyleBackColor = true;
            // 
            // listViewPocztaPolska
            // 
            this.listViewPocztaPolska.AllowDrop = true;
            this.listViewPocztaPolska.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPocztaPolska.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewPocztaPolska.ContextMenuStrip = this.contextMenuList;
            this.listViewPocztaPolska.FullRowSelect = true;
            this.listViewPocztaPolska.Location = new System.Drawing.Point(6, 6);
            this.listViewPocztaPolska.MultiSelect = false;
            this.listViewPocztaPolska.Name = "listViewPocztaPolska";
            this.listViewPocztaPolska.Size = new System.Drawing.Size(1050, 258);
            this.listViewPocztaPolska.TabIndex = 11;
            this.listViewPocztaPolska.UseCompatibleStateImageBehavior = false;
            this.listViewPocztaPolska.View = System.Windows.Forms.View.Details;
            this.listViewPocztaPolska.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewPocztaPolska_KeyDown);
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
            this.columnHeader3.Text = "Adres";
            this.columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Miasto";
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
            // contextMenuList
            // 
            this.contextMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripCopyNumber});
            this.contextMenuList.Name = "contextMenuList";
            this.contextMenuList.Size = new System.Drawing.Size(200, 26);
            // 
            // ToolStripCopyNumber
            // 
            this.ToolStripCopyNumber.Name = "ToolStripCopyNumber";
            this.ToolStripCopyNumber.Size = new System.Drawing.Size(199, 22);
            this.ToolStripCopyNumber.Text = "Skopiuj numer przesyłki";
            this.ToolStripCopyNumber.Click += new System.EventHandler(this.ToolStripCopyNumber_Click);
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
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(6, 267);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1050, 111);
            this.tableLayoutPanelMain.TabIndex = 10;
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
            this.buttonOpenFile.Size = new System.Drawing.Size(511, 67);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Otwórz plik danych przesyłek E-Nadawcy";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            // 
            // labelOpenFile
            // 
            this.labelOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOpenFile.AutoSize = true;
            this.labelOpenFile.Location = new System.Drawing.Point(3, 15);
            this.labelOpenFile.Name = "labelOpenFile";
            this.labelOpenFile.Size = new System.Drawing.Size(505, 13);
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
            this.tableLayoutPanelMainData.Controls.Add(this.dateTimePickerPocztaPolska, 1, 0);
            this.tableLayoutPanelMainData.Controls.Add(this.labelDate, 0, 0);
            this.tableLayoutPanelMainData.Location = new System.Drawing.Point(538, 0);
            this.tableLayoutPanelMainData.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMainData.Name = "tableLayoutPanelMainData";
            this.tableLayoutPanelMainData.RowCount = 1;
            this.tableLayoutPanelMainData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainData.Size = new System.Drawing.Size(512, 44);
            this.tableLayoutPanelMainData.TabIndex = 10;
            // 
            // dateTimePickerPocztaPolska
            // 
            this.dateTimePickerPocztaPolska.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.dateTimePickerPocztaPolska.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerPocztaPolska.CustomFormat = "dd.MM.yyyy (ddd)";
            this.dateTimePickerPocztaPolska.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPocztaPolska.Location = new System.Drawing.Point(307, 12);
            this.dateTimePickerPocztaPolska.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimePickerPocztaPolska.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerPocztaPolska.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerPocztaPolska.Name = "dateTimePickerPocztaPolska";
            this.dateTimePickerPocztaPolska.Size = new System.Drawing.Size(205, 20);
            this.dateTimePickerPocztaPolska.TabIndex = 2;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(3, 9);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(301, 26);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "Wskaż datę, od jakiej mają zostać pobrane dane przesyłek z API E-Nadawcy";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMainOr
            // 
            this.labelMainOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMainOr.AutoSize = true;
            this.labelMainOr.Location = new System.Drawing.Point(514, 71);
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
            this.tableLayoutPanelMainAccounts.Controls.Add(this.buttonGetDataPocztaPolska, 0, 1);
            this.tableLayoutPanelMainAccounts.Controls.Add(this.comboBoxAccounts, 0, 0);
            this.tableLayoutPanelMainAccounts.Location = new System.Drawing.Point(538, 44);
            this.tableLayoutPanelMainAccounts.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMainAccounts.Name = "tableLayoutPanelMainAccounts";
            this.tableLayoutPanelMainAccounts.RowCount = 2;
            this.tableLayoutPanelMainAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMainAccounts.Size = new System.Drawing.Size(512, 67);
            this.tableLayoutPanelMainAccounts.TabIndex = 12;
            // 
            // buttonGetDataPocztaPolska
            // 
            this.buttonGetDataPocztaPolska.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetDataPocztaPolska.Location = new System.Drawing.Point(0, 26);
            this.buttonGetDataPocztaPolska.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGetDataPocztaPolska.Name = "buttonGetDataPocztaPolska";
            this.buttonGetDataPocztaPolska.Size = new System.Drawing.Size(512, 41);
            this.buttonGetDataPocztaPolska.TabIndex = 8;
            this.buttonGetDataPocztaPolska.Text = "Pobierz dane przesyłek z API E-Nadawcy";
            this.buttonGetDataPocztaPolska.UseVisualStyleBackColor = true;
            this.buttonGetDataPocztaPolska.Click += new System.EventHandler(this.ButtonGetData_Click);
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
            this.comboBoxAccounts.Size = new System.Drawing.Size(512, 21);
            this.comboBoxAccounts.TabIndex = 9;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPagePocztaPolska);
            this.tabControl.Controls.Add(this.tabPageDHL);
            this.tabControl.Location = new System.Drawing.Point(8, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1070, 410);
            this.tabControl.TabIndex = 8;
            // 
            // tabPageDHL
            // 
            this.tabPageDHL.Controls.Add(this.buttonGetDataDHL);
            this.tabPageDHL.Controls.Add(this.tableLayoutPanel1);
            this.tabPageDHL.Controls.Add(this.listViewDHL);
            this.tabPageDHL.Location = new System.Drawing.Point(4, 22);
            this.tabPageDHL.Name = "tabPageDHL";
            this.tabPageDHL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDHL.Size = new System.Drawing.Size(1062, 384);
            this.tabPageDHL.TabIndex = 1;
            this.tabPageDHL.Text = "DHL";
            this.tabPageDHL.UseVisualStyleBackColor = true;
            // 
            // buttonGetDataDHL
            // 
            this.buttonGetDataDHL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetDataDHL.Location = new System.Drawing.Point(6, 331);
            this.buttonGetDataDHL.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.buttonGetDataDHL.Name = "buttonGetDataDHL";
            this.buttonGetDataDHL.Size = new System.Drawing.Size(1050, 47);
            this.buttonGetDataDHL.TabIndex = 14;
            this.buttonGetDataDHL.Text = "Pobierz dane przesyłek z API DHL";
            this.buttonGetDataDHL.UseVisualStyleBackColor = true;
            this.buttonGetDataDHL.Click += new System.EventHandler(this.ButtonGetDataDHL_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerDHL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 287);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 44);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // dateTimePickerDHL
            // 
            this.dateTimePickerDHL.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.dateTimePickerDHL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDHL.CustomFormat = "dd.MM.yyyy (ddd)";
            this.dateTimePickerDHL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDHL.Location = new System.Drawing.Point(525, 12);
            this.dateTimePickerDHL.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimePickerDHL.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerDHL.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerDHL.Name = "dateTimePickerDHL";
            this.dateTimePickerDHL.Size = new System.Drawing.Size(525, 20);
            this.dateTimePickerDHL.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wskaż datę, od jakiej mają zostać pobrane dane przesyłek z API DHL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listViewDHL
            // 
            this.listViewDHL.AllowDrop = true;
            this.listViewDHL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDHL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewDHL.ContextMenuStrip = this.contextMenuList;
            this.listViewDHL.FullRowSelect = true;
            this.listViewDHL.Location = new System.Drawing.Point(6, 6);
            this.listViewDHL.MultiSelect = false;
            this.listViewDHL.Name = "listViewDHL";
            this.listViewDHL.Size = new System.Drawing.Size(1050, 278);
            this.listViewDHL.TabIndex = 12;
            this.listViewDHL.UseCompatibleStateImageBehavior = false;
            this.listViewDHL.View = System.Windows.Forms.View.Details;
            this.listViewDHL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDHL_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nazwa klienta";
            this.columnHeader7.Width = 141;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Imię i nazwisko";
            this.columnHeader8.Width = 121;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Adres";
            this.columnHeader11.Width = 126;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Miasto";
            this.columnHeader12.Width = 113;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "E-mail";
            this.columnHeader13.Width = 160;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Numer przesyłki";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Status";
            this.columnHeader10.Width = 126;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(8, 484);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1070, 23);
            this.progressBar.TabIndex = 14;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(8, 513);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(1070, 47);
            this.buttonSettings.TabIndex = 13;
            this.buttonSettings.Text = "Ustawienia programu";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonSendData
            // 
            this.buttonSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendData.Location = new System.Drawing.Point(8, 428);
            this.buttonSendData.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(1070, 50);
            this.buttonSendData.TabIndex = 15;
            this.buttonSendData.Text = "Prześlij numery przesyłek do Sello";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.ButtonSendData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 572);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importer Przesyłek Sello";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Form_Closed);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.tabPagePocztaPolska.ResumeLayout(false);
            this.contextMenuList.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelMainData.ResumeLayout(false);
            this.tableLayoutPanelMainData.PerformLayout();
            this.tableLayoutPanelMainAccounts.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageDHL.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TabPage tabPagePocztaPolska;
        private System.Windows.Forms.ListView listViewPocztaPolska;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label labelOpenFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainData;
        private System.Windows.Forms.DateTimePicker dateTimePickerPocztaPolska;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelMainOr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainAccounts;
        private System.Windows.Forms.Button buttonGetDataPocztaPolska;
        private System.Windows.Forms.ComboBox comboBoxAccounts;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDHL;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView listViewDHL;
        private System.Windows.Forms.Button buttonGetDataDHL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDHL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.ContextMenuStrip contextMenuList;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCopyNumber;
    }
}

