using Day8;

//List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\Round1Input.txt").ToList();

var boxPairs = new List<Tuple<JunctionBox, JunctionBox>>();
var junctionBoxes = new JunctionBox[lines.Count];
for (int i = 0; i < lines.Count; i++)
{
    var values = lines[i].Split(",").Select(val => int.Parse(val)).ToList();
    var newJunctionBox = new JunctionBox(values[0], values[1], values[2]);
    junctionBoxes[i] = newJunctionBox;
    for (int k = i - 1; k >= 0; k--)
    {
        var oldJunctionBox = junctionBoxes[k];
        boxPairs.Add(new Tuple<JunctionBox, JunctionBox>(oldJunctionBox, newJunctionBox));
    }
}

var circuits = new List<JunctionBox>[500];
var orderedBoxPairs = boxPairs
    .OrderBy(bp => bp.Item1.CalculateDistanceToOtherJunctionBox(bp.Item2))
    .ToArray();

var circuitCount = 0;
var index = 0;
var connectedCircuits = 0;
var activeCircuits = 0;
Tuple<JunctionBox, JunctionBox> lastPair = null;

while(connectedCircuits < junctionBoxes.Length || activeCircuits > 1)
{
    var pair = orderedBoxPairs[index];
    index++;
    var circuitContainingBoth = Array.FindIndex(circuits, c => c is not null && c.Contains(pair.Item1) && c.Contains(pair.Item2));
    if (circuitContainingBoth >= 0)
    {
        continue;
    }

    var item1Index = Array.FindIndex(circuits, c => c is not null && c.Contains(pair.Item1));
    var item2Index = Array.FindIndex(circuits, c => c is not null && c.Contains(pair.Item2));
    if (item1Index >= 0 && item2Index >= 0)
    {
        circuits[item1Index].AddRange(circuits[item2Index]);
        circuits[item2Index] = null;
    }
    else if (item1Index >= 0)
    {
        circuits[item1Index].Add(pair.Item2);
        connectedCircuits++;

    }
    else if (item2Index >= 0)
    {
        circuits[item2Index].Add(pair.Item1);
        connectedCircuits++;
    }
    else
    {
        circuits[circuitCount] = new List<JunctionBox> { pair.Item1, pair.Item2 };
        circuitCount++;
        connectedCircuits += 2;
    }
    if (connectedCircuits >= junctionBoxes.Length - 1)
    {
        lastPair = pair;
    }
    activeCircuits = circuits.Where(c => c is not null).Count();
}

var closestPair = orderedBoxPairs.FirstOrDefault();

//var top3Circuits = circuits.Where(c => c is not null).OrderByDescending(c => c.Count).Take(3).ToArray();
//var multipliedTogether = top3Circuits[0].Count * top3Circuits[1].Count * top3Circuits[2].Count; 

Console.WriteLine($"CLOSEST PAIR");
Console.WriteLine($"1: {closestPair.Item1.X.ToString()}, {closestPair.Item1.Y.ToString()}, {closestPair.Item1.Z.ToString()}");
Console.WriteLine($"2: {closestPair.Item2.X.ToString()}, {closestPair.Item2.Y.ToString()}, {closestPair.Item2.Z.ToString()}");

Console.WriteLine($"LAST CONNECTED PAIR");
Console.WriteLine($"1: {lastPair.Item1.X.ToString()}, {lastPair.Item1.Y.ToString()}, {lastPair.Item1.Z.ToString()}");
Console.WriteLine($"2: {lastPair.Item2.X.ToString()}, {lastPair.Item2.Y.ToString()}, {lastPair.Item2.Z.ToString()}");

var product = Math.BigMul(lastPair.Item1.X, lastPair.Item2.X);
Console.WriteLine($"X Product: {product.ToString()}");


//Console.WriteLine("Circuit Count:" + circuitCount.ToString());
//Console.WriteLine("Circuit 1 Box Count:" + top3Circuits[0].Count.ToString());
//Console.WriteLine("Circuit 2 Box Count:" + top3Circuits[1].Count.ToString());
//Console.WriteLine("Circuit 3 Box Count:" + top3Circuits[2].Count.ToString());
//Console.WriteLine("Product of Circuit Sizes:" + multipliedTogether.ToString());