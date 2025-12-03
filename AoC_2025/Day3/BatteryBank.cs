namespace Day3
{
    public class BatteryBank
    {

        private int NumDigits = 2;
        private List<int> LineNumbers;
        private List<int> Digits = new List<int>();

        public BatteryBank(string line, int numDigits = 2)
        {
            NumDigits = numDigits;

            var numbers = line
                .Select(c => int.Parse(c.ToString()))
                .ToList();
            LineNumbers = numbers;

            for (int i = 1; i <= NumDigits; i++) 
            {
                TurnOnDigit(i);
            }
        }

        public void TurnOnDigit(int digitPlace)
        {
            var digitsToRemove = NumDigits - digitPlace;
            var localNumbers = LineNumbers.ToList();
            localNumbers.RemoveRange(localNumbers.Count - digitsToRemove, digitsToRemove);

            var digit = localNumbers.Max();
            Digits.Add(digit);

            LineNumbers.RemoveRange(0, LineNumbers.IndexOf(digit) + 1);
        }

        public long Joltage
        {
            get 
            {
                var joltageString = String.Join("", Digits.Select(d => d.ToString()).ToList());
                return long.Parse(joltageString);
            }
        }
    }
}
