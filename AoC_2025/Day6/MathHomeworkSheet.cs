namespace Day6
{
    public class MathHomeworkSheet
    {
        private readonly List<string> _sheetText = new List<string>();
        private readonly int _colCount = 0;
        private readonly int[] _colWidths;
        public MathHomeworkSheet(List<string> sheetText) 
        {
            _sheetText = sheetText;
            _colCount = GetRowColumns(_sheetText.First() ?? "").Count;
            _colWidths = new int[_colCount];

            for (int i  = 0; i < _colCount; i++)
            {
                var maxWidth = 0;
                foreach(var line in _sheetText)
                {
                    var column = GetRowColumns(line)[i];
                    if (column.Length > maxWidth)
                    {
                        maxWidth = column.Length;
                    }
                }
                _colWidths[i] = maxWidth;
            }
        }

        private List<string> GetRowColumns(string line)
        {
            return line
                .Split(' ')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }


        public long CalculateSheetGrandTotal(bool useCephalopodNumbers = false)
        {
            var grandTotal = 0L;

            for (int i = 0; i < _colCount; i ++)
            {
                var problemStatement = new List<string>();
                foreach(var line in _sheetText)
                {
                    var row = GetPaddedRowColumns(line);
                    problemStatement.Add(row[i]);
                }
                var operation = problemStatement.Last().Trim();

                var numbers = useCephalopodNumbers
                    ? GetCephalopodNumbers(problemStatement) 
                    : problemStatement
                        .Where(s => !s.Contains(operation))
                        .Select(s => long.Parse(s))
                        .ToList();

                if (operation == "+")
                {
                    grandTotal += numbers.Sum(); 
                }
                else
                {
                    var problemTotal = 1L;
                    foreach (var number in numbers)
                    {
                        problemTotal *= number;
                    }
                    grandTotal += problemTotal;
                }

            }

            return grandTotal;
        }

        public static List<long> GetCephalopodNumbers(List<string> problem)
        {
            var justNumbers = problem
                    .Where(s => !s.Contains("+") && !s.Contains("*"))
                    .ToList();

            var highestCharCount = justNumbers.Max(s => s.Length);

            var numbers = new List<long>();
            for (int i = highestCharCount - 1; i >= 0; i--)
            {
                var numStr = "";
                foreach (var number in justNumbers)
                {
                    numStr += number[i];
                }
                numbers.Add(long.Parse(numStr.Trim()));
            }
            return numbers;
        }

        public List<string> GetPaddedRowColumns(string line)
        {
            var columns = new List<string>();
            var colStartIndex = 0;
            foreach (var col in _colWidths)
            {
                var column = line.Substring(colStartIndex, col);
                columns.Add(column);
                colStartIndex += column.Length + 1;
            }

            return columns;
        }
    }
}
