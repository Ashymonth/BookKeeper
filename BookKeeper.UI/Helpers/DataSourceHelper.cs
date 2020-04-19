using BookKeeper.Data.Data.Entities.Address;
using MetroFramework.Controls;
using System;
using System.Linq;
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;

namespace BookKeeper.UI.Helpers
{
    public class DataSourceHelper
    {
        private readonly IContainer _container;

        public DataSourceHelper()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        public void StreetIndexChanged(MetroComboBox streetBox, MetroComboBox houseBox, Func<LocationEntity, string> selectedItem)
        {
            houseBox.DataSource = null;

            if (!(streetBox.SelectedItem is StreetEntity selectedStreet))
                return;

            houseBox.DataSource = selectedStreet.Locations
                .Where(x => x.IsDeleted == false)
                .Prepend(new LocationEntity(){HouseNumber = houseBox.PromptText})
                .Select(selectedItem)
                .Distinct()
                .ToList();
        }

        public void HouseIndexChanged(MetroComboBox streetBox, MetroComboBox houseBox, MetroComboBox buildingBox, Func<LocationEntity, string> selectedItem)
        {
            buildingBox.DataSource = null;

            var selectedStreet = streetBox.SelectedItem as StreetEntity;
            if (selectedStreet == null)
                return;
            
            var house = houseBox.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(house))
                return;
            

            buildingBox.DataSource = selectedStreet.Locations
                .Where(x => x.IsDeleted == false && string.Equals(x.HouseNumber, house, StringComparison.OrdinalIgnoreCase))
                .Prepend(new LocationEntity() { BuildingCorpus = buildingBox.PromptText })
                .Select(selectedItem)
                .Distinct()
                .ToList();
            
        }

        public void BuildingIndexChanged(MetroComboBox streetBox, MetroComboBox houseBox, MetroComboBox buildingBox, 
            MetroComboBox apartmentBox, Func<LocationEntity, string> selectedItem)
        {
            apartmentBox.DataSource = null;

            var selectedStreet = streetBox.SelectedItem as StreetEntity;
            if (selectedStreet == null)
                return;

            var selectedHouse = houseBox.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(selectedHouse))
                return;

            var selectedBuilding = buildingBox.SelectedItem as string;

            apartmentBox.DataSource = selectedStreet.Locations
                .Where(x => x.IsDeleted == false &&
                            string.Equals(x.HouseNumber, selectedHouse, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(x.BuildingCorpus, selectedBuilding, StringComparison.OrdinalIgnoreCase))
                .Prepend(new LocationEntity() {ApartmentNumber = apartmentBox.PromptText})
                .Select(selectedItem)
                .Distinct()
                .ToList();
        }

        public void LoadAddresses(MetroComboBox addressBox)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IStreetService>();

                var streets = service.GetWithInclude(x => x.IsDeleted == false,x=>x.Locations).ToList();
                addressBox.DataSource = streets;
                addressBox.DisplayMember = "StreetName";
                addressBox.ValueMember = "Id";
            }
        }

        public void LoadDiscountsPercent(MetroComboBox percentBox)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IDiscountPercentService>();

                var percents = service.GetItems(x => x.IsDeleted == false).OrderBy(x => x.Percent).ToList();
                percentBox.DataSource = percents;
                percentBox.DisplayMember = "Percent";
                percentBox.ValueMember = "Percent";
            }
        }

        public void LoadDiscountsDescription(MetroComboBox descriptionBox)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IDiscountDescriptionService>();

                var descriptions = service.GetItems(x => x.IsDeleted == false).ToList();
                descriptionBox.DataSource = descriptions;
                descriptionBox.DisplayMember = "Description";
                descriptionBox.ValueMember = "Description";
            }
        }
    }
}