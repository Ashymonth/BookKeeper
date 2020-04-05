namespace BookKeeper.UI.UI.Forms.Discount
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
            this.SuspendLayout();
            // 
            // btnSaveDiscount
            // 
            this.btnSaveDiscount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveDiscount.Location = new System.Drawing.Point(433, 389);
            this.btnSaveDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveDiscount.Name = "btnSaveDiscount";
            this.btnSaveDiscount.Size = new System.Drawing.Size(161, 28);
            this.btnSaveDiscount.TabIndex = 11;
            this.btnSaveDiscount.Text = "Сохранить";
            this.btnSaveDiscount.UseSelectable = true;
            this.btnSaveDiscount.Click += new System.EventHandler(this.btnSaveDiscount_Click);
            // 
            // dtnCancelDiscount
            // 
            this.dtnCancelDiscount.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dtnCancelDiscount.Location = new System.Drawing.Point(31, 389);
            this.dtnCancelDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.dtnCancelDiscount.Name = "dtnCancelDiscount";
            this.dtnCancelDiscount.Size = new System.Drawing.Size(160, 28);
            this.dtnCancelDiscount.TabIndex = 12;
            this.dtnCancelDiscount.Text = "Отменить";
            this.dtnCancelDiscount.UseSelectable = true;
            // 
            // cmbStreets
            // 
            this.cmbStreets.FormattingEnabled = true;
            this.cmbStreets.ItemHeight = 23;
            this.cmbStreets.Location = new System.Drawing.Point(31, 92);
            this.cmbStreets.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStreets.Name = "cmbStreets";
            this.cmbStreets.PromptText = "Адрес";
            this.cmbStreets.Size = new System.Drawing.Size(563, 29);
            this.cmbStreets.TabIndex = 1;
            this.cmbStreets.UseSelectable = true;
            this.cmbStreets.SelectedIndexChanged += new System.EventHandler(this.cmbStreets_SelectedIndexChanged);
            // 
            // cmbPercent
            // 
            this.cmbPercent.FormattingEnabled = true;
            this.cmbPercent.ItemHeight = 23;
            this.cmbPercent.Location = new System.Drawing.Point(353, 168);
            this.cmbPercent.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPercent.Name = "cmbPercent";
            this.cmbPercent.PromptText = "Скидка";
            this.cmbPercent.Size = new System.Drawing.Size(241, 29);
            this.cmbPercent.TabIndex = 5;
            this.cmbPercent.UseSelectable = true;
            // 
            // cmbDescription
            // 
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.ItemHeight = 23;
            this.cmbDescription.Location = new System.Drawing.Point(353, 236);
            this.cmbDescription.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.PromptText = "Описание";
            this.cmbDescription.Size = new System.Drawing.Size(241, 29);
            this.cmbDescription.TabIndex = 9;
            this.cmbDescription.UseSelectable = true;
            // 
            // Адрес
            // 
            this.Адрес.AutoSize = true;
            this.Адрес.Location = new System.Drawing.Point(31, 65);
            this.Адрес.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Адрес.Name = "Адрес";
            this.Адрес.Size = new System.Drawing.Size(46, 19);
            this.Адрес.TabIndex = 0;
            this.Адрес.Text = "Адрес";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(353, 145);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Скидка";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(353, 213);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Описание";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 292);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 17;
            this.metroLabel1.Text = "Квартира";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(31, 213);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 15;
            this.metroLabel4.Text = "Корпус";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(31, 141);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(35, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Дом";
            // 
            // cmbApatmens
            // 
            this.cmbApatmens.FormattingEnabled = true;
            this.cmbApatmens.ItemHeight = 23;
            this.cmbApatmens.Location = new System.Drawing.Point(31, 314);
            this.cmbApatmens.Margin = new System.Windows.Forms.Padding(4);
            this.cmbApatmens.Name = "cmbApatmens";
            this.cmbApatmens.PromptText = "Квартира";
            this.cmbApatmens.Size = new System.Drawing.Size(241, 29);
            this.cmbApatmens.TabIndex = 18;
            this.cmbApatmens.UseSelectable = true;
            // 
            // cmbBuilding
            // 
            this.cmbBuilding.FormattingEnabled = true;
            this.cmbBuilding.ItemHeight = 23;
            this.cmbBuilding.Location = new System.Drawing.Point(31, 241);
            this.cmbBuilding.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBuilding.Name = "cmbBuilding";
            this.cmbBuilding.PromptText = "Корпус";
            this.cmbBuilding.Size = new System.Drawing.Size(241, 29);
            this.cmbBuilding.TabIndex = 16;
            this.cmbBuilding.UseSelectable = true;
            this.cmbBuilding.SelectedIndexChanged += new System.EventHandler(this.cmbBuilding_SelectedIndexChanged);
            // 
            // cmbHouses
            // 
            this.cmbHouses.FormattingEnabled = true;
            this.cmbHouses.ItemHeight = 23;
            this.cmbHouses.Location = new System.Drawing.Point(31, 168);
            this.cmbHouses.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHouses.Name = "cmbHouses";
            this.cmbHouses.PromptText = "Дом";
            this.cmbHouses.Size = new System.Drawing.Size(241, 29);
            this.cmbHouses.TabIndex = 14;
            this.cmbHouses.UseSelectable = true;
            this.cmbHouses.SelectedIndexChanged += new System.EventHandler(this.cmbHouses_SelectedIndexChanged);
            // 
            // DiscountOnAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 469);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountOnAddressForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Text = "Льгота на адрес";
            this.Load += new System.EventHandler(this.DiscountOnAddressForm_Load);
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
    }
}