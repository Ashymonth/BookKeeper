using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Wpf.UI.Services
{
    public interface IFileService<TFileType>
    {
        List<TFileType> Open(string fileName);

        bool Save(string fileName, List<TFileType> list);
    }

    public class FileService
    {
    }
}
