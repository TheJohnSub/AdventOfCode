namespace Day9
{
    public class FloorGrid
    {
        private List<Tuple<Tile, Tile>> _redTilePairs = new List<Tuple<Tile, Tile>>();
        private Dictionary<long, List<Tuple<long, long>>> _horizontalSegments = new Dictionary<long, List<Tuple<long, long>>>();
        private Dictionary<long, List<Tuple<long, long>>> _verticalSegments = new Dictionary<long, List<Tuple<long, long>>>();
        private long _maxColumn = 0;
        private long _maxRow = 0;

        public FloorGrid(List<string> lines)
        {
            InitializeRedTilePairsAndTileSegments(lines);
        }

        private void AddSegmentBetweenTiles(Tile tile1, Tile tile2)
        {
            if (tile1.Row == tile2.Row)
            {
                //add horizontal segment
                if (!_horizontalSegments.ContainsKey(tile1.Row))
                {
                    _horizontalSegments[tile1.Row] = new List<Tuple<long, long>>();
                }
                _horizontalSegments[tile1.Row]
                    .Add(new Tuple<long, long>(Math.Min(tile1.Column, tile2.Column), Math.Max(tile1.Column, tile2.Column)));
            }
            else if (tile1.Column == tile2.Column)
            {
                //add vertical segment
                if (!_verticalSegments.ContainsKey(tile1.Column))
                {
                    _verticalSegments[tile1.Column] = new List<Tuple<long, long>>();
                }
                _verticalSegments[tile1.Column]
                    .Add(new Tuple<long, long>(Math.Min(tile1.Row, tile2.Row), Math.Max(tile1.Row, tile2.Row)));
            }
        }

        private void InitializeRedTilePairsAndTileSegments(List<string> lines)
        {
            var redTiles = new Tile[ lines.Count ];
            Tile? prevTile = null;

            for (int i = 0; i < lines.Count; i++)
            {
                //create tile from line text
                var values = lines[i].Split(",").Select(val => long.Parse(val)).ToList();
                var column = values[0];
                var row = values[1];
                var tile = new Tile(row, column);
                redTiles[i] = tile;

                _maxColumn = Math.Max(tile.Column, _maxColumn);
                _maxRow = Math.Max(tile.Row, _maxRow);

                if (prevTile is not null)
                {
                    AddSegmentBetweenTiles(prevTile, tile);
                    if (i == lines.Count - 1)
                    {
                        //wrap last tile to first
                        AddSegmentBetweenTiles(tile, redTiles[0]);
                    }
                }
                prevTile = tile;

                //generate pairings
                for (int k = i - 1; k >= 0; k--)
                {
                    var oldTile = redTiles[k];
                    _redTilePairs.Add(new Tuple<Tile, Tile>(oldTile, tile));
                }
            }
            _redTilePairs = _redTilePairs
                .OrderBy(bp => bp.Item1.CalculateAreaBetweenTiles(bp.Item2)).ToList();
        }


        public long LargestAreaCreatedByRedTilePair
        {
            get 
            { 
                var pair = _redTilePairs.Last();
                return pair.Item1.CalculateAreaBetweenTiles(pair.Item2);
            }
        }

        public long LargestCompletelyFilledAreaCreatedByRedTilePair 
        { 
            get 
            {
                for (int i = _redTilePairs.Count - 1; i >= 0; i--)
                {
                    var pair = _redTilePairs[i];
                    if (IsAreaCompletelyFilled(pair))
                    {
                        return pair.Item1.CalculateAreaBetweenTiles(pair.Item2);
                    }
                }
                return 0; 
            } 
        }

        public bool IsAreaCompletelyFilled(Tuple<Tile, Tile> tilePair)
        {
            var verticalBorderStart = Math.Min(tilePair.Item1.Row, tilePair.Item2.Row);
            var verticalBorderEnd = Math.Max(tilePair.Item1.Row, tilePair.Item2.Row);

            ////check if fully contained in a vertical segment on left
            var leftBorderColumnIndex = Math.Min(tilePair.Item1.Column, tilePair.Item2.Column);
            if (!IsBorderComplete(_verticalSegments, verticalBorderStart, verticalBorderEnd, leftBorderColumnIndex, 0, -1))
            {
                return false;
            }

            ////check if fully contained in a vertical segment on right
            var rightBorderColumnIndex = Math.Max(tilePair.Item1.Column, tilePair.Item2.Column);
            if (!IsBorderComplete(_verticalSegments, verticalBorderStart, verticalBorderEnd, rightBorderColumnIndex, _maxColumn, 1))
            {
                return false;
            }

            var horizontalBorderStart = Math.Min(tilePair.Item1.Column, tilePair.Item2.Column);
            var horizontalBorderEnd = Math.Max(tilePair.Item1.Column, tilePair.Item2.Column);

            //check if fully contained in a horizontal segment on top
            var topBorderRowIndex = Math.Min(tilePair.Item1.Row, tilePair.Item2.Row);
            if (!IsBorderComplete(_horizontalSegments, horizontalBorderStart, horizontalBorderEnd, topBorderRowIndex, 0, -1))
            {
                return false;
            }

            //check if fully contained in a horizontal segment on bottom
            var bottomBorderIndex = Math.Max(tilePair.Item1.Row, tilePair.Item2.Row);
            if (!IsBorderComplete(_horizontalSegments, horizontalBorderStart, horizontalBorderEnd, bottomBorderIndex, _maxRow, 1))
            {
                return false;
            }
            return true; 
        }

        private static bool IsBorderComplete(Dictionary<long, List<Tuple<long, long>>> segments, long borderStart, long borderEnd, long index, long stopIndex, int step)
        {
            var isBorderComplete = false;
            var borderSegments = new List<Tuple<long, long>>();
            while (!isBorderComplete)
            {
                if (segments.ContainsKey(index))
                {
                    var segmentsAtIndex = segments[index]
                        .Where(s =>
                        (s.Item1 <= borderStart && s.Item2 >= borderEnd) || //segment fully encompasses expected border
                        (s.Item1 >= borderStart && s.Item1 <= borderEnd) || //start of segment is in expected borderStart -> expected borderEnd
                        (s.Item2 >= borderStart && s.Item2 <= borderEnd))  //end of segment is in expected borderStart -> expected borderEnd
                        .ToList();
                    borderSegments.AddRange(segmentsAtIndex);

                    isBorderComplete = AreSegmentsConsecutive(borderSegments) &&
                        borderSegments.Min(b => b.Item1) <= borderStart && 
                        borderSegments.Max(b => b.Item2) >= borderEnd;
                }
                if (index == stopIndex && !isBorderComplete)
                {
                    return false;
                }
                index += step;
            }
            return true;
        }

        public static bool AreSegmentsConsecutive(List<Tuple<long, long>> segments)
        {
            if (!segments.Any())
            {
                return false;
            }
            var orderedSegments = segments.OrderBy(s => s.Item1).ToList();
            long? nextStart = null;
            foreach ( var segment in orderedSegments )
            {
                if ( nextStart is not null )
                {
                    if (segment.Item1 > nextStart)
                    {
                        return false;
                    }
                }
                nextStart = segment.Item2 + 1;
            }
            return true;
        }
    }
}
