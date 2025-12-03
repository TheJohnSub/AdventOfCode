using System.Data;

namespace Day2
{
    public class NumberRange
    {
        private List<long> Range = new List<long>();
        private List<long> InvalidIds = new List<long>();
        public NumberRange(long beginning, long end) 
        {
            for (long x = 0; beginning + x <= end; x++)
            {
                Range.Add(beginning + x);
            }

            InvalidIds = Range
                .Where(x => IsMirroredString(x.ToString()) || IsRepeatingString(x.ToString()))
                .ToList();
        }

        public long InvalidSum
        {
            get { return InvalidIds.Sum(x => x); }
        }

        public static bool IsMirroredString(string id)
        {
            if (id.Length % 2 != 0)
            {
                return false;
            }

            var middleIndex = id.Length / 2;

            var string1 = id.Substring(0, middleIndex);
            var string2 = id.Substring(middleIndex);

            return string1.Equals(string2);
        }

        public static bool IsRepeatingString(string id)
        {
            if (id.Length <= 1)
            {
                return false;
            }

            var isRepeating = true;
            var repeatedSubstring = id.Substring(0, 1);
            var index = 1;

            while (index < id.Length)
            {
                if (index + repeatedSubstring.Length > id.Length)
                {
                    isRepeating = false;
                    break;
                }

                var compareString = id.Substring(index, repeatedSubstring.Length);
                if (!compareString.Equals(repeatedSubstring)) 
                {
                    isRepeating = false;
                    repeatedSubstring = id.Substring(0, index + 1);
                    index++;
                }
                else
                {
                    isRepeating = true;
                    index += repeatedSubstring.Length;
                }
            }

            return isRepeating;
        }
    }
}
