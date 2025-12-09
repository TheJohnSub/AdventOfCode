using Day7;

//List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\Round1Input.txt").ToList();

DiagramLine? prevDiagramLine = null;
var diagramLines = new List<DiagramLine>();
foreach (var line in lines)
{
    var newDiagramLine = new DiagramLine(line, prevDiagramLine);
    diagramLines.Add(newDiagramLine);
    prevDiagramLine = newDiagramLine;
}

var totalSplittersThatCausedSplits = diagramLines.Sum(d => d.Spaces.Count(d => d.CausedSplit));
var linePossibilities = diagramLines.Select(l => l.Spaces.Sum(s => s.Possibility));

Console.WriteLine($"Splits: {totalSplittersThatCausedSplits.ToString()}");
Console.WriteLine($"Paths: {linePossibilities.Last().ToString()}");

