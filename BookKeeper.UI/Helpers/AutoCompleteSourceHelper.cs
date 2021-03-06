﻿using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using MetroFramework.Controls;
using System.Linq;

namespace BookKeeper.UI.Helpers
{

    public class AutoCompleteSourceHelper
    {
        private readonly IContainer _container;

        public AutoCompleteSourceHelper()
        {
            _container = AutofacConfiguration.ConfigureContainer();
        }

        public void FillAutoSource(MetroTextBox textBox)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var accountService = scope.Resolve<IAccountService>();
                var accounts = accountService.GetItems(x => x.IsDeleted == false).Select(x => x.Account.ToString()).ToArray();
                textBox.AutoCompleteCustomSource.AddRange(accounts);
            }
        }
    }
}
