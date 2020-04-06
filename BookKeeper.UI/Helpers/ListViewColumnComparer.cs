using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookKeeper.UI.Helpers
{
    public class ListViewColumnComparer : Comparer<ListViewItem>
    {
        private readonly int _column;

        public ListViewColumnComparer()
        {
            _column = 0;
        }

        public ListViewColumnComparer(int column)
        {
            _column = column;
        }

        public override int Compare(ListViewItem x, ListViewItem y)
        {

            return string.CompareOrdinal(x?.SubItems[_column].Text, y?.SubItems[_column].Text);
        }
    }
}