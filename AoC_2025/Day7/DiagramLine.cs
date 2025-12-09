namespace Day7
{
    public class DiagramLine
    {
        public readonly DiagramSpace[] Spaces;
        public DiagramLine(string line, DiagramLine? previousLine = null) 
        {
            Spaces = new DiagramSpace[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                if (Spaces[i] == null)
                {
                    Spaces[i] = new DiagramSpace(line[i]);
                }
                if (previousLine is not null)
                {
                    HandleBeamPath(i, previousLine.Spaces[i]);
                }
            }
        }

        private void HandleBeamPath(int currentIndex, DiagramSpace spaceAbove)
        {
            if (!spaceAbove.IsBeam)
            {
                return;
            }

            var currentSpace = Spaces[currentIndex];
            if (currentSpace.IsSplitter)
            {
                //set left to beam
                if (currentIndex > 0)
                {
                    Spaces[currentIndex - 1].SetToBeam(spaceAbove.Possibility);
                }
                //set right to beam
                if (currentIndex < Spaces.Length - 1)
                {
                    Spaces[currentIndex + 1] = new DiagramSpace('|', spaceAbove.Possibility);
                }
                currentSpace.CausedSplit = true;
            }
            else currentSpace.SetToBeam(spaceAbove.Possibility);
        }
    }
}
