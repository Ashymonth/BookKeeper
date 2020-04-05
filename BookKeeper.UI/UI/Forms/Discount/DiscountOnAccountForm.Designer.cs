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
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.cmbDescription = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
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
            this.txtAccount.CustomButton.Location = new System.Drawing.Point(352, 1);
            this.txtAccount.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAccount.CustomButton.Name = "";
            this.txtAccount.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtAccount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccount.CustomButton.TabIndex = 1;
            this.txtAccount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccount.CustomButton.UseSelectable = true;
            this.txtAccount.CustomButton.Visible = false;
            this.txtAccount.Lines = new string[0];
            this.txtAccount.Location = new System.Drawing.Point(31, 102);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAccount.MaxLength = 32767;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.PasswordChar = '\0';
            this.txtAccount.PromptText = "Номер счета";
            this.txtAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccount.SelectedText = "";
            this.txtAccount.SelectionLength = 0;
            this.txtAccount.SelectionStart = 0;
            this.txtAccount.ShortcutsEnabled = true;
            this.txtAccount.Size = new System.Drawing.Size(380, 29);
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
            this.cmbPercent.Location = new System.Drawing.Point(31, 168);
            this.cmbPercent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPercent.Name = "cmbPercent";
            this.cmbPercent.PromptText = "Процент скидки";
            this.cmbPercent.Size = new System.Drawing.Size(379, 29);
            this.cmbPercent.TabIndex = 1;
            this.cmbPercent.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(310, 286);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButton2.Location = new System.Drawing.Point(31, 286);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(100, 28);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Отменить";
            this.metroButton2.UseSelectable = true;
            // 
            // cmbDescription
            // 
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.ItemHeight = 23;
            this.cmbDescription.Location = new System.Drawing.Point(31, 234);
            this.cmbDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.PromptText = "Описание";
            this.cmbDescription.Size = new System.Drawing.Size(379, 29);
            this.cmbDescription.TabIndex = 4;
            this.cmbDescription.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(31, 206);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Описание";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 140);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Скидка";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 74);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(37, 19);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Счет";
            // 
            // DiscountAccountItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 337);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbPercent);
            this.Controls.Add(this.txtAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountAccountItemForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
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
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroComboBox cmbDescription;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}