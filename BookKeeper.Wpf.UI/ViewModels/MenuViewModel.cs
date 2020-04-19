using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookKeeper.Wpf.UI.Infrastructure;
using BookKeeper.Wpf.UI.Services;

namespace BookKeeper.Wpf.UI.ViewModels
{
    public class MenuViewModel
    {
        private readonly IFileService<string> _fileService;
        
        private readonly IDialogService _dialogService;
        
        private readonly ICommand _loadDataBase;

        private RelayCommand _saveCommand;
        
        private RelayCommand _openCommand;

        public MenuViewModel(IFileService<string> fileService, IDialogService dialogService)
        {
            _fileService = fileService;
            _dialogService = dialogService;
            _loadDataBase = new RelayCommand(OnLoadDataBaseCommandExecute);
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (_dialogService.SaveFileDialog())
                        {
                            _fileService.Save(_dialogService.FilePath, null);
                        }
                    }
                    catch (Exception e)
                    {
                        //
                    }
                }));
            }
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                       (_openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               if (_dialogService.OpenFileDialog())
                               {
                                   _fileService.Open(_dialogService.FilePath);
                               }
                           }
                           catch (Exception)
                           {
                               //
                           }
                       }));
            }
        }

        public void OnLoadDataBaseCommandExecute(object files)
        {
            files = files as IEnumerable<string>;

            if(files == null)
                throw new ArgumentNullException(nameof(files));

            if (_dialogService.OpenFileDialog())
            {

            }

        }
    }
}
