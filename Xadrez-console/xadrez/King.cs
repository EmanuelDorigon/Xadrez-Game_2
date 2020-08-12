using board;

namespace xadrez
{
    class King : Piece
    {
        public King(Board boar, Color color) : base(boar, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
        private bool canMoviment(Position pos)
        {
            Piece p = Boar.piece(pos);
            return p == null || p.Color != Color;
        }
        private bool towerTesttoRoque(Position pos)
        {
            Piece p = Boar.piece(pos);
            return p != null && p is Tower && p.Color == Color && MovimentQuantity == 0;
        }
        public override bool[,] movimetsPosible()
        {
            bool[,] array = new bool[Boar.Lines, Boar.Columns];
            Position pos = new Position(0, 0);


            //up
            pos.defineValue(Position.Line - 1, Position.Column);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //right
            pos.defineValue(Position.Line, Position.Column + 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //left
            pos.defineValue(Position.Line, Position.Column - 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //down
            pos.defineValue(Position.Line + 1, Position.Column);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //northwestern
            pos.defineValue(Position.Line - 1, Position.Column + 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //southeast
            pos.defineValue(Position.Line + 1, Position.Column + 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //sout-west
            pos.defineValue(Position.Line + 1, Position.Column - 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //northewest
            pos.defineValue(Position.Line - 1, Position.Column - 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            // Jogada especial Roque
            if (MovimentQuantity == 0)
            {
                // jogada especial roque pequeno
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (towerTesttoRoque(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Boar.piece(p1) == null && Boar.piece(p2) == null)
                    {
                        array[Position.Line, Position.Column + 2] = true;
                    }
                }

            }

            // #Jogadaespecial Roque grande
            if (MovimentQuantity == 0)
            {
                // #jogadaespecial roque pequeno
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (towerTesttoRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Boar.piece(p1) == null && Boar.piece(p2) == null && Boar.piece(p3) == null)
                    {
                        array[Position.Line, Position.Column - 2] = true;
                    }
                }

            }

            return array;
        }

    }

}
