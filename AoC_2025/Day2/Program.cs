using Day2;

//string input = File.ReadAllText("C:\\Project\\AoC_2025\\Day2\\Input\\SampleInput.txt");
string input = File.ReadAllText("C:\\Project\\AoC_2025\\Day2\\Input\\Round1Input.txt");

var stringRanges = input.Split(',');
var numberRanges = new List<NumberRange>();

foreach (var range in stringRanges)
{
    var splitRange = range
        .Split("-")
        .Select(s => long.Parse(s.Trim()))
        .ToArray();
    numberRanges.Add(new NumberRange(splitRange[0], splitRange[1]));
}

var totalSum = numberRanges.Sum(r => r.InvalidSum);

Console.WriteLine($"Total sum of invalid IDs: {totalSum}");