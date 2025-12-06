namespace Day5.Tests
{
    public class Tests
    {
        [Test]
        public void IsFreshIngredient_FiveToFifteenGivenTen_ReturnsTrue()
        {
            var database = new FreshIngredientDatabase(new List<string> { "5-15" });
            
            var result = database.IsFreshIngredient("10");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsFreshIngredient_FiveToFifteenGivenTwenty_ReturnsFalse()
        {
            var database = new FreshIngredientDatabase(new List<string> { "5-15" });

            var result = database.IsFreshIngredient("20");

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsFreshIngredient_UnorderedListOfRangesAndGivenNumberInRange_ReturnsTrue()
        {
            var database = new FreshIngredientDatabase(new List<string> { "100-130", "5-15" });

            var result = database.IsFreshIngredient("10");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsFreshIngredient_SampleInput_ReturnsTrueFor3Ids()
        {
            var database = new FreshIngredientDatabase(new List<string> 
            { 
                "3-5",
                "10-14",
                "16-20",
                "12-18"
            });

            var ingredients = new List<string> { "1", "5", "8", "11", "17", "32" };

            var freshIngredients = ingredients.Where(i => database.IsFreshIngredient(i)).Count();

            Assert.That(freshIngredients, Is.EqualTo(3));
        }

        [Test]
        public void FreshIngredientCount_SampleInput_Returns14()
        {
            var database = new FreshIngredientDatabase(new List<string>
            {
                "3-5",
                "10-14",
                "16-20",
                "12-18"
            });

            Assert.That(database.FreshIngredientCount, Is.EqualTo(14));
        }

        [Test]
        public void FreshIngredientCount_IrrelevantRangeAfterOverlap_Returns12()
        {
            var database = new FreshIngredientDatabase(new List<string>
            {
                "9-20",
                "10-12",
            });

            Assert.That(database.FreshIngredientCount, Is.EqualTo(12));
        }

        [Test]
        public void FreshIngredientCount_IrrelevantRangeBeforeOverlap_Returns12()
        {
            var database = new FreshIngredientDatabase(new List<string>
            {
                "10-12",
                "9-20",
            });

            Assert.That(database.FreshIngredientCount, Is.EqualTo(12));
        }

        [Test]
        public void FreshIngredientCount_SampleInputAndAdditional10_Returns24()
        {
            var database = new FreshIngredientDatabase(new List<string>
            {
                "3-5",
                "10-14",
                "16-20",
                "12-18",
                "20-23",
                "25-30",
                "21-22",
                "22-26",
            });

            Assert.That(database.FreshIngredientCount, Is.EqualTo(24));
        }

        [Test]
        public void GetOverlappingPair_3To7Given1To5_Returns3To7()
        {
            var database = new FreshIngredientDatabase(new List<string> { "3-7" });
            var overlapping = database.GetOverlappingPair(new Tuple<long, long>(1, 5));

            Assert.That(overlapping, !Is.Null);
            Assert.That(overlapping.Item1, Is.EqualTo(3));
            Assert.That(overlapping.Item2, Is.EqualTo(7));
        }

        [Test]
        public void GetOverlappingPair_6To10Given1To5_ReturnsNull()
        {
            var database = new FreshIngredientDatabase(new List<string> { "6-10" });
            var overlapping = database.GetOverlappingPair(new Tuple<long, long>(1, 5));

            Assert.That(overlapping, Is.Null);
        }

        [Test]
        public void GetOverlappingPair_1To5Given3To7_Returns1To5()
        {
            var database = new FreshIngredientDatabase(new List<string> { "1-5" });
            var overlapping = database.GetOverlappingPair(new Tuple<long, long>(3, 7));

            Assert.That(overlapping, !Is.Null);
            Assert.That(overlapping.Item1, Is.EqualTo(1));
            Assert.That(overlapping.Item2, Is.EqualTo(5));
        }

        [Test]
        public void GetOverlappingPair_1To5Given6To10_ReturnsNull()
        {
            var database = new FreshIngredientDatabase(new List<string> { "1-5" });
            var overlapping = database.GetOverlappingPair(new Tuple<long, long>(6, 10));

            Assert.That(overlapping, Is.Null);
        }

        [Test]
        public void AdjustTupleToOverlapping_1To5And3To7_Returns1To2()
        {
            var adjusted = FreshIngredientDatabase.AdjustRangeToOverlapping(
                new Tuple<long, long>(1, 5),
                new Tuple<long, long>(3, 7));

            Assert.That(adjusted, !Is.Null);
            Assert.That(adjusted.Item1, Is.EqualTo(1));
            Assert.That(adjusted.Item2, Is.EqualTo(2));
        }

        [Test]
        public void AdjustTupleToOverlapping_3To7And1To5_Returns6To7()
        {
            var adjusted = FreshIngredientDatabase.AdjustRangeToOverlapping(
                new Tuple<long, long>(3, 7),
                new Tuple<long, long>(1, 5));

            Assert.That(adjusted, !Is.Null);
            Assert.That(adjusted.Item1, Is.EqualTo(6));
            Assert.That(adjusted.Item2, Is.EqualTo(7));
        }
    }
}
