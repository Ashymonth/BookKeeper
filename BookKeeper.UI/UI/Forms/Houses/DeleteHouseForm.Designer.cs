namespace BookKeeper.UI.UI.Forms.Houses
{
    partial class DeleteHouseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteHouseForm));
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.cmbStreets = new MetroFramework.Controls.MetroComboBox();
            this.cmbHouses = new MetroFramework.Controls.MetroComboBox();
            this.cmbBuildings = new MetroFramework.Controls.MetroComboBox();
            this.cmbApartmens = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(24, 280);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 22);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseSelectable = true;
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.Location = new System.Drawing.Point(222, 280);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 22);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbStreets
            // 
            this.cmbStreets.FormattingEnabled = true;
            this.cmbStreets.ItemHeight = 23;
            this.cmbStreets.Location = new System.Drawing.Point(24, 64);
            this.cmbStreets.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStreets.Name = "cmbStreets";
            this.cmbStreets.PromptText = "Улица";
            this.cmbStreets.Size = new System.Drawing.Size(293, 29);
            this.cmbStreets.TabIndex = 9;
            this.cmbStreets.UseSelectable = true;
            this.cmbStreets.SelectedIndexChanged += new System.EventHandler(this.cmbStreets_SelectedIndexChanged);
            // 
            // cmbHouses
            // 
            this.cmbHouses.FormattingEnabled = true;
            this.cmbHouses.ItemHeight = 23;
            this.cmbHouses.Location = new System.Drawing.Point(24, 117);
            this.cmbHouses.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHouses.Name = "cmbHouses";
            this.cmbHouses.PromptText = "Дом";
            this.cmbHouses.Size = new System.Drawing.Size(293, 29);
            this.cmbHouses.TabIndex = 15;
            this.cmbHouses.UseSelectable = true;
            this.cmbHouses.SelectionChangeCommitted += new System.EventHandler(this.cmbHouses_SelectionChangeCommitted);
            // 
            // cmbBuildings
            // 
            this.cmbBuildings.FormattingEnabled = true;
            this.cmbBuildings.ItemHeight = 23;
            this.cmbBuildings.Location = new System.Drawing.Point(24, 170);
            this.cmbBuildings.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBuildings.Name = "cmbBuildings";
            this.cmbBuildings.PromptText = "Корпус";
            this.cmbBuildings.Size = new System.Drawing.Size(293, 29);
            this.cmbBuildings.TabIndex = 16;
            this.cmbBuildings.UseSelectable = true;
            this.cmbBuildings.DropDown += new System.EventHandler(this.cmbBuildings_DropDown);
            // 
            // cmbApartmens
            // 
            this.cmbApartmens.FormattingEnabled = true;
            this.cmbApartmens.ItemHeight = 23;
            this.cmbApartmens.Location = new System.Drawing.Point(24, 223);
            this.cmbApartmens.Margin = new System.Windows.Forms.Padding(4);
            this.cmbApartmens.Name = "cmbApartmens";
            this.cmbApartmens.PromptText = "Квартира";
            this.cmbApartmens.Size = new System.Drawing.Size(293, 29);
            this.cmbApartmens.TabIndex = 17;
            this.cmbApartmens.UseSelectable = true;
            // 
            // DeleteHouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 319);
            this.Controls.Add(this.cmbApartmens);
            this.Controls.Add(this.cmbBuildings);
            this.Controls.Add(this.cmbHouses);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbStreets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteHouseForm";
            this.Resizable = false;
            this.Text = "Удалить дом";
            this.Load += new System.EventHandler(this.DeleteHouseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroComboBox cmbStreets;
        private MetroFramework.Controls.MetroComboBox cmbHouses;
        private MetroFramework.Controls.MetroComboBox cmbBuildings;
        private MetroFramework.Controls.MetroComboBox cmbApartmens;
    }
}