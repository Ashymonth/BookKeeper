namespace BookKeeper.UI.UI.Forms
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
            this.components = new System.ComponentModel.Container();
            this.cmbStreetName = new MetroFramework.Controls.MetroComboBox();
            this.txtHouseNumber = new MetroFramework.Controls.MetroTextBox();
            this.txtBuildingNumber = new MetroFramework.Controls.MetroTextBox();
            this.txtApartmentNumber = new MetroFramework.Controls.MetroTextBox();
            this.txtPrice = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.bookKeepingDataSet = new BookKeeper.UI.BookKeepingDataSet();
            this.streetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.streetsTableAdapter = new BookKeeper.UI.BookKeepingDataSetTableAdapters.StreetsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bookKeepingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStreetName
            // 
            this.cmbStreetName.DataSource = this.streetsBindingSource;
            this.cmbStreetName.DisplayMember = "StreetName";
            this.cmbStreetName.FormattingEnabled = true;
            this.cmbStreetName.ItemHeight = 23;
            this.cmbStreetName.Location = new System.Drawing.Point(135, 24);
            this.cmbStreetName.Name = "cmbStreetName";
            this.cmbStreetName.Size = new System.Drawing.Size(380, 29);
            this.cmbStreetName.TabIndex = 0;
            this.cmbStreetName.UseSelectable = true;
            this.cmbStreetName.ValueMember = "Id";
            // 
            // txtHouseNumber
            // 
            // 
            // 
            // 
            this.txtHouseNumber.CustomButton.Image = null;
            this.txtHouseNumber.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.txtHouseNumber.CustomButton.Name = "";
            this.txtHouseNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtHouseNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHouseNumber.CustomButton.TabIndex = 1;
            this.txtHouseNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHouseNumber.CustomButton.UseSelectable = true;
            this.txtHouseNumber.CustomButton.Visible = false;
            this.txtHouseNumber.Lines = new string[] {
        "Номер дома"};
            this.txtHouseNumber.Location = new System.Drawing.Point(3, 209);
            this.txtHouseNumber.MaxLength = 32767;
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.PasswordChar = '\0';
            this.txtHouseNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHouseNumber.SelectedText = "";
            this.txtHouseNumber.SelectionLength = 0;
            this.txtHouseNumber.SelectionStart = 0;
            this.txtHouseNumber.ShortcutsEnabled = true;
            this.txtHouseNumber.Size = new System.Drawing.Size(121, 23);
            this.txtHouseNumber.TabIndex = 1;
            this.txtHouseNumber.Text = "Номер дома";
            this.txtHouseNumber.UseSelectable = true;
            this.txtHouseNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHouseNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBuildingNumber
            // 
            // 
            // 
            // 
            this.txtBuildingNumber.CustomButton.Image = null;
            this.txtBuildingNumber.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.txtBuildingNumber.CustomButton.Name = "";
            this.txtBuildingNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBuildingNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBuildingNumber.CustomButton.TabIndex = 1;
            this.txtBuildingNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBuildingNumber.CustomButton.UseSelectable = true;
            this.txtBuildingNumber.CustomButton.Visible = false;
            this.txtBuildingNumber.Lines = new string[] {
        "Номер корпуса"};
            this.txtBuildingNumber.Location = new System.Drawing.Point(183, 209);
            this.txtBuildingNumber.MaxLength = 32767;
            this.txtBuildingNumber.Name = "txtBuildingNumber";
            this.txtBuildingNumber.PasswordChar = '\0';
            this.txtBuildingNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuildingNumber.SelectedText = "";
            this.txtBuildingNumber.SelectionLength = 0;
            this.txtBuildingNumber.SelectionStart = 0;
            this.txtBuildingNumber.ShortcutsEnabled = true;
            this.txtBuildingNumber.Size = new System.Drawing.Size(121, 23);
            this.txtBuildingNumber.TabIndex = 2;
            this.txtBuildingNumber.Text = "Номер корпуса";
            this.txtBuildingNumber.UseSelectable = true;
            this.txtBuildingNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBuildingNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtApartmentNumber
            // 
            // 
            // 
            // 
            this.txtApartmentNumber.CustomButton.Image = null;
            this.txtApartmentNumber.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.txtApartmentNumber.CustomButton.Name = "";
            this.txtApartmentNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtApartmentNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtApartmentNumber.CustomButton.TabIndex = 1;
            this.txtApartmentNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtApartmentNumber.CustomButton.UseSelectable = true;
            this.txtApartmentNumber.CustomButton.Visible = false;
            this.txtApartmentNumber.Lines = new string[] {
        "Номер квартиры"};
            this.txtApartmentNumber.Location = new System.Drawing.Point(353, 209);
            this.txtApartmentNumber.MaxLength = 32767;
            this.txtApartmentNumber.Name = "txtApartmentNumber";
            this.txtApartmentNumber.PasswordChar = '\0';
            this.txtApartmentNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtApartmentNumber.SelectedText = "";
            this.txtApartmentNumber.SelectionLength = 0;
            this.txtApartmentNumber.SelectionStart = 0;
            this.txtApartmentNumber.ShortcutsEnabled = true;
            this.txtApartmentNumber.Size = new System.Drawing.Size(121, 23);
            this.txtApartmentNumber.TabIndex = 3;
            this.txtApartmentNumber.Text = "Номер квартиры";
            this.txtApartmentNumber.UseSelectable = true;
            this.txtApartmentNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtApartmentNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.CustomButton.Image = null;
            this.txtPrice.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.txtPrice.CustomButton.Name = "";
            this.txtPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrice.CustomButton.TabIndex = 1;
            this.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrice.CustomButton.UseSelectable = true;
            this.txtPrice.CustomButton.Visible = false;
            this.txtPrice.Lines = new string[] {
        "Цена"};
            this.txtPrice.Location = new System.Drawing.Point(353, 310);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.ShortcutsEnabled = true;
            this.txtPrice.Size = new System.Drawing.Size(121, 23);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "Цена";
            this.txtPrice.UseSelectable = true;
            this.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[] {
        "Описание"};
            this.txtDescription.Location = new System.Drawing.Point(353, 261);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(121, 23);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "Описание";
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseSelectable = true;
            // 
            // bookKeepingDataSet
            // 
            this.bookKeepingDataSet.DataSetName = "BookKeepingDataSet";
            this.bookKeepingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // RateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtApartmentNumber);
            this.Controls.Add(this.txtBuildingNumber);
            this.Controls.Add(this.txtHouseNumber);
            this.Controls.Add(this.cmbStreetName);
            this.Name = "RateItemForm";
            this.Text = "Тарифы";
            this.Load += new System.EventHandler(this.RateItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookKeepingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbStreetName;
        private MetroFramework.Controls.MetroTextBox txtHouseNumber;
        private MetroFramework.Controls.MetroTextBox txtBuildingNumber;
        private MetroFramework.Controls.MetroTextBox txtApartmentNumber;
        private MetroFramework.Controls.MetroTextBox txtPrice;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private BookKeepingDataSet bookKeepingDataSet;
        private System.Windows.Forms.BindingSource streetsBindingSource;
        private BookKeepingDataSetTableAdapters.StreetsTableAdapter streetsTableAdapter;
    }
}