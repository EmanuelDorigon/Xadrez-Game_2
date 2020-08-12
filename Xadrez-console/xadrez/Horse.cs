using board;

namespace xadrez
{
    class Horse : Piece
    {
        public Horse(Board boar, Color color) : base(boar, color)
        {
        }
        
        public override string ToString()
        {
            return "H";
        }

        private bool canMoviment(Position pos)
        {
            Piece p = Boar.piece(pos);
            return p == null || p.Color != Color;
        }
        
        public override bool[,] movimetsPosible()
        {
            bool[,] arrayGeneral = new bool[Boar.Lines, Boar.Columns];
            Position pos = new Position(0, 0);


            //up
            pos.defineValue(Position.Line - 2, Position.Column - 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;                
            }
            //up
            pos.defineValue(Position.Line - 2, Position.Column + 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            //Down
            pos.defineValue(Position.Line + 2, Position.Column + 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            //Down
            pos.defineValue(Position.Line + 2, Position.Column - 1);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            //Rith
            pos.defineValue(Position.Line + 1, Position.Column + 2);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            //Rith
            pos.defineValue(Position.Line - 1, Position.Column + 2);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            //Left
            pos.defineValue(Position.Line - 1, Position.Column - 2);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            //Left
            pos.defineValue(Position.Line + 1, Position.Column - 2);
            if (Boar.positionValid(pos) && canMoviment(pos))
            {
                arrayGeneral[pos.Line, pos.Column] = true;
            }
            return arrayGeneral;
        }
    }
}
