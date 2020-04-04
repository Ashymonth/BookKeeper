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
            this.cboPercent = new MetroFramework.Controls.MetroComboBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.cboDescription = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dateFrom = new MetroFramework.Controls.MetroDateTime();
            this.dateTo = new MetroFramework.Controls.MetroDateTime();
            this.Начало = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            // 
            // 
            // 
            this.txtAccount.CustomButton.Image = null;
            this.txtAccount.CustomButton.Location = new System.Drawing.Point(263, 1);
            this.txtAccount.CustomButton.Name = "";
            this.txtAccount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccount.CustomButton.TabIndex = 1;
            this.txtAccount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccount.CustomButton.UseSelectable = true;
            this.txtAccount.CustomButton.Visible = false;
            this.txtAccount.Lines = new string[0];
            this.txtAccount.Location = new System.Drawing.Point(23, 90);
            this.txtAccount.MaxLength = 32767;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.PasswordChar = '\0';
            this.txtAccount.PromptText = "Номер счета";
            this.txtAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccount.SelectedText = "";
            this.txtAccount.SelectionLength = 0;
            this.txtAccount.SelectionStart = 0;
            this.txtAccount.ShortcutsEnabled = true;
            this.txtAccount.Size = new System.Drawing.Size(285, 23);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.UseSelectable = true;
            this.txtAccount.WaterMark = "Номер счета";
            this.txtAccount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cboPercent
            // 
            this.cboPercent.FormattingEnabled = true;
            this.cboPercent.ItemHeight = 23;
            this.cboPercent.Location = new System.Drawing.Point(23, 137);
            this.cboPercent.Name = "cboPercent";
            this.cboPercent.PromptText = "Процент скидки";
            this.cboPercent.Size = new System.Drawing.Size(285, 29);
            this.cboPercent.TabIndex = 1;
            this.cboPercent.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(478, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButton2.Location = new System.Drawing.Point(23, 249);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Отменить";
            this.metroButton2.UseSelectable = true;
            // 
            // cboDescription
            // 
            this.cboDescription.FormattingEnabled = true;
            this.cboDescription.ItemHeight = 23;
            this.cboDescription.Location = new System.Drawing.Point(23, 193);
            this.cboDescription.Name = "cboDescription";
            this.cboDescription.PromptText = "Описание";
            this.cboDescription.Size = new System.Drawing.Size(285, 29);
            this.cboDescription.TabIndex = 4;
            this.cboDescription.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 171);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Описание";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 115);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Скидка";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMMM yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(353, 84);
            this.dateFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 29);
            this.dateFrom.TabIndex = 15;
            this.dateFrom.Value = new System.DateTime(2020, 1, 1, 22, 42, 0, 0);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MMMM yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(353, 142);
            this.dateTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 29);
            this.dateTo.TabIndex = 16;
            this.dateTo.Value = new System.DateTime(2020, 1, 1, 22, 42, 0, 0);
            // 
            // Начало
            // 
            this.Начало.AutoSize = true;
            this.Начало.Location = new System.Drawing.Point(353, 54);
            this.Начало.Name = "Начало";
            this.Начало.Size = new System.Drawing.Size(54, 19);
            this.Начало.TabIndex = 17;
            this.Начало.Text = "Начало";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(353, 120);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(47, 19);
            this.metroLabel4.TabIndex = 18;
            this.metroLabel4.Text = "Конец";
            // 
            // DiscountAccountItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 295);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.Начало);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cboDescription);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboPercent);
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
        private MetroFramework.Controls.MetroComboBox cboPercent;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroComboBox cboDescription;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dateFrom;
        private MetroFramework.Controls.MetroDateTime dateTo;
        private MetroFramework.Controls.MetroLabel Начало;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}