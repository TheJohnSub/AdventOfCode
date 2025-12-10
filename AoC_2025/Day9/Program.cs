using Day9;

//List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\Round1Input.txt").ToList();


var grid = new FloorGrid(lines);
Console.WriteLine(grid.LargestCompletelyFilledAreaCreatedByRedTilePair.ToString());
