using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using BookKeeper.Data.Data.Entities.Discounts;

namespace BookKeeper.UI.Helpers
{

    public class ListViewStringComparer : IComparer
    {
        private readonly int _col;
        private readonly SortOrder _order;
        public ListViewStringComparer()
        {
            _col = 0;
            _order = SortOrder.Ascending;
        }

        public ListViewStringComparer(int column, SortOrder order)
        {
            _col = column;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            var returnVal = -1;
            returnVal = string.CompareOrdinal(((ListViewItem)x)?.SubItems[_col].Text, ((ListViewItem)y)?.SubItems[_col].Text);
            if (_order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }

    public class ListViewDateComparer : IComparer
    {
        private readonly int _column;
        private readonly SortOrder _order;
        public ListViewDateComparer()
        {
            _column = 0;
            _order = SortOrder.Ascending;
        }

        public ListViewDateComparer(int column, SortOrder order)
        {
            _column = column;
            _order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal;
            try
            {
                var firstDate = DateTime.Parse(((ListViewItem)x)?.SubItems[_column].Text);
                var secondDate = DateTime.Parse(((ListViewItem)y)?.SubItems[_column].Text);

                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            catch
            {
                returnVal = string.CompareOrdinal(((ListViewItem)x)?.SubItems[_column].Text, ((ListViewItem)y)?.SubItems[_column].Text);
            }

            if (_order == SortOrder.Descending)
                returnVal *= -1;

            return returnVal;

        }
    }
}