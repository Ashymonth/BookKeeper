﻿namespace BookKeeper.UI.UI.Forms.Discount
{
    partial class DiscountOnAddressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountOnAddressForm));
            this.btnSaveDiscount = new MetroFramework.Controls.MetroButton();
            this.dtnCancelDiscount = new MetroFramework.Controls.MetroButton();
            this.cmbStreets = new MetroFramework.Controls.MetroComboBox();
            this.cmbPercent = new MetroFramework.Controls.MetroComboBox();
            this.cmbDescription = new MetroFramework.Controls.MetroComboBox();
            this.Адрес = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cmbApatmens = new MetroFramework.Controls.MetroComboBox();
            this.cmbBuilding = new MetroFramework.Controls.MetroComboBox();
            this.cmbHouses = new MetroFramework.Controls.MetroComboBox();
            this.dateTo = new MetroFramework.Controls.MetroDateTime();
            this.dateFrom = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveDiscount
            // 
            this.btnSaveDiscount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveDiscount.Location = new System.Drawing.Point(772, 410);
            this.btnSaveDiscount.Name = "btnSaveDiscount";
            this.btnSaveDiscount.Size = new System.Drawing.Size(121, 23);
            this.btnSaveDiscount.TabIndex = 11;
            this.btnSaveDiscount.Text = "Сохранить";
            this.btnSaveDiscount.UseSelectable = true;
            this.btnSaveDiscount.Click += new System.EventHandler(this.btnSaveDiscount_Click);
            // 
            // dtnCancelDiscount
            // 
            this.dtnCancelDiscount.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dtnCancelDiscount.Location = new System.Drawing.Point(23, 410);
            this.dtnCancelDiscount.Name = "dtnCancelDiscount";
            this.dtnCancelDiscount.Size = new System.Drawing.Size(120, 23);
            this.dtnCancelDiscount.TabIndex = 12;
            this.dtnCancelDiscount.Text = "Отменить";
            this.dtnCancelDiscount.UseSelectable = true;
            // 
            // cmbStreets
            // 
            this.cmbStreets.FormattingEnabled = true;
            this.cmbStreets.ItemHeight = 23;
            this.cmbStreets.Location = new System.Drawing.Point(23, 75);
            this.cmbStreets.Name = "cmbStreets";
            this.cmbStreets.PromptText = "Адрес";
            this.cmbStreets.Size = new System.Drawing.Size(645, 29);
            this.cmbStreets.TabIndex = 1;
            this.cmbStreets.UseSelectable = true;
            this.cmbStreets.SelectedIndexChanged += new System.EventHandler(this.cmbStreets_SelectedIndexChanged);
            // 
            // cmbPercent
            // 
            this.cmbPercent.FormattingEnabled = true;
            this.cmbPercent.ItemHeight = 23;
            this.cmbPercent.Location = new System.Drawing.Point(254, 147);
            this.cmbPercent.Name = "cmbPercent";
            this.cmbPercent.PromptText = "Скидка";
            this.cmbPercent.Size = new System.Drawing.Size(182, 29);
            this.cmbPercent.TabIndex = 5;
            this.cmbPercent.UseSelectable = true;
            // 
            // cmbDescription
            // 
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.ItemHeight = 23;
            this.cmbDescription.Location = new System.Drawing.Point(254, 210);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.PromptText = "Описание";
            this.cmbDescription.Size = new System.Drawing.Size(182, 29);
            this.cmbDescription.TabIndex = 9;
            this.cmbDescription.UseSelectable = true;
            // 
            // Адрес
            // 
            this.Адрес.AutoSize = true;
            this.Адрес.Location = new System.Drawing.Point(23, 53);
            this.Адрес.Name = "Адрес";
            this.Адрес.Size = new System.Drawing.Size(46, 19);
            this.Адрес.TabIndex = 0;
            this.Адрес.Text = "Адрес";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(254, 118);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Скидка";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(254, 183);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Описание";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 247);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 17;
            this.metroLabel1.Text = "Квартира";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 183);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 15;
            this.metroLabel4.Text = "Корпус";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(23, 115);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(35, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Дом";
            // 
            // cmbApatmens
            // 
            this.cmbApatmens.FormattingEnabled = true;
            this.cmbApatmens.ItemHeight = 23;
            this.cmbApatmens.Location = new System.Drawing.Point(23, 274);
            this.cmbApatmens.Name = "cmbApatmens";
            this.cmbApatmens.PromptText = "Квартира";
            this.cmbApatmens.Size = new System.Drawing.Size(182, 29);
            this.cmbApatmens.TabIndex = 18;
            this.cmbApatmens.UseSelectable = true;
            // 
            // cmbBuilding
            // 
            this.cmbBuilding.FormattingEnabled = true;
            this.cmbBuilding.ItemHeight = 23;
            this.cmbBuilding.Location = new System.Drawing.Point(23, 210);
            this.cmbBuilding.Name = "cmbBuilding";
            this.cmbBuilding.PromptText = "Корпус";
            this.cmbBuilding.Size = new System.Drawing.Size(182, 29);
            this.cmbBuilding.TabIndex = 16;
            this.cmbBuilding.UseSelectable = true;
            this.cmbBuilding.SelectedIndexChanged += new System.EventHandler(this.cmbBuilding_SelectedIndexChanged);
            // 
            // cmbHouses
            // 
            this.cmbHouses.FormattingEnabled = true;
            this.cmbHouses.ItemHeight = 23;
            this.cmbHouses.Location = new System.Drawing.Point(23, 147);
            this.cmbHouses.Name = "cmbHouses";
            this.cmbHouses.PromptText = "Дом";
            this.cmbHouses.Size = new System.Drawing.Size(182, 29);
            this.cmbHouses.TabIndex = 14;
            this.cmbHouses.UseSelectable = true;
            this.cmbHouses.SelectedIndexChanged += new System.EventHandler(this.cmbHouses_SelectedIndexChanged);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MMMM yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(468, 210);
            this.dateTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 29);
            this.dateTo.TabIndex = 20;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMMM yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(468, 147);
            this.dateFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 29);
            this.dateFrom.TabIndex = 19;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(468, 183);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(47, 19);
            this.metroLabel6.TabIndex = 26;
            this.metroLabel6.Text = "Конец";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(468, 118);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(54, 19);
            this.metroLabel7.TabIndex = 25;
            this.metroLabel7.Text = "Начало";
            // 
            // lstPeople
            // 
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.Location = new System.Drawing.Point(701, 75);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(192, 225);
            this.lstPeople.TabIndex = 28;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(701, 335);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(192, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Добавить льготника";
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(701, 364);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 23);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblCounter});
            this.statusStrip1.Location = new System.Drawing.Point(20, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabel1.Text = "Количество проживающих:";
            // 
            // lblCounter
            // 
            this.lblCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(13, 17);
            this.lblCounter.Text = "0";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(701, 306);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(192, 23);
            this.metroButton1.TabIndex = 32;
            this.metroButton1.Text = "Добавить проживающего";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // DiscountOnAddressForm
            // 
            this.AcceptButton = this.btnSaveDiscount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.dtnCancelDiscount;
            this.ClientSize = new System.Drawing.Size(916, 496);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstPeople);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cmbApatmens);
            this.Controls.Add(this.cmbBuilding);
            this.Controls.Add(this.cmbHouses);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.Адрес);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.dtnCancelDiscount);
            this.Controls.Add(this.btnSaveDiscount);
            this.Controls.Add(this.cmbPercent);
            this.Controls.Add(this.cmbStreets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountOnAddressForm";
            this.Resizable = false;
            this.Text = "Льгота на адрес";
            this.Load += new System.EventHandler(this.DiscountOnAddressForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnSaveDiscount;
        private MetroFramework.Controls.MetroButton dtnCancelDiscount;
        private MetroFramework.Controls.MetroComboBox cmbStreets;
        private MetroFramework.Controls.MetroComboBox cmbPercent;
        private MetroFramework.Controls.MetroComboBox cmbDescription;
        private MetroFramework.Controls.MetroLabel Адрес;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cmbApatmens;
        private MetroFramework.Controls.MetroComboBox cmbBuilding;
        private MetroFramework.Controls.MetroComboBox cmbHouses;
        private MetroFramework.Controls.MetroDateTime dateTo;
        private MetroFramework.Controls.MetroDateTime dateFrom;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.ListBox lstPeople;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCounter;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}