namespace Day4
{
    public class Grid
    {
        public GridSlot[,] GridSlots;
        private int ColumnCount;
        private int RowCount;
        public Grid(List<string> lines) 
        {
            RowCount = lines.Count;
            ColumnCount = lines[0].Length;

            GridSlots = new GridSlot[RowCount, ColumnCount];

            for (int row = 0; row < lines.Count; row++)
            {
                var line = lines[row];
                var charArray = line.ToCharArray();
                for (int column = 0; column < charArray.Length; column++)
                {
                    var slot = new GridSlot(charArray[column], column, row);
                    if (slot.IsPaper)
                    {
                        slot.AdjacentPaper += GetHitsAgainst(slot);
                        IncrementHitsBeforeSlot(slot);
                    }
                    GridSlots[row, column] = slot;
                }
            }
        }

        private void ReevaluateGrid()
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    var slot = GridSlots[row, column];
                    slot.AdjacentPaper = 0;
                    if (slot.IsPaper)
                    {
                        slot.AdjacentPaper += GetHitsAgainst(slot);
                        IncrementHitsBeforeSlot(slot);
                    }
                }
            }
        }

        public int TakeAccessibleRolls()
        {
            var count = 0;
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    var slot = GridSlots[row, column];
                    if (slot.IsPaper & slot.AdjacentPaper < 4)
                    {
                        count++;
                        slot.IsPaper = false;
                    }
                }
            }
            ReevaluateGrid(); 
            return count;
        }

        public void IncrementHitsBeforeSlot(GridSlot slot)
        {
            //hits in same row
            if (slot.Column > 0)
            {
                //Left
                GridSlots[slot.Row, slot.Column - 1].AdjacentPaper++; 
            }

            //hits in row below
            if (slot.Row > 0)
            {
                //Lower Left
                if (slot.Column > 0)
                {
                    GridSlots[slot.Row - 1, slot.Column - 1].AdjacentPaper++;
                }

                //Lower Middle
                GridSlots[slot.Row - 1, slot.Column].AdjacentPaper++;

                //Lower Right
                if (slot.Column < ColumnCount - 1)
                {
                    GridSlots[slot.Row - 1, slot.Column + 1].AdjacentPaper++;
                }
            }
        }

        public int GetHitsAgainst(GridSlot slot)
        {
            var hits = 0;

            //hits in same row
            if (slot.Column > 0)
            {
                //Left
                hits += GetHitCount(slot.Row, slot.Column - 1);
            }

            //hits in row above
            if (slot.Row > 0)
            {
                //Upper Left
                if (slot.Column > 0)
                {
                    hits += GetHitCount(slot.Row - 1, slot.Column - 1);
                }

                //Upper Middle
                hits += GetHitCount(slot.Row - 1, slot.Column);

                //Upper Right
                if (slot.Column < ColumnCount - 1)
                {
                    hits += GetHitCount(slot.Row - 1, slot.Column + 1);
                }
            }

            return hits;
        }

        private int GetHitCount(int row, int column)
        {
            return GridSlots[row, column].IsPaper ? 1 : 0;
        }
    }
}
