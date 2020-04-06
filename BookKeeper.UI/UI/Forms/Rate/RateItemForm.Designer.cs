﻿namespace BookKeeper.UI.UI.Forms.Rate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateItemForm));
            this.cmbStreet = new MetroFramework.Controls.MetroComboBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.cmbHouses = new MetroFramework.Controls.MetroComboBox();
            this.cmbBuildings = new MetroFramework.Controls.MetroComboBox();
            this.txtPrice = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // cmbStreet
            // 
            this.cmbStreet.DisplayMember = "StreetName";
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.ItemHeight = 23;
            this.cmbStreet.Location = new System.Drawing.Point(31, 78);
            this.cmbStreet.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.PromptText = "Адрес";
            this.cmbStreet.Size = new System.Drawing.Size(588, 29);
            this.cmbStreet.TabIndex = 0;
            this.cmbStreet.UseSelectable = true;
            this.cmbStreet.ValueMember = "Id";
            this.cmbStreet.SelectedIndexChanged += new System.EventHandler(this.cmbStreet_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(515, 1);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(73, 73);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(30, 183);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
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
            this.txtDescription.TabIndex = 4;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMark = "Описание";
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(435, 283);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(184, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(30, 285);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbHouses
            // 
            this.cmbHouses.DisplayMember = "StreetName";
            this.cmbHouses.FormattingEnabled = true;
            this.cmbHouses.ItemHeight = 23;
            this.cmbHouses.Location = new System.Drawing.Point(30, 136);
            this.cmbHouses.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHouses.Name = "cmbHouses";
            this.cmbHouses.PromptText = "Дом";
            this.cmbHouses.Size = new System.Drawing.Size(184, 29);
            this.cmbHouses.TabIndex = 1;
            this.cmbHouses.UseSelectable = true;
            this.cmbHouses.ValueMember = "Id";
            this.cmbHouses.SelectionChangeCommitted += new System.EventHandler(this.cmbHouses_SelectionChangeCommitted);
            // 
            // cmbBuildings
            // 
            this.cmbBuildings.DisplayMember = "StreetName";
            this.cmbBuildings.FormattingEnabled = true;
            this.cmbBuildings.ItemHeight = 23;
            this.cmbBuildings.Location = new System.Drawing.Point(232, 136);
            this.cmbBuildings.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBuildings.Name = "cmbBuildings";
            this.cmbBuildings.PromptText = "Корпус";
            this.cmbBuildings.Size = new System.Drawing.Size(184, 29);
            this.cmbBuildings.TabIndex = 2;
            this.cmbBuildings.UseSelectable = true;
            this.cmbBuildings.ValueMember = "Id";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.CustomButton.Image = null;
            this.txtPrice.CustomButton.Location = new System.Drawing.Point(156, 1);
            this.txtPrice.CustomButton.Name = "";
            this.txtPrice.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrice.CustomButton.TabIndex = 1;
            this.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrice.CustomButton.UseSelectable = true;
            this.txtPrice.CustomButton.Visible = false;
            this.txtPrice.Lines = new string[0];
            this.txtPrice.Location = new System.Drawing.Point(434, 136);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.PromptText = "Цена";
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.ShortcutsEnabled = true;
            this.txtPrice.Size = new System.Drawing.Size(184, 29);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.UseSelectable = true;
            this.txtPrice.WaterMark = "Цена";
            this.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // RateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 355);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbBuildings);
            this.Controls.Add(this.cmbHouses);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbStreet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RateItemForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Тариф";
            this.Load += new System.EventHandler(this.RateItemForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbStreet;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroComboBox cmbHouses;
        private MetroFramework.Controls.MetroComboBox cmbBuildings;
        private MetroFramework.Controls.MetroTextBox txtPrice;
    }
}