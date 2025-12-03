namespace Day1
{
    public class GateLock
    {
        public int CurrentPosition = 50;
        public int ZeroCount = 0;
        public void Rotate(Direction direction, int numberOfClicks) 
        {
            if (numberOfClicks >= 100)
            {
                ZeroCount += numberOfClicks / 100;
                numberOfClicks = numberOfClicks % 100;
            }

            var newPosition = direction == Direction.Left 
                ? CurrentPosition - numberOfClicks 
                : CurrentPosition + numberOfClicks;

            var passedZero = false;

            if (newPosition < 0 || newPosition > 99)
            {
                newPosition = newPosition < 0
                    ? 100 - Math.Abs(newPosition)
                    : newPosition - 100;

                if (CurrentPosition != 0)
                {
                    passedZero = true;
                    ZeroCount++;
                }
            }

            CurrentPosition = newPosition;
            if (CurrentPosition == 0 && !passedZero)
            {
                ZeroCount++;
            }
        }
    }
}
