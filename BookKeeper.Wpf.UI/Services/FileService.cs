using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Wpf.UI.Services
{
    public interface IFileService
    {
        void Open(string fileName);

    }

    public class FileService : IFileService
    {
        public void Open(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}