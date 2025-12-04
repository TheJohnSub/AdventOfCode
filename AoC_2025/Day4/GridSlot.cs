using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class GridSlot
    {
        public bool IsPaper = false;
        public int Column;
        public int Row;
        public int AdjacentPaper = 0;

        public GridSlot(char type, int column, int row) 
        {
            IsPaper = type == '@';
            Column = column; 
            Row = row;
        }
    }
}
