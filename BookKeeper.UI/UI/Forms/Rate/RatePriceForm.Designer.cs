namespace BookKeeper.UI.UI.Forms.Rate
{
    partial class RatePriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatePriceForm));
            this.btnChange = new MetroFramework.Controls.MetroButton();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChange.Location = new System.Drawing.Point(17, 114);
            this.btnChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(278, 27);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseSelectable = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(17, 72);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrice.Mask = "000.00";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(278, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // RatePriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 171);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnChange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RatePriceForm";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.Resizable = false;
            this.Text = "Новая цена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnChange;
        private System.Windows.Forms.MaskedTextBox txtPrice;
    }
}