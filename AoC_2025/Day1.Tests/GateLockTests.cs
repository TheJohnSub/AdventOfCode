namespace Day1.Tests
{
    public class GateLockTests
    {
        [Test]
        public void Rotate_Right1Click_CurrentPositionIs51()
        {
            var gateLock = new GateLock();
            gateLock.Rotate(Direction.Right, 1);
            Assert.That(gateLock.CurrentPosition, Is.EqualTo(51));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(0));
        }

        [Test]
        public void Rotate_Left1Click_CurrentPositionIs49()
        {
            var gateLock = new GateLock();
            gateLock.Rotate(Direction.Left, 1);
            Assert.That(gateLock.CurrentPosition, Is.EqualTo(49));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(0));
        }

        [Test]
        public void Rotate_Right50Clicks_CurrentPositionIsZero()
        {
            var gateLock = new GateLock();
            gateLock.Rotate(Direction.Right, 50);
            Assert.That(gateLock.CurrentPosition, Is.EqualTo(0));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(1));

        }

        [Test]
        public void Rotate_Left51Clicks_CurrentPositionIs99()
        {
            var gateLock = new GateLock();
            gateLock.Rotate(Direction.Left, 51);
            Assert.That(gateLock.CurrentPosition, Is.EqualTo(99));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(1));
        }

        [Test]
        public void Rotate_Left201Clicks_CurrentPositionIs49()
        {
            var gateLock = new GateLock();
            gateLock.Rotate(Direction.Left, 201);
            Assert.That(gateLock.CurrentPosition, Is.EqualTo(49));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(2));
        }

        [Test]
        public void Rotate_Right201Clicks_CurrentPositionIs51()
        {
            var gateLock = new GateLock();
            gateLock.Rotate(Direction.Right, 201);
            Assert.That(gateLock.CurrentPosition, Is.EqualTo(51));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(2));
        }

        [Test]
        public void Rotate_SampleGameInput_ZeroCountIs3()
        {
            var gateLock = new GateLock();

            gateLock.Rotate(Direction.Left, 68);   //L68
            gateLock.Rotate(Direction.Left, 30);   //L30
            gateLock.Rotate(Direction.Right, 48);  //R48
            gateLock.Rotate(Direction.Left, 5);    //L5
            gateLock.Rotate(Direction.Right, 60);  //R60
            gateLock.Rotate(Direction.Left, 55);   //L55
            gateLock.Rotate(Direction.Left, 1);    //L1
            gateLock.Rotate(Direction.Left, 99);   //L99
            gateLock.Rotate(Direction.Right, 14);  //R14
            gateLock.Rotate(Direction.Left, 82);   //L82

            Assert.That(gateLock.CurrentPosition, Is.EqualTo(32));
            Assert.That(gateLock.ZeroCount, Is.EqualTo(6));
        }
    }
}
