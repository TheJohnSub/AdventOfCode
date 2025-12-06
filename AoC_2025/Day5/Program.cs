using Day5;

List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\SampleInput.txt").ToList();
//List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\Round1Input.txt").ToList();

var ranges = lines.Where(l => l.Contains("-")).ToList();
//var ids = lines.Where(l => l.Length > 0 && !l.Contains("-")).ToList();

var database = new FreshIngredientDatabase(ranges);
var freshIngredientCount = database.FreshIngredientCount;

Console.WriteLine($"Fresh Ingredients: {freshIngredientCount.ToString()}");
