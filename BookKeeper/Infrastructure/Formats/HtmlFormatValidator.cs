using System;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Formats
{


    public static class HtmlFormatValidator
    {
        /// <summary>
        /// Большинство документов имеют .htm расширение, его нужно заменять на .html
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ValidateFormat(string file)
        {
            if (file == null)
            {
                return null;
            }

            try
            {
                if (!Path.GetExtension(file).Equals(".htm", StringComparison.OrdinalIgnoreCase))
                    return file;
                

                var newFile = $"{Path.GetFileNameWithoutExtension(file)}.html";

                File.Copy(file, newFile);
                return newFile;
            }
            catch (IOException)
            {
                return null;
            }
        }
    }
}
