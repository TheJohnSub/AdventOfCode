namespace Day6.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateSheetGrandTotal_TwoThreeFourAdd_ReturnsSix()
        {
            var lines = new List<string> { "2", "3", "4", "+" };
            var sheet = new MathHomeworkSheet(lines);

            var result = sheet.CalculateSheetGrandTotal();

            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void CalculateSheetGrandTotal_TwoThreeFourMultiply_ReturnsTwentyFour()
        {
            var lines = new List<string> { "2", "3", "4", "*" };
            var sheet = new MathHomeworkSheet(lines);

            var result = sheet.CalculateSheetGrandTotal();

            Assert.That(result, Is.EqualTo(24));
        }

        [Test]
        public void CalculateSheetGrandTotal_SampleInput_Returns4277556()
        {
            var lines = new List<string> {
                "123 328  51 64 ",
                " 45 64  387 23 ",
                "  6 98  215 314",
                "*   +   *   +  " };
            var sheet = new MathHomeworkSheet(lines);

            var result = sheet.CalculateSheetGrandTotal();

            Assert.That(result, Is.EqualTo(4277556));
        }

        [Test]
        public void GetCephalopodNumbers_SampleColumnFour_ReturnsCorrectNumbers()
        {
            var result = MathHomeworkSheet.GetCephalopodNumbers(new List<string> { "64 ", "23 ", "314", "+" });

            Assert.That(result[0], Is.EqualTo(4));
            Assert.That(result[1], Is.EqualTo(431));
            Assert.That(result[2], Is.EqualTo(623));
        }

        [Test]
        public void GetCephalopodNumbers_SampleColumnThree_ReturnsCorrectNumbers()
        {
            var result = MathHomeworkSheet.GetCephalopodNumbers(new List<string> { " 51", "387", "215", "*" });

            Assert.That(result[0], Is.EqualTo(175));
            Assert.That(result[1], Is.EqualTo(581));
            Assert.That(result[2], Is.EqualTo(32));
        }

        [Test]
        public void CalculateSheetGrandTotalWithCephalopodNumbers_SampleInput_Returns3263827()
        {
            var lines = new List<string> {
                "123 328  51 64 ",
                " 45 64  387 23 ",
                "  6 98  215 314",
                "*   +   *   +  " };
            var sheet = new MathHomeworkSheet(lines);

            var result = sheet.CalculateSheetGrandTotal(true);

            Assert.That(result, Is.EqualTo(3263827));
        }

        [Test]
        public void GetPaddedRowColumns_SampleInput_ReturnsCorrectlyPaddedStrings()
        {
            var lines = new List<string> {
                "123 328  51 64 ",
                " 45 64  387 23 ",
                "  6 98  215 314",
                "*   +   *   +  " };
            var sheet = new MathHomeworkSheet(lines);

            var line1Result = sheet.GetPaddedRowColumns("123 328  51 64 ");
            Assert.That(line1Result[0], Is.EqualTo("123"));
            Assert.That(line1Result[1], Is.EqualTo("328"));
            Assert.That(line1Result[2], Is.EqualTo(" 51"));
            Assert.That(line1Result[3], Is.EqualTo("64 "));
        }
    }
}
