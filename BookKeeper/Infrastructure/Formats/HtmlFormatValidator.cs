using System;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Formats
{
    public static class HtmlFormatValidator
    {
        private const string TempFolder = "TempFolder";

        /// <summary>
        /// Большинство документов имеют .htm расширение, его нужно заменять на .html
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ValidateFormat(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));

            if (!Path.GetExtension(file).Equals(".htm", StringComparison.OrdinalIgnoreCase))
                return file;

            if (!Directory.Exists(TempFolder))
                Directory.CreateDirectory(TempFolder);

            var newFile = $"{Path.GetFileNameWithoutExtension(file)}.html";

            File.Copy(file, Path.Combine(TempFolder, newFile), true);

            return newFile;
        }
    }
}
