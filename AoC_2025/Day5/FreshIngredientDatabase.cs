namespace Day5
{
    public class FreshIngredientDatabase
    {
        private List<Tuple<long, long>> _ranges = new List<Tuple<long, long>>();
        public FreshIngredientDatabase(List<string> lines) 
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var numbers = line.Split('-').Select(s => long.Parse(s)).ToList();
                var range = new Tuple<long, long>(numbers[0], numbers[1]);
                var overlapping = GetOverlappingPair(range);
                while (overlapping != null) 
                {
                    if (MustSplitInputRange(range, overlapping))
                    {
                        var newRange = SplitInputRangeOnHighEnd(range, overlapping);
                        lines.Add($"{newRange.Item1.ToString()}-{newRange.Item2.ToString()}");
                    }
                    range = AdjustRangeToOverlapping(range, overlapping);
                    if (range == null)
                    {
                        break;
                    }
                    overlapping = GetOverlappingPair(range);
                }
                if (range != null)
                {
                    _ranges.Add(range);
                }
            }

            _ranges = _ranges.OrderBy(r => r.Item1).ToList();
        }

        public Tuple<long, long>? GetOverlappingPair(Tuple<long, long> input)
        {
            return _ranges.Find(p => 
                (input.Item1 <= p.Item1 && input.Item2 >= p.Item1) ||
                (input.Item1 <= p.Item2 && input.Item2 >= p.Item2) ||
                (input.Item1 >= p.Item1 && input.Item2 <= p.Item2));
        }

        public Tuple<long, long> SplitInputRangeOnHighEnd(Tuple<long, long> input, Tuple<long, long> overlapping)
        {
            return new Tuple<long, long>(overlapping.Item2 + 1, input.Item2);
        }

        public bool MustSplitInputRange(Tuple<long, long> input, Tuple<long, long> overlapping)
        {
            return input.Item1 <= overlapping.Item1 && input.Item2 >= overlapping.Item2;
        }

        public static Tuple<long, long>? AdjustRangeToOverlapping(Tuple<long, long> input, Tuple<long, long> overlapping)
        {
            var start = 0L;
            var end = 0L;

            if (input.Item1 <= overlapping.Item1 && input.Item2 >= overlapping.Item1)
            {
                start = input.Item1;
                end = overlapping.Item1 - 1;
            }
            else if (input.Item1 <= overlapping.Item2 && input.Item2 >= overlapping.Item2)
            {
                start = overlapping.Item2 + 1;
                end = input.Item2;
            }
            else if (input.Item1 >= overlapping.Item1 && input.Item2 <= overlapping.Item2)
            {
                return null;
            }
            return new Tuple<long, long>(start, end);
        }

        public bool IsFreshIngredient(string id)
        {
            var number = long.Parse(id);

            foreach (var pair in _ranges)
            {
                if (pair.Item1 > number)
                {
                    return false;
                }
                //In range
                if (number >= pair.Item1 && number <= pair.Item2)
                {
                    return true;
                }
            }

            return false;
        }

        public long FreshIngredientCount
        {
            get 
            {
                var freshIngredientCount = 0L;
                foreach (var pair in _ranges)
                {
                    freshIngredientCount += (pair.Item2 - pair.Item1) + 1; 
                }
                return freshIngredientCount;
            }
        }
    }
}
