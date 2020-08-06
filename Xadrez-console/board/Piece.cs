using xadrez;

namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovimentQuantity { get; protected set; }
        public Board Boar { get; protected set; }

        public Piece(Board boar, Color color)
        {
            Position = null;
            Color = color;
            Boar = boar;
            MovimentQuantity = 0;
        }
        public void incrementMoviment()
        {
            MovimentQuantity++;
        }

        public bool existMovimentsPosible()
        {
            bool[,] array = movimetsPosible();
            for (int i = 0; i < Boar.Lines; i++)
            {
                for (int j = 0; j < Boar.Columns; j++)
                {
                    if (array[i, j])
                    { 
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return movimetsPosible()[pos.Line, pos.Column];
        }

        public abstract bool[,] movimetsPosible(); // We have metod abstract, becose Piese is class generic
        
        
        
    }
}
