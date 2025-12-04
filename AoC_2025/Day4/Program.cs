using Day4;

//List<string> lines = File.ReadLines("C:\\Users\\John Subtirelu\\Documents\\GitHub\\AdventOfCode\\AoC_2025\\Day4\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines("C:\\Users\\John Subtirelu\\Documents\\GitHub\\AdventOfCode\\AoC_2025\\Day4\\Input\\Round1Input.txt").ToList();

//List<string> lines = File.ReadLines("C:\\Project\\AoC_2025\\Day4\\Input\\Round1Input.txt").ToList();

var grid = new Grid(lines);

var lastRolls = grid.TakeAccessibleRolls();
var totalRolls = lastRolls;

while (lastRolls > 0)
{
    lastRolls = grid.TakeAccessibleRolls();
    totalRolls += lastRolls;
}

Console.WriteLine(Environment.CurrentDirectory);
Console.WriteLine($"Accessible Rolls: {totalRolls}");
