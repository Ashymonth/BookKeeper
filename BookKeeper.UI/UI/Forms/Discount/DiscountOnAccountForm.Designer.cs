namespace BookKeeper.UI.UI.Forms.Discount
{
    partial class DiscountAccountItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountAccountItemForm));
            this.txtAccount = new MetroFramework.Controls.MetroTextBox();
            this.cmbPercent = new MetroFramework.Controls.MetroComboBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.cmbDescription = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dateTo = new MetroFramework.Controls.MetroDateTime();
            this.dateFrom = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnAddOccupant = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnAddOccupantWithDiscount = new MetroFramework.Controls.MetroButton();
            this.lstOccupants = new System.Windows.Forms.ListBox();
            this.chkUnlimitedLastDate = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            this.txtAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtAccount.CustomButton.Image = null;
            this.txtAccount.CustomButton.Location = new System.Drawing.Point(257, 1);
            this.txtAccount.CustomButton.Name = "";
            this.txtAccount.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtAccount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccount.CustomButton.TabIndex = 1;
            this.txtAccount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccount.CustomButton.UseSelectable = true;
            this.txtAccount.CustomButton.Visible = false;
            this.txtAccount.Lines = new string[0];
            this.txtAccount.Location = new System.Drawing.Point(23, 83);
            this.txtAccount.MaxLength = 32767;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.PasswordChar = '\0';
            this.txtAccount.PromptText = "Номер счета";
            this.txtAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccount.SelectedText = "";
            this.txtAccount.SelectionLength = 0;
            this.txtAccount.SelectionStart = 0;
            this.txtAccount.ShortcutsEnabled = true;
            this.txtAccount.Size = new System.Drawing.Size(285, 29);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.UseSelectable = true;
            this.txtAccount.WaterMark = "Номер счета";
            this.txtAccount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbPercent
            // 
            this.cmbPercent.FormattingEnabled = true;
            this.cmbPercent.ItemHeight = 23;
            this.cmbPercent.Location = new System.Drawing.Point(23, 136);
            this.cmbPercent.Name = "cmbPercent";
            this.cmbPercent.PromptText = "Процент скидки";
            this.cmbPercent.Size = new System.Drawing.Size(285, 29);
            this.cmbPercent.TabIndex = 1;
            this.cmbPercent.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(420, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(23, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseSelectable = true;
            // 
            // cmbDescription
            // 
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.ItemHeight = 23;
            this.cmbDescription.Location = new System.Drawing.Point(23, 190);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.PromptText = "Описание";
            this.cmbDescription.Size = new System.Drawing.Size(285, 29);
            this.cmbDescription.TabIndex = 4;
            this.cmbDescription.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 167);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Описание";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Скидка";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(37, 19);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Счет";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MMMM yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(23, 308);
            this.dateTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(285, 29);
            this.dateTo.TabIndex = 22;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMMM yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(23, 248);
            this.dateFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(285, 29);
            this.dateFrom.TabIndex = 21;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 226);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(54, 19);
            this.metroLabel4.TabIndex = 23;
            this.metroLabel4.Text = "Начало";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(23, 279);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(47, 19);
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "Конец";
            // 
            // btnAddOccupant
            // 
            this.btnAddOccupant.Location = new System.Drawing.Point(349, 259);
            this.btnAddOccupant.Name = "btnAddOccupant";
            this.btnAddOccupant.Size = new System.Drawing.Size(192, 23);
            this.btnAddOccupant.TabIndex = 36;
            this.btnAddOccupant.Text = "Добавить проживающего";
            this.btnAddOccupant.UseSelectable = true;
            this.btnAddOccupant.Click += new System.EventHandler(this.btnAddOccupant_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(349, 317);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddOccupantWithDiscount
            // 
            this.btnAddOccupantWithDiscount.Location = new System.Drawing.Point(349, 288);
            this.btnAddOccupantWithDiscount.Name = "btnAddOccupantWithDiscount";
            this.btnAddOccupantWithDiscount.Size = new System.Drawing.Size(192, 23);
            this.btnAddOccupantWithDiscount.TabIndex = 34;
            this.btnAddOccupantWithDiscount.Text = "Добавить льготника";
            this.btnAddOccupantWithDiscount.UseSelectable = true;
            this.btnAddOccupantWithDiscount.Click += new System.EventHandler(this.btnAddOccupantWithDiscount_Click);
            // 
            // lstOccupants
            // 
            this.lstOccupants.FormattingEnabled = true;
            this.lstOccupants.Location = new System.Drawing.Point(349, 83);
            this.lstOccupants.Name = "lstOccupants";
            this.lstOccupants.Size = new System.Drawing.Size(192, 173);
            this.lstOccupants.TabIndex = 33;
            // 
            // chkUnlimitedLastDate
            // 
            this.chkUnlimitedLastDate.AutoSize = true;
            this.chkUnlimitedLastDate.Location = new System.Drawing.Point(23, 354);
            this.chkUnlimitedLastDate.Name = "chkUnlimitedLastDate";
            this.chkUnlimitedLastDate.Size = new System.Drawing.Size(83, 15);
            this.chkUnlimitedLastDate.TabIndex = 38;
            this.chkUnlimitedLastDate.Text = "Бессрочно";
            this.chkUnlimitedLastDate.UseSelectable = true;
            // 
            // DiscountAccountItemForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 456);
            this.Controls.Add(this.chkUnlimitedLastDate);
            this.Controls.Add(this.btnAddOccupant);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddOccupantWithDiscount);
            this.Controls.Add(this.lstOccupants);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbPercent);
            this.Controls.Add(this.txtAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountAccountItemForm";
            this.Resizable = false;
            this.Text = "Льгота на счет";
            this.Load += new System.EventHandler(this.DiscountAccountItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtAccount;
        private MetroFramework.Controls.MetroComboBox cmbPercent;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroComboBox cmbDescription;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dateTo;
        private MetroFramework.Controls.MetroDateTime dateFrom;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnAddOccupant;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnAddOccupantWithDiscount;
        private System.Windows.Forms.ListBox lstOccupants;
        private MetroFramework.Controls.MetroCheckBox chkUnlimitedLastDate;
    }
}