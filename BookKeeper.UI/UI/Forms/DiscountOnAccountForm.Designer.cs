namespace BookKeeper.UI.UI.Forms
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
            this.txtAccount = new MetroFramework.Controls.MetroTextBox();
            this.cboPercent = new MetroFramework.Controls.MetroComboBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.cboDescription = new MetroFramework.Controls.MetroComboBox();
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
            this.cboPercent.Size = new System.Drawing.Size(285, 29);
            this.cboPercent.TabIndex = 1;
            this.cboPercent.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(233, 249);
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
            this.cboDescription.Size = new System.Drawing.Size(285, 29);
            this.cboDescription.TabIndex = 4;
            this.cboDescription.UseSelectable = true;
            // 
            // DiscountAccountItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 295);
            this.Controls.Add(this.cboDescription);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboPercent);
            this.Controls.Add(this.txtAccount);
            this.Name = "DiscountAccountItemForm";
            this.Resizable = false;
            this.Text = "Льгота на счет";
            this.Load += new System.EventHandler(this.DiscountAccountItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtAccount;
        private MetroFramework.Controls.MetroComboBox cboPercent;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroComboBox cboDescription;
    }
}