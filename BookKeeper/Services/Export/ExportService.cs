using BookKeeper.Data.Infrastructure.Formats;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BookKeeper.Data.Services.Export
{
    public class ExportService
    {
        public static void ExportTotalReportToExcel(ListView listView, string file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            if (string.IsNullOrWhiteSpace(file))
                throw new FileNotFoundException(nameof(file));

            if (listView == null)
                throw new ArgumentException(nameof(listView));

            file = ExcelFormatValidator.ValidateFormat(file);


            var dt = new DataTable();
            dt.Columns.AddRange(new[]
              { new DataColumn("Адрес", typeof(string)),
                new DataColumn("Начислено муниципально", typeof(string)),
                new DataColumn("Начислено част",typeof(string)),
                new DataColumn("Поступило муниципально",typeof(string)),
                new DataColumn("Поступило част",typeof(string)),
                new DataColumn("Всего поступило",typeof(string)),
                new DataColumn("Всего начислено",typeof(string)),
                new DataColumn("%",typeof(string)),
              });

            foreach (ListViewItem listViewItem in listView.Items)
            {
                var list = new List<string>();
                foreach (ListViewItem.ListViewSubItem listViewSubItem in listViewItem.SubItems)
                {
                    list.Add(listViewSubItem.Text);
                }

                try
                {
                    dt.Rows.Add(list.ToArray());
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            using (var workBook = new XLWorkbook())
            {
                workBook.Worksheets.Add(dt, "Отчет");
                workBook.SaveAs(file);
            }
        }
    }
}