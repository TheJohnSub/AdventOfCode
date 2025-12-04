namespace Day4.Tests
{
    public class Tests
    {
        [Test]
        public void Grid_2Rows1PaperInEachRow_2Papers()
        {
            var rows = new List<string> { "@.", ".@" };
            var grid = new Grid(rows);

            Assert.That(grid.GridSlots[0, 0].IsPaper, Is.True);
            Assert.That(grid.GridSlots[0, 0].AdjacentPaper, Is.EqualTo(1));
            Assert.That(grid.GridSlots[0, 0].Column, Is.EqualTo(0));
            Assert.That(grid.GridSlots[0, 0].Row, Is.EqualTo(0));

            Assert.That(grid.GridSlots[0, 1].IsPaper, Is.False);
            Assert.That(grid.GridSlots[0, 1].Column, Is.EqualTo(1));
            Assert.That(grid.GridSlots[0, 1].Row, Is.EqualTo(0));

            Assert.That(grid.GridSlots[1, 0].IsPaper, Is.False);
            Assert.That(grid.GridSlots[1, 0].Column, Is.EqualTo(0));
            Assert.That(grid.GridSlots[1, 0].Row, Is.EqualTo(1));

            Assert.That(grid.GridSlots[1, 1].IsPaper, Is.True);
            Assert.That(grid.GridSlots[1, 1].AdjacentPaper, Is.EqualTo(1));
            Assert.That(grid.GridSlots[1, 1].Column, Is.EqualTo(1));
            Assert.That(grid.GridSlots[1, 1].Row, Is.EqualTo(1));

            Assert.That(grid.TakeAccessibleRolls, Is.EqualTo(2));
        }

        [Test]
        public void Grid_SampleInput_13AccessiblePaperRolls()
        {
            var rows = new List<string> {
                "..@@.@@@@.",
                "@@@.@.@.@@",
                "@@@@@.@.@@",
                "@.@@@@..@.",
                "@@.@@@@.@@",
                ".@@@@@@@.@",
                ".@.@.@.@@@",
                "@.@@@.@@@@",
                ".@@@@@@@@.",
                "@.@.@@@.@."
            };
            var grid = new Grid(rows);


            Assert.That(grid.TakeAccessibleRolls, Is.EqualTo(13));
        }
    }
}
