namespace Day7.Tests
{
    public class Tests
    {
        [Test]
        public void DiagramSpace_InitialLine_ConstructsWithoutErrors()
        {
            var line = "..S..";
            var diagramLine = new DiagramLine(line);

            Assert.That(diagramLine.Spaces[0].IsEmptySpace, Is.True);
            Assert.That(diagramLine.Spaces[2].IsBeam, Is.True);
            Assert.That(diagramLine.Spaces[4].IsEmptySpace, Is.True);
        }

        [Test]
        public void DiagramSpace_InitialLineAndLineWithSplitter_SplitsCorrectly()
        {
            var line1 = "..S..";
            var line2 = "..^..";
            var diagramLine1 = new DiagramLine(line1);
            var diagramLine2 = new DiagramLine(line2, diagramLine1);


            Assert.That(diagramLine2.Spaces[0].IsEmptySpace, Is.True);
            Assert.That(diagramLine2.Spaces[1].IsBeam, Is.True);
            Assert.That(diagramLine2.Spaces[2].IsSplitter, Is.True);
            Assert.That(diagramLine2.Spaces[2].CausedSplit, Is.True);
            Assert.That(diagramLine2.Spaces[3].IsBeam, Is.True);
            Assert.That(diagramLine2.Spaces[4].IsEmptySpace, Is.True);
        }

        [Test]
        public void DiagramSpace_SampleInput_Has21SplittersThatCausedSplit()
        {
            var lines = new List<string>
            {
                ".......S.......",
                "...............",
                ".......^.......",
                "...............",
                "......^.^......",
                "...............",
                ".....^.^.^.....",
                "...............",
                "....^.^...^....",
                "...............",
                "...^.^...^.^...",
                "...............",
                "..^...^.....^..",
                "...............",
                ".^.^.^.^.^...^.",
                "...............",
            };

            DiagramLine? prevDiagramLine = null;
            var diagramLines = new List<DiagramLine>();
            foreach (var line in lines)
            {
                var newDiagramLine = new DiagramLine(line, prevDiagramLine);
                diagramLines.Add(newDiagramLine);
                prevDiagramLine = newDiagramLine;
            }

            var totalSplittersThatCausedSplits = diagramLines.Sum(d => d.Spaces.Count(d => d.CausedSplit));
            Assert.That(totalSplittersThatCausedSplits, Is.EqualTo(21));
        }

        [Test]
        public void DiagramSpace_SampleInput_Has40PossiblePaths()
        {
            var lines = new List<string>
            {
                ".......S.......",
                "...............",
                ".......^.......",
                "...............",
                "......^.^......",
                "...............",
                ".....^.^.^.....",
                "...............",
                "....^.^...^....",
                "...............",
                "...^.^...^.^...",
                "...............",
                "..^...^.....^..",
                "...............",
                ".^.^.^.^.^...^.",
                "...............",
            };

            DiagramLine? prevDiagramLine = null;
            var diagramLines = new List<DiagramLine>();
            foreach (var line in lines)
            {
                var newDiagramLine = new DiagramLine(line, prevDiagramLine);
                diagramLines.Add(newDiagramLine);
                prevDiagramLine = newDiagramLine;
            }

            var linePossibilities = diagramLines.Select(l => l.Spaces.Sum(s => s.Possibility));

            Assert.That(linePossibilities.Last(), Is.EqualTo(40));
        }
    }
}
