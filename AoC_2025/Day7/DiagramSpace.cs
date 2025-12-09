namespace Day7
{
    public class DiagramSpace
    {
        private char _char;
        private bool _causedSplit = false;
        private long _possibility = 0L;
        public DiagramSpace(char c, long possibility = 0)
        {
            _char = c;
            _possibility = possibility;
            if (_char == 'S')
            {
                _possibility = 1L;
            }
        }

        public bool IsEmptySpace { get { return _char == '.'; } }
        public bool IsSplitter { get { return _char == '^'; } }
        public bool IsBeam { get { return _char == '|' || _char == 'S'; } }
        public long Possibility { get { return _possibility; } }
        public bool CausedSplit
        {
            get { return _causedSplit; }
            set
            {
                if (IsSplitter)
                {
                    _causedSplit = value;
                }
            }
        }
        public void SetToBeam(long possibility)
        {
            _char = '|';
            _possibility += possibility;
        }
    }
}
