using board;

namespace xadrez
{
    class XadrezPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public XadrezPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
        public Position toPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
    }
}
