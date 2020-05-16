using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace BookKeeper.Data.Services.Export
{
    public interface IExportService
    {
        void ExportReport(ListView listView, string file);
    }

    public class ExportService : IExportService
    {
        public void ExportReport(ListView listView, string file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            if (string.IsNullOrWhiteSpace(file))
                throw new FileNotFoundException(nameof(file));

            if (listView == null)
                throw new ArgumentException(nameof(listView));


            var dt = new DataTable();
            foreach (ColumnHeader headers in listView.Columns)
            {
                dt.Columns.Add(new DataColumn(headers.Text, typeof(string)));
            }
            foreach (ListViewItem listViewItem in listView.Items)
            {
                var list = new List<string>();
                foreach (ListViewItem.ListViewSubItem listViewSubItem in listViewItem.SubItems)
                {
                    list.Add(listViewSubItem.Text);
                }

                dt.Rows.Add(list.ToArray());

            }

            using (var workBook = new XLWorkbook())
            {
                workBook.Worksheets.Add(dt, "Отчет");
                var extension = Path.GetExtension(file);
                workBook.SaveAs(string.IsNullOrEmpty(extension) ? $"{file}.xlsx" : file);
            }
        }
    }
}