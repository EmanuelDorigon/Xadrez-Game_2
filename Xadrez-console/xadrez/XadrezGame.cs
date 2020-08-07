using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace xadrez
{
    class XadrezGame
    {
        public Board bor { get; private set; }
        public int round { get; private set; }
        public Color CurrentePlayer { get; private set; }
        public bool Finish { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public XadrezGame()
        {
            bor = new Board(8, 8);
            round = 1;
            CurrentePlayer = Color.White;
            Finish = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public void runMoviment(Position origin, Position destination)
        {
            Piece p = bor.removePiece(origin);
            p.incrementMoviment();
            Piece pieceCaptured = bor.removePiece(destination);
            bor.putPiece(p, destination);
            if (pieceCaptured != null)
            {
                captured.Add(pieceCaptured);
            }

        }

        public void gamedPerforms(Position origin, Position destination)
        {
            runMoviment(origin, destination);
            round++;
            changedPlayer();
        }
        public void validPositionTheOrigin(Position pos)
        {
            if (bor.piece(pos) == null)
            {
                throw new BoardException("Not exist piece in the position chosen");
            }
            if (CurrentePlayer != bor.piece(pos).Color)
            {
                throw new BoardException("This piece is not your");
            }
            if (!bor.piece(pos).existMovimentsPosible())
            {
                throw new BoardException("There is no possible movement for de chosen piece");
            }

        }

        public void validateTargetPosition(Position origin, Position destination)
        {
            if (!bor.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("Destination position invalidates");
            }
        }
        private void changedPlayer()
        {
            if (CurrentePlayer == Color.White)
            {
                CurrentePlayer = Color.Black;
            }
            else
            {
                CurrentePlayer = Color.White;
            }

        }
        public HashSet<Piece> pieceCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> pieceinGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pieceCaptured(color));
            return aux;
        }
        public void putNewPiece(char column, int line, Piece piece)
        {
            bor.putPiece(piece, new XadrezPosition(column, line).toPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {
            putNewPiece('c', 1, new Tower(bor, Color.White));
            putNewPiece('c', 2, new Tower(bor, Color.White));
            putNewPiece('d', 2, new Tower(bor, Color.White));
            putNewPiece('e', 2, new Tower(bor, Color.White));
            putNewPiece('e', 1, new Tower(bor, Color.White));
            putNewPiece('d', 1, new King(bor, Color.White));

            putNewPiece('c', 7, new Tower(bor, Color.Black));
            putNewPiece('c', 8, new Tower(bor, Color.Black));
            putNewPiece('d', 7, new Tower(bor, Color.Black));
            putNewPiece('e', 7, new Tower(bor, Color.Black));
            putNewPiece('e', 8, new Tower(bor, Color.Black));
            putNewPiece('d', 8, new King(bor, Color.Black));

        }

    }
}
