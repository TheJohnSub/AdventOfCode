using Day6;

//List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\Round1Input.txt").ToList();


var sheet = new MathHomeworkSheet(lines);
var grandTotal = sheet.CalculateSheetGrandTotal(useCephalopodNumbers: true);

Console.WriteLine($"Grand Total: {grandTotal.ToString()}");
