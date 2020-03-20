namespace BookKeeper.UI
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbStreet = new MetroFramework.Controls.MetroComboBox();
            this.cmbPersonalAccountType = new MetroFramework.Controls.MetroComboBox();
            this.txtHouse = new MetroFramework.Controls.MetroTextBox();
            this.txtBuilding = new MetroFramework.Controls.MetroTextBox();
            this.txtApartment = new MetroFramework.Controls.MetroTextBox();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime2 = new MetroFramework.Controls.MetroDateTime();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оплатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookKeepingDataSet = new BookKeeper.UI.BookKeepingDataSet();
            this.accountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountsTableAdapter = new BookKeeper.UI.BookKeepingDataSetTableAdapters.AccountsTableAdapter();
            this.streetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.streetsTableAdapter = new BookKeeper.UI.BookKeepingDataSetTableAdapters.StreetsTableAdapter();
            this.fKPaymentDocumentsAccountsAccountEntityIdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentDocumentsTableAdapter = new BookKeeper.UI.BookKeepingDataSetTableAdapters.PaymentDocumentsTableAdapter();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroListView2 = new MetroFramework.Controls.MetroListView();
            this.flowLayoutPanel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookKeepingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPaymentDocumentsAccountsAccountEntityIdBindingSource)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.metroButton1);
            this.flowLayoutPanel1.Controls.Add(this.metroButton2);
            this.flowLayoutPanel1.Controls.Add(this.metroButton3);
            this.flowLayoutPanel1.Controls.Add(this.metroButton4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1379, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(8, 3);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(125, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Загрузка файлов";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(139, 3);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "metroButton2";
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(220, 3);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(75, 23);
            this.metroButton3.TabIndex = 2;
            this.metroButton3.Text = "metroButton3";
            this.metroButton3.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(301, 3);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(75, 23);
            this.metroButton4.TabIndex = 3;
            this.metroButton4.Text = "metroButton4";
            this.metroButton4.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 92);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1379, 24);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 116);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1379, 782);
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroListView1);
            this.metroTabPage1.Controls.Add(this.flowLayoutPanel2);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.metroTabPage1.Size = new System.Drawing.Size(1371, 740);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Месячный отчет";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroListView1
            // 
            this.metroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.metroListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.GridLines = true;
            this.metroListView1.Location = new System.Drawing.Point(5, 44);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(1361, 691);
            this.metroListView1.TabIndex = 5;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Счет";
            this.columnHeader1.Width = 164;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cmbStreet);
            this.flowLayoutPanel2.Controls.Add(this.cmbPersonalAccountType);
            this.flowLayoutPanel2.Controls.Add(this.txtHouse);
            this.flowLayoutPanel2.Controls.Add(this.txtBuilding);
            this.flowLayoutPanel2.Controls.Add(this.txtApartment);
            this.flowLayoutPanel2.Controls.Add(this.metroDateTime1);
            this.flowLayoutPanel2.Controls.Add(this.metroDateTime2);
            this.flowLayoutPanel2.Controls.Add(this.metroCheckBox1);
            this.flowLayoutPanel2.Controls.Add(this.metroButton5);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1361, 39);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // cmbStreet
            // 
            this.cmbStreet.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.streetsBindingSource, "Id", true));
            this.cmbStreet.DataSource = this.streetsBindingSource;
            this.cmbStreet.DisplayFocus = true;
            this.cmbStreet.DisplayMember = "StreetName";
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.ItemHeight = 23;
            this.cmbStreet.Location = new System.Drawing.Point(3, 3);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.PromptText = "Улица";
            this.cmbStreet.Size = new System.Drawing.Size(302, 29);
            this.cmbStreet.TabIndex = 0;
            this.cmbStreet.UseSelectable = true;
            this.cmbStreet.ValueMember = "Id";
            // 
            // cmbPersonalAccountType
            // 
            this.cmbPersonalAccountType.FormattingEnabled = true;
            this.cmbPersonalAccountType.ItemHeight = 23;
            this.cmbPersonalAccountType.Items.AddRange(new object[] {
            "Муниципальный",
            "Частный"});
            this.cmbPersonalAccountType.Location = new System.Drawing.Point(311, 3);
            this.cmbPersonalAccountType.Name = "cmbPersonalAccountType";
            this.cmbPersonalAccountType.PromptText = "Тип";
            this.cmbPersonalAccountType.Size = new System.Drawing.Size(121, 29);
            this.cmbPersonalAccountType.TabIndex = 9;
            this.cmbPersonalAccountType.UseSelectable = true;
            // 
            // txtHouse
            // 
            // 
            // 
            // 
            this.txtHouse.CustomButton.Image = null;
            this.txtHouse.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.txtHouse.CustomButton.Name = "";
            this.txtHouse.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtHouse.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHouse.CustomButton.TabIndex = 1;
            this.txtHouse.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHouse.CustomButton.UseSelectable = true;
            this.txtHouse.CustomButton.Visible = false;
            this.txtHouse.Lines = new string[0];
            this.txtHouse.Location = new System.Drawing.Point(438, 3);
            this.txtHouse.MaxLength = 32767;
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.PasswordChar = '\0';
            this.txtHouse.PromptText = "Дом";
            this.txtHouse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHouse.SelectedText = "";
            this.txtHouse.SelectionLength = 0;
            this.txtHouse.SelectionStart = 0;
            this.txtHouse.ShortcutsEnabled = true;
            this.txtHouse.Size = new System.Drawing.Size(75, 29);
            this.txtHouse.TabIndex = 1;
            this.txtHouse.UseSelectable = true;
            this.txtHouse.WaterMark = "Дом";
            this.txtHouse.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHouse.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBuilding
            // 
            // 
            // 
            // 
            this.txtBuilding.CustomButton.Image = null;
            this.txtBuilding.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.txtBuilding.CustomButton.Name = "";
            this.txtBuilding.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtBuilding.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBuilding.CustomButton.TabIndex = 1;
            this.txtBuilding.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBuilding.CustomButton.UseSelectable = true;
            this.txtBuilding.CustomButton.Visible = false;
            this.txtBuilding.Lines = new string[0];
            this.txtBuilding.Location = new System.Drawing.Point(519, 3);
            this.txtBuilding.MaxLength = 32767;
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.PasswordChar = '\0';
            this.txtBuilding.PromptText = "Корпус";
            this.txtBuilding.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuilding.SelectedText = "";
            this.txtBuilding.SelectionLength = 0;
            this.txtBuilding.SelectionStart = 0;
            this.txtBuilding.ShortcutsEnabled = true;
            this.txtBuilding.Size = new System.Drawing.Size(75, 29);
            this.txtBuilding.TabIndex = 2;
            this.txtBuilding.UseSelectable = true;
            this.txtBuilding.WaterMark = "Корпус";
            this.txtBuilding.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBuilding.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtApartment
            // 
            // 
            // 
            // 
            this.txtApartment.CustomButton.Image = null;
            this.txtApartment.CustomButton.Location = new System.Drawing.Point(47, 1);
            this.txtApartment.CustomButton.Name = "";
            this.txtApartment.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtApartment.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtApartment.CustomButton.TabIndex = 1;
            this.txtApartment.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtApartment.CustomButton.UseSelectable = true;
            this.txtApartment.CustomButton.Visible = false;
            this.txtApartment.Lines = new string[0];
            this.txtApartment.Location = new System.Drawing.Point(600, 3);
            this.txtApartment.MaxLength = 32767;
            this.txtApartment.Name = "txtApartment";
            this.txtApartment.PasswordChar = '\0';
            this.txtApartment.PromptText = "Квартира";
            this.txtApartment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtApartment.SelectedText = "";
            this.txtApartment.SelectionLength = 0;
            this.txtApartment.SelectionStart = 0;
            this.txtApartment.ShortcutsEnabled = true;
            this.txtApartment.Size = new System.Drawing.Size(75, 29);
            this.txtApartment.TabIndex = 3;
            this.txtApartment.UseSelectable = true;
            this.txtApartment.WaterMark = "Квартира";
            this.txtApartment.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtApartment.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(681, 3);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(200, 29);
            this.metroDateTime1.TabIndex = 4;
            // 
            // metroDateTime2
            // 
            this.metroDateTime2.Location = new System.Drawing.Point(887, 3);
            this.metroDateTime2.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime2.Name = "metroDateTime2";
            this.metroDateTime2.Size = new System.Drawing.Size(200, 29);
            this.metroDateTime2.TabIndex = 5;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroCheckBox1.Location = new System.Drawing.Point(1093, 3);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(57, 29);
            this.metroCheckBox1.TabIndex = 8;
            this.metroCheckBox1.Text = "Архив";
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(1156, 3);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(187, 29);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroButton5.TabIndex = 7;
            this.metroButton5.Text = "Применить";
            this.metroButton5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1371, 740);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Общий отчет";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroListView2);
            this.metroTabPage3.Controls.Add(this.flowLayoutPanel3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1371, 740);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Тарифы";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1371, 740);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Льготы";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базаToolStripMenuItem,
            this.оплатаToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(115, 48);
            // 
            // базаToolStripMenuItem
            // 
            this.базаToolStripMenuItem.Name = "базаToolStripMenuItem";
            this.базаToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.базаToolStripMenuItem.Text = "База";
            // 
            // оплатаToolStripMenuItem
            // 
            this.оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            this.оплатаToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.оплатаToolStripMenuItem.Text = "Оплата";
            // 
            // bookKeepingDataSet
            // 
            this.bookKeepingDataSet.DataSetName = "BookKeepingDataSet";
            this.bookKeepingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountsBindingSource
            // 
            this.accountsBindingSource.DataMember = "Accounts";
            this.accountsBindingSource.DataSource = this.bookKeepingDataSet;
            // 
            // accountsTableAdapter
            // 
            this.accountsTableAdapter.ClearBeforeFill = true;
            // 
            // streetsBindingSource
            // 
            this.streetsBindingSource.DataMember = "Streets";
            this.streetsBindingSource.DataSource = this.bookKeepingDataSet;
            // 
            // streetsTableAdapter
            // 
            this.streetsTableAdapter.ClearBeforeFill = true;
            // 
            // fKPaymentDocumentsAccountsAccountEntityIdBindingSource
            // 
            this.fKPaymentDocumentsAccountsAccountEntityIdBindingSource.DataMember = "FK_PaymentDocuments_Accounts_AccountEntityId";
            this.fKPaymentDocumentsAccountsAccountEntityIdBindingSource.DataSource = this.accountsBindingSource;
            // 
            // paymentDocumentsTableAdapter
            // 
            this.paymentDocumentsTableAdapter.ClearBeforeFill = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.metroButton6);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 701);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1371, 39);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(1283, 8);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(75, 23);
            this.metroButton6.TabIndex = 0;
            this.metroButton6.Text = "metroButton6";
            this.metroButton6.UseSelectable = true;
            // 
            // metroListView2
            // 
            this.metroListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroListView2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView2.FullRowSelect = true;
            this.metroListView2.GridLines = true;
            this.metroListView2.Location = new System.Drawing.Point(0, 0);
            this.metroListView2.Name = "metroListView2";
            this.metroListView2.OwnerDraw = true;
            this.metroListView2.Size = new System.Drawing.Size(1371, 701);
            this.metroListView2.TabIndex = 3;
            this.metroListView2.UseCompatibleStateImageBehavior = false;
            this.metroListView2.UseSelectable = true;
            this.metroListView2.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 918);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookKeepingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPaymentDocumentsAccountsAccountEntityIdBindingSource)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MetroFramework.Controls.MetroComboBox cmbStreet;
        private MetroFramework.Controls.MetroTextBox txtHouse;
        private MetroFramework.Controls.MetroTextBox txtBuilding;
        private MetroFramework.Controls.MetroTextBox txtApartment;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroDateTime metroDateTime2;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroComboBox cmbPersonalAccountType;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оплатаToolStripMenuItem;
        private BookKeepingDataSet bookKeepingDataSet;
        private System.Windows.Forms.BindingSource accountsBindingSource;
        private BookKeepingDataSetTableAdapters.AccountsTableAdapter accountsTableAdapter;
        private System.Windows.Forms.BindingSource streetsBindingSource;
        private BookKeepingDataSetTableAdapters.StreetsTableAdapter streetsTableAdapter;
        private System.Windows.Forms.BindingSource fKPaymentDocumentsAccountsAccountEntityIdBindingSource;
        private BookKeepingDataSetTableAdapters.PaymentDocumentsTableAdapter paymentDocumentsTableAdapter;
        private MetroFramework.Controls.MetroListView metroListView2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MetroFramework.Controls.MetroButton metroButton6;
    }
}

