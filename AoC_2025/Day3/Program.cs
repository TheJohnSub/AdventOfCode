using Day3;

//List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\SampleInput.txt").ToList();
List<string> lines = File.ReadLines(Directory.GetCurrentDirectory() + "\\Input\\Round1Input.txt").ToList();

var batteryBanks = new List<BatteryBank>();
foreach (var line in lines)
{
    batteryBanks.Add(new BatteryBank(line, 12));
}

var totalJoltage = batteryBanks.Sum(b => b.Joltage);
Console.WriteLine($"Total Joltage: {totalJoltage}");
