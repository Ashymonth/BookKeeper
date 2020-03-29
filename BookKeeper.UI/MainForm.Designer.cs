﻿namespace BookKeeper.UI
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
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("");
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFiles = new MetroFramework.Controls.MetroButton();
            this.btnDataBase = new MetroFramework.Controls.MetroButton();
            this.btnShowDebtor = new MetroFramework.Controls.MetroButton();
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
            this.btnAddDiscountPercent = new MetroFramework.Controls.MetroButton();
            this.dtnDiscountDescription = new MetroFramework.Controls.MetroButton();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.lvlRates = new MetroFramework.Controls.MetroListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkDeletedRates = new MetroFramework.Controls.MetroCheckBox();
            this.bthHideDeletedRates = new MetroFramework.Controls.MetroButton();
            this.btnShowDeleteRates = new MetroFramework.Controls.MetroButton();
            this.tbpMonthReport = new MetroFramework.Controls.MetroTabPage();
            this.lvlMonthReport = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbStreet = new MetroFramework.Controls.MetroComboBox();
            this.cmbPersonalAccountType = new MetroFramework.Controls.MetroComboBox();
            this.txtHouse = new MetroFramework.Controls.MetroTextBox();
            this.txtBuilding = new MetroFramework.Controls.MetroTextBox();
            this.txtApartment = new MetroFramework.Controls.MetroTextBox();
            this.dateFrom = new MetroFramework.Controls.MetroDateTime();
            this.dateTo = new MetroFramework.Controls.MetroDateTime();
            this.txtAccount = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnFind = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cntDatabase = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnCreateBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadFromBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.cntDiscounts = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnDiscountOnAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDiscountOnAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDiscounts = new MetroFramework.Controls.MetroButton();
            this.btnHouses = new MetroFramework.Controls.MetroButton();
            this.cntRates = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnAddRate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteRate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRates = new MetroFramework.Controls.MetroButton();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.flowLayoutPanel1.SuspendLayout();
            this.cntFilesMenu.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tbpMonthReport.SuspendLayout();
            this.flpFilter.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.cntDatabase.SuspendLayout();
            this.cntDiscounts.SuspendLayout();
            this.cntRates.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnDataBase);
            this.flowLayoutPanel1.Controls.Add(this.btnHouses);
            this.flowLayoutPanel1.Controls.Add(this.btnShowDebtor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1732, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnFiles
            // 
            this.btnFiles.Location = new System.Drawing.Point(8, 3);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(125, 23);
            this.btnFiles.Style = MetroFramework.MetroColorStyle.Red;
            this.btnFiles.TabIndex = 0;
            this.btnFiles.Text = "Импорт";
            this.btnFiles.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnFiles.UseCustomBackColor = true;
            this.btnFiles.UseSelectable = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnDataBase
            // 
            this.btnDataBase.Location = new System.Drawing.Point(139, 3);
            this.btnDataBase.Name = "btnDataBase";
            this.btnDataBase.Size = new System.Drawing.Size(123, 23);
            this.btnDataBase.TabIndex = 4;
            this.btnDataBase.Text = "База данных";
            this.btnDataBase.UseSelectable = true;
            this.btnDataBase.Click += new System.EventHandler(this.btnDataBase_Click);
            // 
            // btnShowDebtor
            // 
            this.btnShowDebtor.Location = new System.Drawing.Point(354, 3);
            this.btnShowDebtor.Name = "btnShowDebtor";
            this.btnShowDebtor.Size = new System.Drawing.Size(167, 23);
            this.btnShowDebtor.TabIndex = 1;
            this.btnShowDebtor.Text = "Показать не оплаченные";
            this.btnShowDebtor.UseSelectable = true;
            this.btnShowDebtor.Click += new System.EventHandler(this.btnShowDebtor_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 92);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1732, 24);
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
            this.cntFilesMenu.Size = new System.Drawing.Size(124, 48);
            // 
            // btnLoadBase
            // 
            this.btnLoadBase.Name = "btnLoadBase";
            this.btnLoadBase.Size = new System.Drawing.Size(123, 22);
            this.btnLoadBase.Text = "Реестр";
            this.btnLoadBase.Click += new System.EventHandler(this.btnLoadBase_Click);
            // 
            // btnLoadPayments
            // 
            this.btnLoadPayments.Name = "btnLoadPayments";
            this.btnLoadPayments.Size = new System.Drawing.Size(123, 22);
            this.btnLoadPayments.Text = "Платежи";
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
            this.metroTabPage4.Size = new System.Drawing.Size(1724, 740);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Льготы";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // lvlDiscounts
            // 
            this.lvlDiscounts.CheckBoxes = true;
            this.lvlDiscounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvlDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlDiscounts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvlDiscounts.FullRowSelect = true;
            this.lvlDiscounts.GridLines = true;
            listViewItem14.StateImageIndex = 0;
            this.lvlDiscounts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem14});
            this.lvlDiscounts.Location = new System.Drawing.Point(5, 45);
            this.lvlDiscounts.Name = "lvlDiscounts";
            this.lvlDiscounts.Size = new System.Drawing.Size(1714, 690);
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
            this.columnHeader8.Width = 700;
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
            this.flowLayoutPanel2.Controls.Add(this.btnAddDiscounts);
            this.flowLayoutPanel2.Controls.Add(this.btnAddDiscountPercent);
            this.flowLayoutPanel2.Controls.Add(this.dtnDiscountDescription);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1714, 40);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnAddDiscountPercent
            // 
            this.btnAddDiscountPercent.Location = new System.Drawing.Point(130, 8);
            this.btnAddDiscountPercent.Name = "btnAddDiscountPercent";
            this.btnAddDiscountPercent.Size = new System.Drawing.Size(178, 23);
            this.btnAddDiscountPercent.TabIndex = 2;
            this.btnAddDiscountPercent.Text = "Добавить процентную ставку";
            this.btnAddDiscountPercent.UseSelectable = true;
            this.btnAddDiscountPercent.Click += new System.EventHandler(this.btnAddDiscountPercent_Click);
            // 
            // dtnDiscountDescription
            // 
            this.dtnDiscountDescription.Location = new System.Drawing.Point(314, 8);
            this.dtnDiscountDescription.Name = "dtnDiscountDescription";
            this.dtnDiscountDescription.Size = new System.Drawing.Size(178, 23);
            this.dtnDiscountDescription.TabIndex = 3;
            this.dtnDiscountDescription.Text = "Добавить описание льготы";
            this.dtnDiscountDescription.UseSelectable = true;
            this.dtnDiscountDescription.Click += new System.EventHandler(this.dtnDiscountDescription_Click);
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
            this.metroTabPage3.Size = new System.Drawing.Size(1724, 740);
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
            listViewItem15.StateImageIndex = 0;
            this.lvlRates.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem15});
            this.lvlRates.Location = new System.Drawing.Point(5, 44);
            this.lvlRates.Name = "lvlRates";
            this.lvlRates.Size = new System.Drawing.Size(1714, 691);
            this.lvlRates.TabIndex = 6;
            this.lvlRates.UseCompatibleStateImageBehavior = false;
            this.lvlRates.UseCustomBackColor = true;
            this.lvlRates.UseCustomForeColor = true;
            this.lvlRates.UseSelectable = true;
            this.lvlRates.View = System.Windows.Forms.View.Details;
            this.lvlRates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvlRates_MouseDoubleClick);
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
            this.flowLayoutPanel3.Controls.Add(this.btnRates);
            this.flowLayoutPanel3.Controls.Add(this.chkDeletedRates);
            this.flowLayoutPanel3.Controls.Add(this.btnShowDeleteRates);
            this.flowLayoutPanel3.Controls.Add(this.bthHideDeletedRates);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1714, 39);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // chkDeletedRates
            // 
            this.chkDeletedRates.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDeletedRates.AutoSize = true;
            this.chkDeletedRates.BackColor = System.Drawing.Color.Transparent;
            this.chkDeletedRates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeletedRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDeletedRates.Location = new System.Drawing.Point(130, 8);
            this.chkDeletedRates.Name = "chkDeletedRates";
            this.chkDeletedRates.Size = new System.Drawing.Size(130, 23);
            this.chkDeletedRates.TabIndex = 12;
            this.chkDeletedRates.Text = "Удаленные тарифы";
            this.chkDeletedRates.UseCustomBackColor = true;
            this.chkDeletedRates.UseCustomForeColor = true;
            this.chkDeletedRates.UseSelectable = true;
            // 
            // bthHideDeletedRates
            // 
            this.bthHideDeletedRates.Location = new System.Drawing.Point(412, 8);
            this.bthHideDeletedRates.Name = "bthHideDeletedRates";
            this.bthHideDeletedRates.Size = new System.Drawing.Size(140, 23);
            this.bthHideDeletedRates.TabIndex = 14;
            this.bthHideDeletedRates.Text = "Скрыть";
            this.bthHideDeletedRates.UseSelectable = true;
            this.bthHideDeletedRates.Click += new System.EventHandler(this.bthHideDeletedRates_Click);
            // 
            // btnShowDeleteRates
            // 
            this.btnShowDeleteRates.Location = new System.Drawing.Point(266, 8);
            this.btnShowDeleteRates.Name = "btnShowDeleteRates";
            this.btnShowDeleteRates.Size = new System.Drawing.Size(140, 23);
            this.btnShowDeleteRates.TabIndex = 13;
            this.btnShowDeleteRates.Text = "Показать";
            this.btnShowDeleteRates.UseSelectable = true;
            this.btnShowDeleteRates.Click += new System.EventHandler(this.btnShowDeleteRates_Click);
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
            this.tbpMonthReport.Size = new System.Drawing.Size(1724, 740);
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
            this.lvlMonthReport.Location = new System.Drawing.Point(5, 41);
            this.lvlMonthReport.Name = "lvlMonthReport";
            this.lvlMonthReport.OwnerDraw = true;
            this.lvlMonthReport.Size = new System.Drawing.Size(1714, 694);
            this.lvlMonthReport.TabIndex = 5;
            this.lvlMonthReport.UseCompatibleStateImageBehavior = false;
            this.lvlMonthReport.UseCustomBackColor = true;
            this.lvlMonthReport.UseCustomForeColor = true;
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
            this.flpFilter.AutoSize = true;
            this.flpFilter.Controls.Add(this.cmbStreet);
            this.flpFilter.Controls.Add(this.cmbPersonalAccountType);
            this.flpFilter.Controls.Add(this.txtHouse);
            this.flpFilter.Controls.Add(this.txtBuilding);
            this.flpFilter.Controls.Add(this.txtApartment);
            this.flpFilter.Controls.Add(this.dateFrom);
            this.flpFilter.Controls.Add(this.dateTo);
            this.flpFilter.Controls.Add(this.txtAccount);
            this.flpFilter.Controls.Add(this.metroCheckBox1);
            this.flpFilter.Controls.Add(this.metroCheckBox2);
            this.flpFilter.Controls.Add(this.btnClear);
            this.flpFilter.Controls.Add(this.btnFind);
            this.flpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilter.Location = new System.Drawing.Point(5, 5);
            this.flpFilter.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.flpFilter.Name = "flpFilter";
            this.flpFilter.Size = new System.Drawing.Size(1714, 36);
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
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMMM yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(684, 3);
            this.dateFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 29);
            this.dateFrom.TabIndex = 4;
            this.dateFrom.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MMMM yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(890, 3);
            this.dateTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(186, 29);
            this.dateTo.TabIndex = 5;
            // 
            // txtAccount
            // 
            // 
            // 
            // 
            this.txtAccount.CustomButton.Image = null;
            this.txtAccount.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtAccount.CustomButton.Name = "";
            this.txtAccount.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtAccount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccount.CustomButton.TabIndex = 1;
            this.txtAccount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccount.CustomButton.UseSelectable = true;
            this.txtAccount.CustomButton.Visible = false;
            this.txtAccount.Lines = new string[0];
            this.txtAccount.Location = new System.Drawing.Point(1082, 3);
            this.txtAccount.MaxLength = 32767;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.PasswordChar = '\0';
            this.txtAccount.PromptText = "Номер счета";
            this.txtAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccount.SelectedText = "";
            this.txtAccount.SelectionLength = 0;
            this.txtAccount.SelectionStart = 0;
            this.txtAccount.ShortcutsEnabled = true;
            this.txtAccount.Size = new System.Drawing.Size(155, 29);
            this.txtAccount.TabIndex = 14;
            this.txtAccount.UseSelectable = true;
            this.txtAccount.WaterMark = "Номер счета";
            this.txtAccount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroCheckBox1.Location = new System.Drawing.Point(1243, 3);
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
            this.metroCheckBox2.Location = new System.Drawing.Point(1306, 3);
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
            this.btnClear.Location = new System.Drawing.Point(1403, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 30);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Сбросить";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = true;
            this.btnFind.Location = new System.Drawing.Point(1477, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(66, 29);
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
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 116);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(1732, 782);
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.UseSelectable = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cntDatabase
            // 
            this.cntDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateBackup,
            this.btnLoadFromBackup});
            this.cntDatabase.Name = "metroContextMenu1";
            this.cntDatabase.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cntDatabase.Size = new System.Drawing.Size(150, 48);
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(149, 22);
            this.btnCreateBackup.Text = "Бэкап";
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // btnLoadFromBackup
            // 
            this.btnLoadFromBackup.Name = "btnLoadFromBackup";
            this.btnLoadFromBackup.Size = new System.Drawing.Size(149, 22);
            this.btnLoadFromBackup.Text = "Восстановить";
            this.btnLoadFromBackup.Click += new System.EventHandler(this.btnLoadFromBackup_Click);
            // 
            // cntDiscounts
            // 
            this.cntDiscounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDiscountOnAccount,
            this.btnDiscountOnAddress});
            this.cntDiscounts.Name = "metroContextMenu1";
            this.cntDiscounts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cntDiscounts.Size = new System.Drawing.Size(126, 48);
            // 
            // btnDiscountOnAccount
            // 
            this.btnDiscountOnAccount.Name = "btnDiscountOnAccount";
            this.btnDiscountOnAccount.Size = new System.Drawing.Size(107, 22);
            this.btnDiscountOnAccount.Text = "Счет";
            this.btnDiscountOnAccount.Click += new System.EventHandler(this.btnDiscountOnAccount_Click_1);
            // 
            // btnDiscountOnAddress
            // 
            this.btnDiscountOnAddress.Name = "btnDiscountOnAddress";
            this.btnDiscountOnAddress.Size = new System.Drawing.Size(125, 22);
            this.btnDiscountOnAddress.Text = "Квартиру";
            this.btnDiscountOnAddress.Click += new System.EventHandler(this.btnDiscountOnAddress_Click);
            // 
            // btnAddDiscounts
            // 
            this.btnAddDiscounts.Location = new System.Drawing.Point(8, 8);
            this.btnAddDiscounts.Name = "btnAddDiscounts";
            this.btnAddDiscounts.Size = new System.Drawing.Size(116, 23);
            this.btnAddDiscounts.TabIndex = 5;
            this.btnAddDiscounts.Text = "Добавить";
            this.btnAddDiscounts.UseSelectable = true;
            this.btnAddDiscounts.Click += new System.EventHandler(this.btnAddDiscounts_Click);
            // 
            // btnHouses
            // 
            this.btnHouses.Location = new System.Drawing.Point(268, 3);
            this.btnHouses.Name = "btnHouses";
            this.btnHouses.Size = new System.Drawing.Size(80, 23);
            this.btnHouses.TabIndex = 5;
            this.btnHouses.Text = "Дома";
            this.btnHouses.UseSelectable = true;
            this.btnHouses.Click += new System.EventHandler(this.btnHouses_Click);
            // 
            // cntRates
            // 
            this.cntRates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRate,
            this.btnDeleteRate});
            this.cntRates.Name = "metroContextMenu1";
            this.cntRates.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cntRates.Size = new System.Drawing.Size(127, 48);
            // 
            // btnAddRate
            // 
            this.btnAddRate.Name = "btnAddRate";
            this.btnAddRate.Size = new System.Drawing.Size(180, 22);
            this.btnAddRate.Text = "Добавить";
            this.btnAddRate.Click += new System.EventHandler(this.btnAddRate_Click_1);
            // 
            // btnDeleteRate
            // 
            this.btnDeleteRate.Name = "btnDeleteRate";
            this.btnDeleteRate.Size = new System.Drawing.Size(180, 22);
            this.btnDeleteRate.Text = "Удалить";
            this.btnDeleteRate.Click += new System.EventHandler(this.btnDeleteRate_Click_1);
            // 
            // btnRates
            // 
            this.btnRates.Location = new System.Drawing.Point(8, 8);
            this.btnRates.Name = "btnRates";
            this.btnRates.Size = new System.Drawing.Size(116, 23);
            this.btnRates.TabIndex = 15;
            this.btnRates.Text = "Тарифы";
            this.btnRates.UseSelectable = true;
            this.btnRates.Click += new System.EventHandler(this.btnRates_Click);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1724, 740);
            this.metroTabPage1.TabIndex = 4;
            this.metroTabPage1.Text = "metroTabPage1";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 918);
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
            this.flowLayoutPanel3.PerformLayout();
            this.tbpMonthReport.ResumeLayout(false);
            this.tbpMonthReport.PerformLayout();
            this.flpFilter.ResumeLayout(false);
            this.flpFilter.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.cntDatabase.ResumeLayout(false);
            this.cntDiscounts.ResumeLayout(false);
            this.cntRates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnFiles;
        private MetroFramework.Controls.MetroButton btnShowDebtor;
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
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage tbpMonthReport;
        private MetroFramework.Controls.MetroListView lvlMonthReport;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private MetroFramework.Controls.MetroComboBox cmbStreet;
        private MetroFramework.Controls.MetroComboBox cmbPersonalAccountType;
        private MetroFramework.Controls.MetroTextBox txtHouse;
        private MetroFramework.Controls.MetroTextBox txtBuilding;
        private MetroFramework.Controls.MetroTextBox txtApartment;
        private MetroFramework.Controls.MetroDateTime dateFrom;
        private MetroFramework.Controls.MetroDateTime dateTo;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroButton btnAddDiscountPercent;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnFind;
        private MetroFramework.Controls.MetroButton dtnDiscountDescription;
        private MetroFramework.Controls.MetroTextBox txtAccount;
        private MetroFramework.Controls.MetroListView lvlRates;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MetroFramework.Controls.MetroCheckBox chkDeletedRates;
        private MetroFramework.Controls.MetroButton bthHideDeletedRates;
        private MetroFramework.Controls.MetroButton btnShowDeleteRates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MetroFramework.Controls.MetroContextMenu cntDatabase;
        private System.Windows.Forms.ToolStripMenuItem btnCreateBackup;
        private System.Windows.Forms.ToolStripMenuItem btnLoadFromBackup;
        private MetroFramework.Controls.MetroButton btnDataBase;
        private MetroFramework.Controls.MetroButton btnAddDiscounts;
        private MetroFramework.Controls.MetroContextMenu cntDiscounts;
        private System.Windows.Forms.ToolStripMenuItem btnDiscountOnAccount;
        private System.Windows.Forms.ToolStripMenuItem btnDiscountOnAddress;
        private MetroFramework.Controls.MetroButton btnHouses;
        private MetroFramework.Controls.MetroButton btnRates;
        private MetroFramework.Controls.MetroContextMenu cntRates;
        private System.Windows.Forms.ToolStripMenuItem btnAddRate;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteRate;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
    }
}
