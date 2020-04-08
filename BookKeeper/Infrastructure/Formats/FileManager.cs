using System;
using System.IO;
using System.Linq;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public abstract class FileManager
    {
        protected const string TempFolder = "TempFolder";

        public static void DeleteTempFolder()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), TempFolder);

            if (Directory.Exists(folder))
            {
                var files = Directory.GetFiles(folder);
                if (files.Any())
                {
                    try
                    {
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }
                    }
                    catch (Exception)
                    {
                        //
                    }
                }
            }
        }
    }
}
