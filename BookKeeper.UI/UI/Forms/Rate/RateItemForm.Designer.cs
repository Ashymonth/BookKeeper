namespace BookKeeper.UI.UI.Forms.Rate
{
    partial class RateItemForm
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
            this.cmbStreet = new MetroFramework.Controls.MetroComboBox();
            this.txtHouse = new MetroFramework.Controls.MetroTextBox();
            this.txtBuilding = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.dateFrom = new MetroFramework.Controls.MetroDateTime();
            this.dateTo = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // cmbStreet
            // 
            this.cmbStreet.DisplayMember = "StreetName";
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.ItemHeight = 23;
            this.cmbStreet.Location = new System.Drawing.Point(31, 78);
            this.cmbStreet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.PromptText = "Адрес";
            this.cmbStreet.Size = new System.Drawing.Size(588, 29);
            this.cmbStreet.TabIndex = 0;
            this.cmbStreet.UseSelectable = true;
            this.cmbStreet.ValueMember = "Id";
            // 
            // txtHouse
            // 
            // 
            // 
            // 
            this.txtHouse.CustomButton.Image = null;
            this.txtHouse.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.txtHouse.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHouse.CustomButton.Name = "";
            this.txtHouse.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.txtHouse.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHouse.CustomButton.TabIndex = 1;
            this.txtHouse.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHouse.CustomButton.UseSelectable = true;
            this.txtHouse.CustomButton.Visible = false;
            this.txtHouse.Lines = new string[0];
            this.txtHouse.Location = new System.Drawing.Point(31, 143);
            this.txtHouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHouse.MaxLength = 32767;
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.PasswordChar = '\0';
            this.txtHouse.PromptText = "Дом";
            this.txtHouse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHouse.SelectedText = "";
            this.txtHouse.SelectionLength = 0;
            this.txtHouse.SelectionStart = 0;
            this.txtHouse.ShortcutsEnabled = true;
            this.txtHouse.Size = new System.Drawing.Size(161, 25);
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
            this.txtBuilding.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.txtBuilding.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuilding.CustomButton.Name = "";
            this.txtBuilding.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.txtBuilding.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBuilding.CustomButton.TabIndex = 1;
            this.txtBuilding.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBuilding.CustomButton.UseSelectable = true;
            this.txtBuilding.CustomButton.Visible = false;
            this.txtBuilding.Lines = new string[0];
            this.txtBuilding.Location = new System.Drawing.Point(31, 199);
            this.txtBuilding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuilding.MaxLength = 32767;
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.PasswordChar = '\0';
            this.txtBuilding.PromptText = "Корпус";
            this.txtBuilding.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuilding.SelectedText = "";
            this.txtBuilding.SelectionLength = 0;
            this.txtBuilding.SelectionStart = 0;
            this.txtBuilding.ShortcutsEnabled = true;
            this.txtBuilding.Size = new System.Drawing.Size(161, 25);
            this.txtBuilding.TabIndex = 2;
            this.txtBuilding.UseSelectable = true;
            this.txtBuilding.WaterMark = "Корпус";
            this.txtBuilding.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBuilding.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(687, 1);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(97, 90);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(31, 305);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PromptText = "Описание";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(589, 75);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMark = "Описание";
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(459, 405);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Сохранить";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(31, 407);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(31, 247);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Mask = "000.00";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(160, 22);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.ValidatingType = typeof(int);
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMMM yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(353, 143);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(265, 29);
            this.dateFrom.TabIndex = 9;
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MMMM yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(353, 239);
            this.dateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(265, 29);
            this.dateTo.TabIndex = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(273, 143);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Начало";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(273, 251);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Конец";
            // 
            // RateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.txtHouse);
            this.Controls.Add(this.cmbStreet);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RateItemForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Тариф";
            this.Load += new System.EventHandler(this.RateItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbStreet;
        private MetroFramework.Controls.MetroTextBox txtHouse;
        private MetroFramework.Controls.MetroTextBox txtBuilding;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private MetroFramework.Controls.MetroDateTime dateFrom;
        private MetroFramework.Controls.MetroDateTime dateTo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}