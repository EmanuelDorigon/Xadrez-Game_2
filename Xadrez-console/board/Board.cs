using board;
namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return Pieces[line, column];
        }

        // Criar uma sobre carga do metodo peça
        public Piece piece(Position pos)
        {
            validatePosition(pos);
            return Pieces[pos.Line, pos.Column];
        }

        public void putPiece(Piece p, Position pos)
        {
            if(existPiece(pos) == true)
            {
                throw new BoardException("This position contains a piece");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            else
            {
                Piece aux = piece(pos);
                aux.Position = null;
                Pieces[pos.Line, pos.Column] = null;
                return aux;
            }
        }
        public bool existPiece(Position pos)
        {
            validPosition(pos);
            return piece(pos) != null;
        }

        // Position is valid
        public bool positionValid(Position pos)  
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Lines)
            {
                return false;
            }
            return true;
        }
        public bool validPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Lines)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Position does not exist");
            }
        }

    }
}
