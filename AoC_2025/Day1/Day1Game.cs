namespace Day1
{
    public class Day1Game
    {
        List<Tuple<Direction, int>> Rotations;
        GateLock GateLock;
        public int Password;
        public Day1Game(List<string> lines)
        {
            Rotations = lines.Select(l => ParseLineToRotation(l)).ToList();
            GateLock = new GateLock();

            foreach (var rotation in Rotations)
            {
                GateLock.Rotate(rotation.Item1, rotation.Item2);
            }

            Password = GateLock.ZeroCount;
            Console.WriteLine($"Current Position: {GateLock.CurrentPosition.ToString()}");
        }

        private Tuple<Direction, int> ParseLineToRotation(string line) 
        {
            var direction = line.Substring(0, 1) == "L"
                ? Direction.Left 
                : Direction.Right;

            var numberOfClicksStr = line.Substring(1).Trim();
            return Tuple.Create(direction, int.Parse(numberOfClicksStr));  
        }
    }
}
