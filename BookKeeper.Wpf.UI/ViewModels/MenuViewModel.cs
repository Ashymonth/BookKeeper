using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.Load;
using BookKeeper.Wpf.UI.Infrastructure;
using BookKeeper.Wpf.UI.Services;

namespace BookKeeper.Wpf.UI.ViewModels
{
    public class MenuViewModel : ObservableObject
    {
        private readonly IContainer _container;


        private readonly IDialogService _dialogService;

        private RelayCommand _openFileCommand;


        public MenuViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _container = AutofacConfiguration.ConfigureContainer();
        }

        public RelayCommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ?? (_openFileCommand = new RelayCommand(obj =>
                {
                    if (_dialogService.OpenFileDialog())
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var service = scope.ResolveNamed<IDataLoader>(LoaderType.Excel.ToString());
                            var result = service.LoadData(_dialogService.FilePath);
                        }
                    }
                }));
            }
        }

        private void OnLoadDataBaseCommandExecute(object files)
        {

        }
    }
}