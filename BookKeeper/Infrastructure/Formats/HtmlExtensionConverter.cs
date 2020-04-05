using System;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public static class HtmlExtensionConverter
    {
        private const string TempFolder = "TempFolder";

        /// <summary>
        /// Большинство документов имеют .htm расширение, его нужно заменять на .html
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ConvertToHtml(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));

            if (!Path.GetExtension(file).Equals(".htm", StringComparison.OrdinalIgnoreCase))
                return file;

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), TempFolder)))
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), TempFolder));


            var newFile = $"{Path.GetFileNameWithoutExtension(file)}.html";


            File.Copy(Path.GetFullPath(file), Path.Combine(Directory.GetCurrentDirectory(), TempFolder, newFile), true);

            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), TempFolder, newFile)))
                throw new FileNotFoundException(nameof(newFile));

            return Path.GetFullPath(newFile);


        }
    }
}
