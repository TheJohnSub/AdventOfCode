namespace Day3.Tests
{
    public class Tests
    {
        [Test]
        public void BatteryBank_918_JoltageIs98()
        {
            var batteryBank = new BatteryBank("918");
            Assert.That(batteryBank.Joltage, Is.EqualTo(98));
        }

        [Test]
        public void BatteryBank_819_JoltageIs89()
        {
            var batteryBank = new BatteryBank("819");
            Assert.That(batteryBank.Joltage, Is.EqualTo(89));
        }

        [Test]
        public void BatteryBank_177_JoltageIs77()
        {
            var batteryBank = new BatteryBank("177");
            Assert.That(batteryBank.Joltage, Is.EqualTo(77));
        }

        [Test]
        public void BatteryBank_66821_JoltageIs82()
        {
            var batteryBank = new BatteryBank("66821");
            Assert.That(batteryBank.Joltage, Is.EqualTo(82));
        }

        [Test]
        public void BatteryBank_SampleInput_TotalJoltageIs357()
        {
            var batteryBanks = new List<BatteryBank>();
            var batteryBank1 = new BatteryBank("987654321111111");
            var batteryBank2 = new BatteryBank("811111111111119");
            var batteryBank3 = new BatteryBank("234234234234278");
            var batteryBank4 = new BatteryBank("818181911112111");

            batteryBanks.Add(batteryBank1);
            batteryBanks.Add(batteryBank2);
            batteryBanks.Add(batteryBank3);
            batteryBanks.Add(batteryBank4);

            Assert.That(batteryBank1.Joltage, Is.EqualTo(98));
            Assert.That(batteryBank2.Joltage, Is.EqualTo(89));
            Assert.That(batteryBank3.Joltage, Is.EqualTo(78));
            Assert.That(batteryBank4.Joltage, Is.EqualTo(92));

            var totalJoltage = batteryBanks.Sum(b => b.Joltage);
            Assert.That(totalJoltage, Is.EqualTo(357));
        }

        [Test]
        public void BatteryBank_SampleInputAnd12Digits_TotalJoltageIs357()
        {
            var batteryBanks = new List<BatteryBank>();
            var batteryBank1 = new BatteryBank("987654321111111", 12);
            var batteryBank2 = new BatteryBank("811111111111119", 12);
            var batteryBank3 = new BatteryBank("234234234234278", 12);
            var batteryBank4 = new BatteryBank("818181911112111", 12);

            batteryBanks.Add(batteryBank1);
            batteryBanks.Add(batteryBank2);
            batteryBanks.Add(batteryBank3);
            batteryBanks.Add(batteryBank4);

            Assert.That(batteryBank1.Joltage, Is.EqualTo(987654321111));
            Assert.That(batteryBank2.Joltage, Is.EqualTo(811111111119));
            Assert.That(batteryBank3.Joltage, Is.EqualTo(434234234278));
            Assert.That(batteryBank4.Joltage, Is.EqualTo(888911112111));

            var totalJoltage = batteryBanks.Sum(b => b.Joltage);
            Assert.That(totalJoltage, Is.EqualTo(3121910778619));
        }
    }
}
