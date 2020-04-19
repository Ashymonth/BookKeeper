using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BookKeeper.Wpf.UI.Services
{
    public interface IDialogService
    {
        string FilePath { get; set; }

        bool OpenFileDialog();

        bool SaveFileDialog();
    }

    public class DialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Excel files(*.xls;*.xls)|*.xlsx;*xlsx|All files(*.*)|*.*", Multiselect = true
            };

            if (openFileDialog.ShowDialog() != true)
                return false;

            FilePath = openFileDialog.FileName;
            return true;

        }

        public bool SaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != true)
                return false;

            FilePath = saveFileDialog.FileName;
            return true;
        }
    }
}