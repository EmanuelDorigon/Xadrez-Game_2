using board;

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

        public abstract bool[,] movimetsPosible(); // We have metod abstract, becose Piese is class generic
        
        
        
    }
}
