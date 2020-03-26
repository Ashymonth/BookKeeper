using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Discount;
using MetroFramework.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountDescriptionItem : MetroForm
    {
        private readonly IContainer _container;

        public DiscountDescriptionItem()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Описание не может быть пустм");
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IDiscountDescriptionService>();
                service.AddDescription(txtDescription.Text);
            }
            LoadItems();
        }

        private void DiscountDescriptionItem_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var descriptionService = scope.Resolve<IDiscountDescriptionService>();
                var descriptions = descriptionService.GetItems(x => x.IsDeleted == false);

                lstDescription.DataSource = descriptions.ToList();
                lstDescription.DisplayMember = "Description";
                lstDescription.ValueMember = "Id";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstDescription.SelectedItem is DiscountDescriptionEntity entity)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var descriptionService = scope.Resolve<IDiscountDescriptionService>();
                    var result = descriptionService.GetItemById(entity.Id);
                    if (result != null)
                    {
                        descriptionService.Delete(result);
                        LoadItems();
                    }
                }
            }
        }
    }
}
