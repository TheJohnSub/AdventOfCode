namespace Day2.Tests
{
    public class NumberRangeTests
    {
        [Test]
        public void IsMirroredString_1234567_False()
        {
            var response = NumberRange.IsMirroredString("1234567");
            Assert.That(response, Is.False);
        }

        [Test]
        public void IsMirroredString_1234_False()
        {
            var response = NumberRange.IsMirroredString("1234");
            Assert.That(response, Is.False );
        }

        [Test]
        public void IsMirroredString_1010_True()
        {
            var response = NumberRange.IsMirroredString("1010");
            Assert.That(response, Is.True);
        }

        [Test]
        public void IsRepeatingString_111_True()
        {
            var response = NumberRange.IsRepeatingString("111");
            Assert.That(response, Is.True);
        }

        [Test]
        public void IsRepeatingString_100_False()
        {
            var response = NumberRange.IsRepeatingString("100");
            Assert.That(response, Is.False);
        }

        [Test]
        public void IsRepeatingString_1112_False()
        {
            var response = NumberRange.IsRepeatingString("1112");
            Assert.That(response, Is.False);
        }

        [Test]
        public void IsRepeatingString_824824824_True()
        {
            var response = NumberRange.IsRepeatingString("824824824");
            Assert.That(response, Is.True);
        }

        [Test]
        public void IsRepeatingString_79799_False()
        {
            var response = NumberRange.IsRepeatingString("79799");
            Assert.That(response, Is.False);
        }

        [Test]
        public void IsRepeatingString_3_False()
        {
            var response = NumberRange.IsRepeatingString("3");
            Assert.That(response, Is.False);
        }

        [Test]
        public void NumberRange_11And22_InvalidIdSumIs33()
        {
            var numberRange = new NumberRange(11, 22);
            Assert.That(numberRange.InvalidSum, Is.EqualTo(33));
        }

        [Test]
        public void NumberRange_446443And446449_InvalidIdSumIs446446()
        {
            var numberRange = new NumberRange(446443, 446449);
            Assert.That(numberRange.InvalidSum, Is.EqualTo(446446));
        }
    }
}
