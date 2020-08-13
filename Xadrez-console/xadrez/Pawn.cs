using board;


namespace xadrez
{
    class Pawn : Piece
    {
        private XadrezGame Game;
        public Pawn(Board boar, Color color, XadrezGame game) : base(boar, color)
        {
            Game = game;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool free(Position pos)
        {           
            return Boar.piece(pos) == null;
        }
        private bool existEnemy(Position pos)
        {
            Piece p = Boar.piece(pos);
            return p != null && p.Color != Color;
        }       

        public override bool[,] movimetsPosible()
        {
            bool[,] array = new bool[Boar.Lines, Boar.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.defineValue(Position.Line - 2, Position.Column);
                if (Boar.positionValid(pos)  && MovimentQuantity == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }
                //up
                pos.defineValue(Position.Line - 1, Position.Column);
                if (Boar.positionValid(pos) && free(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                //northEast
                pos.defineValue(Position.Line - 1, Position.Column + 1);
                if (Boar.positionValid(pos) && existEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                //northeWest
                pos.defineValue(Position.Line - 1, Position.Column - 1);
                if (Boar.positionValid(pos) && existEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (Position.Line == 4)
                {
                    array[2, 0] = true;
                    Position left = new Position(Position.Line, Position.Column + 1);
                    if (Boar.positionValid(left))
                    {                       
                        array[2, 3] = true;
                    }
                    if (existEnemy(left))
                    {                       
                        array[3, 3] = true;
                    }
                    if (Boar.piece(left) == Game.vulnerableEnPassant)
                    {                        
                        array[4, 3] = true;
                    }

                    if (Boar.positionValid(left) && existEnemy(left) && Boar.piece(left) == Game.vulnerableEnPassant)
                    {
                        array[left.Line - 1, left.Column] = true;
                        array[3, 0] = true;                        
                    }

                    Position right = new Position(Position.Line, Position.Column - 1);
                    if (Boar.positionValid(right) && existEnemy(right) && Boar.piece(right) == Game.vulnerableEnPassant)
                    {
                        array[right.Line, right.Column] = true;
                    }
                }
                
            }
            else           
            {
                pos.defineValue(Position.Line + 2, Position.Column);
                if (Boar.positionValid(pos) && MovimentQuantity == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }
                //up
                pos.defineValue(Position.Line + 1, Position.Column);
                if (Boar.positionValid(pos) && free(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                //northEast
                pos.defineValue(Position.Line + 1, Position.Column - 1);
                if (Boar.positionValid(pos) && existEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                //northeWest
                pos.defineValue(Position.Line + 1, Position.Column + 1);
                if (Boar.positionValid(pos) && existEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Boar.positionValid(left) && existEnemy(left) && Boar.piece(left) == Game.vulnerableEnPassant)
                    {
                        array[left.Line, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Boar.positionValid(right) && existEnemy(right) && Boar.piece(right) == Game.vulnerableEnPassant)
                    {
                        array[right.Line, right.Column] = true;
                    }
                }
            }
            return array;
        }
    }
}




