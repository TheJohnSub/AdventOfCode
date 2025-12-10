namespace Day9.Tests
{
    public class Tests
    {
        private List<string> SampleInput = new() { "7,1", "11,1", "11,7", "9,7", "9,5", "2,5", "2,3", "7,3" };
        private List<string> InputWithConcave = new() { "3,1", "3,5", "1,5", "1,10", "3,10", "3,16", "1,16", "1,20", "4, 20", "4, 1" };
        [Test]
        public void LargestAreaCreatedByRedTilePair_SampleInput_Returns50()
        {
            
            var floorGrid = new FloorGrid(SampleInput);
            var largestArea = floorGrid.LargestAreaCreatedByRedTilePair;
            Assert.That(largestArea, Is.EqualTo(50));
        }

        [TestCase(3, 7, 1, 11, true)] //direct left border, implied bottom border, direct right border, direct top border
        [TestCase(0, 0, 1, 1, false)] //invalid points, no segments at all
        [TestCase(1, 7, 3, 2, false)] //no left border, no top border
        [TestCase(3, 7, 7, 11, false)] //incomplete left border, incomplete bottom border, direct right border, implied top border
        [TestCase(3, 7, 5, 9, true)] //implied left border, direct bottom border, implied right border, implied top border
        [TestCase(3, 2, 5, 9, true)] //direct left border, direct bottom border, implied right border, segmented top border
        public void IsAreaCompletelyFilled_SampleInput_ReturnsExpectedBoolean(long tile1Row, long tile1Col, long tile2Row, long tile2Col, bool expectedResult)
        {
            var floorGrid = new FloorGrid(SampleInput);

            var tile1 = new Tile(tile1Row, tile1Col);
            var tile2 = new Tile(tile2Row, tile2Col);
            var result = floorGrid.IsAreaCompletelyFilled(new Tuple<Tile, Tile>(tile1, tile2));

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void LargestCompletelyFilledAreaCreatedByRedTilePair_SampleInput_Returns24()
        {

            var floorGrid = new FloorGrid(SampleInput);
            var largestArea = floorGrid.LargestCompletelyFilledAreaCreatedByRedTilePair;
            Assert.That(largestArea, Is.EqualTo(24));
        }

        [Test]
        public void LargestCompletelyFilledAreaCreatedByRedTilePair_InputWithConcave_Returns40()
        {

            var floorGrid = new FloorGrid(InputWithConcave);
            var largestArea = floorGrid.LargestCompletelyFilledAreaCreatedByRedTilePair;
            Assert.That(largestArea, Is.EqualTo(40));
        }

        [Test]
        public void AreSegmentsConsecutive_ConsecutiveSegments_ReturnsTrue()
        {
            var consecutiveSegments = new List<Tuple<long, long>> { new Tuple<long, long>(0, 4), new Tuple<long, long>(5, 10) };
            var result = FloorGrid.AreSegmentsConsecutive(consecutiveSegments);
            Assert.That(result, Is.True);
        }

        [Test]
        public void AreSegmentsConsecutive_NonconsecutiveSegments_ReturnsFalse()
        {
            var nonConsecutiveSegments = new List<Tuple<long, long>> { new Tuple<long, long>(0, 4), new Tuple<long, long>(6, 10) };
            var result = FloorGrid.AreSegmentsConsecutive(nonConsecutiveSegments);
            Assert.That(result, Is.False);
        }
    }
}
