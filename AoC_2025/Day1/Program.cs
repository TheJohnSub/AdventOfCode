// See https://aka.ms/new-console-template for more information
using Day1;

//List<string> lines = File.ReadLines("C:\\Project\\AoC_2025\\Day1\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines("C:\\Project\\AoC_2025\\Day1\\Input\\Round1Input.txt").ToList();

var game = new Day1Game(lines);
Console.WriteLine($"Password: {game.Password.ToString()}");
