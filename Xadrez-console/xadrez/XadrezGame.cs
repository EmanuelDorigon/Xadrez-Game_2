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
        public XadrezGame()
        {
            bor = new Board(8, 8);
            round = 1;
            CurrentePlayer = Color.White;
            putPieces();
            Finish = false;
        }

        public void runMoviment(Position origin, Position destination)
        {
            Piece p = bor.removePiece(origin);
            p.incrementMoviment();
            Piece pieceCaptured = bor.removePiece(destination);
            bor.putPiece(p, destination);

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
        private void putPieces()
        {
            bor.putPiece(new Tower(bor, Color.White), new XadrezPosition('c', 1).toPosition());
            bor.putPiece(new Tower(bor, Color.White), new XadrezPosition('c', 2).toPosition());
            bor.putPiece(new Tower(bor, Color.White), new XadrezPosition('d', 2).toPosition());
            bor.putPiece(new Tower(bor, Color.White), new XadrezPosition('e', 2).toPosition());
            bor.putPiece(new Tower(bor, Color.White), new XadrezPosition('e', 1).toPosition());
            bor.putPiece(new King(bor, Color.White), new XadrezPosition('d', 1).toPosition());

            bor.putPiece(new Tower(bor, Color.Black), new XadrezPosition('c', 7).toPosition());
            bor.putPiece(new Tower(bor, Color.Black), new XadrezPosition('c', 8).toPosition());
            bor.putPiece(new Tower(bor, Color.Black), new XadrezPosition('d', 7).toPosition());
            bor.putPiece(new Tower(bor, Color.Black), new XadrezPosition('e', 7).toPosition());
            bor.putPiece(new Tower(bor, Color.Black), new XadrezPosition('e', 8).toPosition());
            bor.putPiece(new King(bor, Color.Black), new XadrezPosition('d', 8).toPosition());

        }

    }
}
