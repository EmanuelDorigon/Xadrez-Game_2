using board;

namespace xadrez
{
    class Lady : Piece
    {
        public Lady(Board boar, Color color) : base(boar, color)
        {
        }

        public override string ToString()
        {
            return "L";
        }

        private bool canMoviment(Position pos)
        {
            Piece p = Boar.piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] movimetsPosible()
        {
            bool[,] array = new bool[Boar.Lines, Boar.Columns];
            Position pos = new Position(0, 0);


            //up
            pos.defineValue(Position.Line - 1, Position.Column);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }

            //Down
            pos.defineValue(Position.Line + 1, Position.Column);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }

            //right
            pos.defineValue(Position.Line, Position.Column + 1);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }

            //left
            pos.defineValue(Position.Line, Position.Column - 1);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }
            //NorthEast
            pos.defineValue(Position.Line - 1, Position.Column + 1);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
                pos.Column += 1;
            }

            //NorthWest
            pos.defineValue(Position.Line - 1, Position.Column - 1);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
                pos.Column -= 1;
            }

            //SouthWest
            pos.defineValue(Position.Line + 1, Position.Column - 1);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
                pos.Column -= 1;
            }

            //SouthEast
            pos.defineValue(Position.Line + 1, Position.Column + 1);
            while (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Boar.piece(pos) != null && Boar.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
                pos.Column += 1;
            }

            return array;
        }
    }
}
