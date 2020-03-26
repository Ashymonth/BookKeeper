namespace BookKeeper.UI
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFiles = new MetroFramework.Controls.MetroButton();
            this.btnShowDebtor = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.cntFilesMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnLoadBase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.lvlDiscounts = new MetroFramework.Controls.MetroListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDiscountOnAddress = new MetroFramework.Controls.MetroButton();
            this.btnDiscountOnAccount = new MetroFramework.Controls.MetroButton();
            this.btnAddDiscountPercent = new MetroFramework.Controls.MetroButton();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.lvlRates = new MetroFramework.Controls.MetroListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRate = new MetroFramework.Controls.MetroButton();
            this.btnDeleteRate = new MetroFramework.Controls.MetroButton();
            this.tbpMonthReport = new MetroFramework.Controls.MetroTabPage();
            this.lvlMonthReport = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbStreet = new MetroFramework.Controls.MetroComboBox();
            this.cmbPersonalAccountType = new MetroFramework.Controls.MetroComboBox();
            this.txtHouse = new MetroFramework.Controls.MetroTextBox();
            this.txtBuilding = new MetroFramework.Controls.MetroTextBox();
            this.txtApartment = new MetroFramework.Controls.MetroTextBox();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime2 = new MetroFramework.Controls.MetroDateTime();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnFind = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dtnDiscountDescription = new MetroFramework.Controls.MetroButton();
            this.btnViewDiscountsParams = new MetroFramework.Controls.MetroButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.cntFilesMenu.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tbpMonthReport.SuspendLayout();
            this.flpFilter.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnShowDebtor);
            this.flowLayoutPanel1.Controls.Add(this.metroButton3);
            this.flowLayoutPanel1.Controls.Add(this.metroButton4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1593, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnFiles
            // 
            this.btnFiles.Location = new System.Drawing.Point(8, 3);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(125, 23);
            this.btnFiles.Style = MetroFramework.MetroColorStyle.Red;
            this.btnFiles.TabIndex = 0;
            this.btnFiles.Text = "Импорт файлов";
            this.btnFiles.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnFiles.UseCustomBackColor = true;
            this.btnFiles.UseSelectable = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnShowDebtor
            // 
            this.btnShowDebtor.Location = new System.Drawing.Point(139, 3);
            this.btnShowDebtor.Name = "btnShowDebtor";
            this.btnShowDebtor.Size = new System.Drawing.Size(167, 23);
            this.btnShowDebtor.TabIndex = 1;
            this.btnShowDebtor.Text = "Показать не оплаченные";
            this.btnShowDebtor.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(312, 3);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(123, 23);
            this.metroButton3.TabIndex = 2;
            this.metroButton3.Text = "metroButton3";
            this.metroButton3.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(441, 3);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(165, 23);
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
            this.metroPanel1.Size = new System.Drawing.Size(1593, 24);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // cntFilesMenu
            // 
            this.cntFilesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadBase,
            this.btnLoadPayments});
            this.cntFilesMenu.Name = "metroContextMenu1";
            this.cntFilesMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cntFilesMenu.Size = new System.Drawing.Size(115, 48);
            // 
            // btnLoadBase
            // 
            this.btnLoadBase.Name = "btnLoadBase";
            this.btnLoadBase.Size = new System.Drawing.Size(114, 22);
            this.btnLoadBase.Text = "База";
            this.btnLoadBase.Click += new System.EventHandler(this.btnLoadBase_Click);
            // 
            // btnLoadPayments
            // 
            this.btnLoadPayments.Name = "btnLoadPayments";
            this.btnLoadPayments.Size = new System.Drawing.Size(114, 22);
            this.btnLoadPayments.Text = "Оплата";
            this.btnLoadPayments.Click += new System.EventHandler(this.btnLoadPayments_Click);
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.lvlDiscounts);
            this.metroTabPage4.Controls.Add(this.flowLayoutPanel2);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Padding = new System.Windows.Forms.Padding(5);
            this.metroTabPage4.Size = new System.Drawing.Size(1585, 740);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Льготы";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // lvlDiscounts
            // 
            this.lvlDiscounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvlDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlDiscounts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvlDiscounts.FullRowSelect = true;
            this.lvlDiscounts.GridLines = true;
            this.lvlDiscounts.Location = new System.Drawing.Point(5, 45);
            this.lvlDiscounts.Name = "lvlDiscounts";
            this.lvlDiscounts.OwnerDraw = true;
            this.lvlDiscounts.Size = new System.Drawing.Size(1575, 690);
            this.lvlDiscounts.TabIndex = 3;
            this.lvlDiscounts.UseCompatibleStateImageBehavior = false;
            this.lvlDiscounts.UseSelectable = true;
            this.lvlDiscounts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Вид";
            this.columnHeader5.Width = 182;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Адрес или счет";
            this.columnHeader8.Width = 206;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Скидка";
            this.columnHeader9.Width = 290;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Описание";
            this.columnHeader10.Width = 383;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnDiscountOnAddress);
            this.flowLayoutPanel2.Controls.Add(this.btnDiscountOnAccount);
            this.flowLayoutPanel2.Controls.Add(this.btnAddDiscountPercent);
            this.flowLayoutPanel2.Controls.Add(this.dtnDiscountDescription);
            this.flowLayoutPanel2.Controls.Add(this.btnViewDiscountsParams);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1575, 40);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnDiscountOnAddress
            // 
            this.btnDiscountOnAddress.Location = new System.Drawing.Point(8, 8);
            this.btnDiscountOnAddress.Name = "btnDiscountOnAddress";
            this.btnDiscountOnAddress.Size = new System.Drawing.Size(116, 23);
            this.btnDiscountOnAddress.TabIndex = 0;
            this.btnDiscountOnAddress.Text = "Добавить адрес";
            this.btnDiscountOnAddress.UseSelectable = true;
            this.btnDiscountOnAddress.Click += new System.EventHandler(this.btnAddDiscount_Click);
            // 
            // btnDiscountOnAccount
            // 
            this.btnDiscountOnAccount.Location = new System.Drawing.Point(130, 8);
            this.btnDiscountOnAccount.Name = "btnDiscountOnAccount";
            this.btnDiscountOnAccount.Size = new System.Drawing.Size(112, 23);
            this.btnDiscountOnAccount.TabIndex = 1;
            this.btnDiscountOnAccount.Text = "Добавить счет";
            this.btnDiscountOnAccount.UseSelectable = true;
            this.btnDiscountOnAccount.Click += new System.EventHandler(this.btnDiscountOnAccount_Click);
            // 
            // btnAddDiscountPercent
            // 
            this.btnAddDiscountPercent.Location = new System.Drawing.Point(248, 8);
            this.btnAddDiscountPercent.Name = "btnAddDiscountPercent";
            this.btnAddDiscountPercent.Size = new System.Drawing.Size(178, 23);
            this.btnAddDiscountPercent.TabIndex = 2;
            this.btnAddDiscountPercent.Text = "Добавить процентную ставку";
            this.btnAddDiscountPercent.UseSelectable = true;
            this.btnAddDiscountPercent.Click += new System.EventHandler(this.btnAddDiscountPercent_Click);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.lvlRates);
            this.metroTabPage3.Controls.Add(this.flowLayoutPanel3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Padding = new System.Windows.Forms.Padding(5);
            this.metroTabPage3.Size = new System.Drawing.Size(1585, 740);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Тарифы";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // lvlRates
            // 
            this.lvlRates.CheckBoxes = true;
            this.lvlRates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7});
            this.lvlRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlRates.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvlRates.FullRowSelect = true;
            this.lvlRates.GridLines = true;
            listViewItem2.StateImageIndex = 0;
            this.lvlRates.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvlRates.Location = new System.Drawing.Point(5, 44);
            this.lvlRates.Name = "lvlRates";
            this.lvlRates.OwnerDraw = true;
            this.lvlRates.Size = new System.Drawing.Size(1575, 691);
            this.lvlRates.TabIndex = 4;
            this.lvlRates.UseCompatibleStateImageBehavior = false;
            this.lvlRates.UseSelectable = true;
            this.lvlRates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "id";
            this.columnHeader2.Text = "Улица";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дом";
            this.columnHeader3.Width = 157;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Корпус";
            this.columnHeader4.Width = 409;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Цена";
            this.columnHeader6.Width = 274;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Описание";
            this.columnHeader7.Width = 544;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnAddRate);
            this.flowLayoutPanel3.Controls.Add(this.btnDeleteRate);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1575, 39);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // btnAddRate
            // 
            this.btnAddRate.Location = new System.Drawing.Point(8, 8);
            this.btnAddRate.Name = "btnAddRate";
            this.btnAddRate.Size = new System.Drawing.Size(116, 23);
            this.btnAddRate.TabIndex = 0;
            this.btnAddRate.Text = "Добавить";
            this.btnAddRate.UseSelectable = true;
            this.btnAddRate.Click += new System.EventHandler(this.btnAddRate_Click);
            // 
            // btnDeleteRate
            // 
            this.btnDeleteRate.Location = new System.Drawing.Point(130, 8);
            this.btnDeleteRate.Name = "btnDeleteRate";
            this.btnDeleteRate.Size = new System.Drawing.Size(140, 23);
            this.btnDeleteRate.TabIndex = 1;
            this.btnDeleteRate.Text = "Удалить выбранные";
            this.btnDeleteRate.UseSelectable = true;
            this.btnDeleteRate.Click += new System.EventHandler(this.btnDeleteRate_Click);
            // 
            // tbpMonthReport
            // 
            this.tbpMonthReport.Controls.Add(this.lvlMonthReport);
            this.tbpMonthReport.Controls.Add(this.flpFilter);
            this.tbpMonthReport.HorizontalScrollbarBarColor = true;
            this.tbpMonthReport.HorizontalScrollbarHighlightOnWheel = false;
            this.tbpMonthReport.HorizontalScrollbarSize = 10;
            this.tbpMonthReport.Location = new System.Drawing.Point(4, 38);
            this.tbpMonthReport.Name = "tbpMonthReport";
            this.tbpMonthReport.Padding = new System.Windows.Forms.Padding(5);
            this.tbpMonthReport.Size = new System.Drawing.Size(1585, 740);
            this.tbpMonthReport.TabIndex = 0;
            this.tbpMonthReport.Text = "Месячный отчет";
            this.tbpMonthReport.VerticalScrollbarBarColor = true;
            this.tbpMonthReport.VerticalScrollbarHighlightOnWheel = false;
            this.tbpMonthReport.VerticalScrollbarSize = 10;
            // 
            // lvlMonthReport
            // 
            this.lvlMonthReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvlMonthReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlMonthReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvlMonthReport.FullRowSelect = true;
            this.lvlMonthReport.GridLines = true;
            this.lvlMonthReport.Location = new System.Drawing.Point(5, 45);
            this.lvlMonthReport.Name = "lvlMonthReport";
            this.lvlMonthReport.OwnerDraw = true;
            this.lvlMonthReport.Size = new System.Drawing.Size(1575, 690);
            this.lvlMonthReport.TabIndex = 5;
            this.lvlMonthReport.UseCompatibleStateImageBehavior = false;
            this.lvlMonthReport.UseSelectable = true;
            this.lvlMonthReport.View = System.Windows.Forms.View.Details;
            this.lvlMonthReport.DoubleClick += new System.EventHandler(this.lvlMonthReport_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Счет";
            this.columnHeader1.Width = 164;
            // 
            // flpFilter
            // 
            this.flpFilter.Controls.Add(this.cmbStreet);
            this.flpFilter.Controls.Add(this.cmbPersonalAccountType);
            this.flpFilter.Controls.Add(this.txtHouse);
            this.flpFilter.Controls.Add(this.txtBuilding);
            this.flpFilter.Controls.Add(this.txtApartment);
            this.flpFilter.Controls.Add(this.metroDateTime1);
            this.flpFilter.Controls.Add(this.metroDateTime2);
            this.flpFilter.Controls.Add(this.metroCheckBox1);
            this.flpFilter.Controls.Add(this.metroCheckBox2);
            this.flpFilter.Controls.Add(this.btnClear);
            this.flpFilter.Controls.Add(this.btnFind);
            this.flpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilter.Location = new System.Drawing.Point(5, 5);
            this.flpFilter.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.flpFilter.Name = "flpFilter";
            this.flpFilter.Size = new System.Drawing.Size(1575, 40);
            this.flpFilter.TabIndex = 4;
            // 
            // cmbStreet
            // 
            this.cmbStreet.DisplayFocus = true;
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.ItemHeight = 23;
            this.cmbStreet.Location = new System.Drawing.Point(3, 3);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.PromptText = "Улица";
            this.cmbStreet.Size = new System.Drawing.Size(283, 29);
            this.cmbStreet.TabIndex = 0;
            this.cmbStreet.UseSelectable = true;
            // 
            // cmbPersonalAccountType
            // 
            this.cmbPersonalAccountType.FormattingEnabled = true;
            this.cmbPersonalAccountType.ItemHeight = 23;
            this.cmbPersonalAccountType.Items.AddRange(new object[] {
            "Муниципальный",
            "Частный"});
            this.cmbPersonalAccountType.Location = new System.Drawing.Point(292, 3);
            this.cmbPersonalAccountType.Name = "cmbPersonalAccountType";
            this.cmbPersonalAccountType.PromptText = "Тип";
            this.cmbPersonalAccountType.Size = new System.Drawing.Size(143, 29);
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
            this.txtHouse.Location = new System.Drawing.Point(441, 3);
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
            this.txtBuilding.Location = new System.Drawing.Point(522, 3);
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
            this.txtApartment.Location = new System.Drawing.Point(603, 3);
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
            this.metroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1.Location = new System.Drawing.Point(684, 3);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(200, 29);
            this.metroDateTime1.TabIndex = 4;
            // 
            // metroDateTime2
            // 
            this.metroDateTime2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime2.Location = new System.Drawing.Point(890, 3);
            this.metroDateTime2.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime2.Name = "metroDateTime2";
            this.metroDateTime2.Size = new System.Drawing.Size(200, 29);
            this.metroDateTime2.TabIndex = 5;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroCheckBox1.Location = new System.Drawing.Point(1096, 3);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(57, 30);
            this.metroCheckBox1.TabIndex = 8;
            this.metroCheckBox1.Text = "Архив";
            this.metroCheckBox1.UseCustomBackColor = true;
            this.metroCheckBox1.UseCustomForeColor = true;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroCheckBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroCheckBox2.Location = new System.Drawing.Point(1159, 3);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(91, 30);
            this.metroCheckBox2.TabIndex = 11;
            this.metroCheckBox2.Text = "Нет корпуса";
            this.metroCheckBox2.UseCustomBackColor = true;
            this.metroCheckBox2.UseCustomForeColor = true;
            this.metroCheckBox2.UseSelectable = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1256, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 30);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Сбросить";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = true;
            this.btnFind.Location = new System.Drawing.Point(1387, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(121, 29);
            this.btnFind.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Найти";
            this.btnFind.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnFind.UseCustomBackColor = true;
            this.btnFind.UseCustomForeColor = true;
            this.btnFind.UseSelectable = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tbpMonthReport);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 116);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(1593, 782);
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.UseSelectable = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dtnDiscountDescription
            // 
            this.dtnDiscountDescription.Location = new System.Drawing.Point(432, 8);
            this.dtnDiscountDescription.Name = "dtnDiscountDescription";
            this.dtnDiscountDescription.Size = new System.Drawing.Size(178, 23);
            this.dtnDiscountDescription.TabIndex = 3;
            this.dtnDiscountDescription.Text = "Добавить описание льготы";
            this.dtnDiscountDescription.UseSelectable = true;
            this.dtnDiscountDescription.Click += new System.EventHandler(this.dtnDiscountDescription_Click);
            // 
            // btnViewDiscountsParams
            // 
            this.btnViewDiscountsParams.Location = new System.Drawing.Point(616, 8);
            this.btnViewDiscountsParams.Name = "btnViewDiscountsParams";
            this.btnViewDiscountsParams.Size = new System.Drawing.Size(177, 23);
            this.btnViewDiscountsParams.TabIndex = 4;
            this.btnViewDiscountsParams.Text = "Изменить описание и скидку";
            this.btnViewDiscountsParams.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1633, 918);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Учет";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.cntFilesMenu.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tbpMonthReport.ResumeLayout(false);
            this.flpFilter.ResumeLayout(false);
            this.flpFilter.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnFiles;
        private MetroFramework.Controls.MetroButton btnShowDebtor;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroContextMenu cntFilesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnLoadBase;
        private System.Windows.Forms.ToolStripMenuItem btnLoadPayments;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroListView lvlDiscounts;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MetroFramework.Controls.MetroButton btnDiscountOnAddress;
        private MetroFramework.Controls.MetroButton btnDiscountOnAccount;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroListView lvlRates;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MetroFramework.Controls.MetroButton btnAddRate;
        private MetroFramework.Controls.MetroTabPage tbpMonthReport;
        private MetroFramework.Controls.MetroListView lvlMonthReport;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private MetroFramework.Controls.MetroComboBox cmbStreet;
        private MetroFramework.Controls.MetroComboBox cmbPersonalAccountType;
        private MetroFramework.Controls.MetroTextBox txtHouse;
        private MetroFramework.Controls.MetroTextBox txtBuilding;
        private MetroFramework.Controls.MetroTextBox txtApartment;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroDateTime metroDateTime2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroButton btnDeleteRate;
        private MetroFramework.Controls.MetroButton btnAddDiscountPercent;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnFind;
        private MetroFramework.Controls.MetroButton dtnDiscountDescription;
        private MetroFramework.Controls.MetroButton btnViewDiscountsParams;
    }
}

