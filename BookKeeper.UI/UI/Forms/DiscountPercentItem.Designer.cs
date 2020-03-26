namespace BookKeeper.UI.UI.Forms
{
    partial class DiscountPercentItem
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
            this.txtDiscountPercent = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtDiscountPercent
            // 
            // 
            // 
            // 
            this.txtDiscountPercent.CustomButton.Image = null;
            this.txtDiscountPercent.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.txtDiscountPercent.CustomButton.Name = "";
            this.txtDiscountPercent.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDiscountPercent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDiscountPercent.CustomButton.TabIndex = 1;
            this.txtDiscountPercent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDiscountPercent.CustomButton.UseSelectable = true;
            this.txtDiscountPercent.CustomButton.Visible = false;
            this.txtDiscountPercent.Lines = new string[0];
            this.txtDiscountPercent.Location = new System.Drawing.Point(23, 85);
            this.txtDiscountPercent.MaxLength = 32767;
            this.txtDiscountPercent.Name = "txtDiscountPercent";
            this.txtDiscountPercent.PasswordChar = '\0';
            this.txtDiscountPercent.PromptText = "Скидка в процентах";
            this.txtDiscountPercent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiscountPercent.SelectedText = "";
            this.txtDiscountPercent.SelectionLength = 0;
            this.txtDiscountPercent.SelectionStart = 0;
            this.txtDiscountPercent.ShortcutsEnabled = true;
            this.txtDiscountPercent.Size = new System.Drawing.Size(175, 23);
            this.txtDiscountPercent.TabIndex = 0;
            this.txtDiscountPercent.UseSelectable = true;
            this.txtDiscountPercent.WaterMark = "Скидка в процентах";
            this.txtDiscountPercent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDiscountPercent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(123, 130);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Сохранить";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(23, 130);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Отменить";
            this.metroButton2.UseSelectable = true;
            // 
            // DiscountPercentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 198);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtDiscountPercent);
            this.Movable = false;
            this.Name = "DiscountPercentItem";
            this.Resizable = false;
            this.Text = "Процентная ставка";
            this.Load += new System.EventHandler(this.DiscountAndDescriptionItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtDiscountPercent;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}