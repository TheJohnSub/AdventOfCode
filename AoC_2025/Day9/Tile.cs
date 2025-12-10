namespace Day9
{
    public class Tile
    {
        public long Row;
        public long Column;
        public Tile(long row, long column)
        {
            Row = row;
            Column = column;
        }

        public long CalculateAreaBetweenTiles(Tile otherTiles)
        {
            var side1 = Math.Abs(Row - otherTiles.Row) + 1;
            var side2 = Math.Abs(Column - otherTiles.Column) + 1;
            return side1 * side2;
        }

    }
}
