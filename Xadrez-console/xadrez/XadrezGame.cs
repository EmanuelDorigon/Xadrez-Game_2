﻿using System.Collections.Generic;
using board;
using System;


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
        public bool CheckMate { get; private set; }
        public Piece vulnerableEnPassant { get; private set; }
        public XadrezGame()
        {
            bor = new Board(8, 8);
            round = 1;
            CurrentePlayer = Color.White;
            Finish = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
            CheckMate = false;
            vulnerableEnPassant = null;
        }

        public Piece runMoviment(Position origin, Position destination)
        {
            Piece p = bor.removePiece(origin);
            p.incrementMoviment();
            Piece pieceCaptured = bor.removePiece(destination);
            bor.putPiece(p, destination);
            if (pieceCaptured != null)
            {
                captured.Add(pieceCaptured);
            }


            // #jogadaespecial small roque
            if(p is King && destination.Column == origin.Column + 2)
            {
                Position originTower = new Position(origin.Line, origin.Column + 3);
                Position destinationTower = new Position(origin.Line, origin.Column + 1);
                Piece T = bor.removePiece(originTower);
                T.incrementMoviment();
                bor.putPiece(T, destinationTower);
            }
            // #jogadaespecial big roque
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originTower = new Position(origin.Line, origin.Column - 4);
                Position destinationTower = new Position(origin.Line, origin.Column - 1);
                Piece T = bor.removePiece(originTower);
                T.incrementMoviment();
                bor.putPiece(T, destinationTower);
            }

            // #jogadaespecial en passant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && pieceCaptured == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destination.Line + 1, destination.Column);
                    }
                    else
                    {
                        posP = new Position(destination.Line - 1, destination.Column);
                    }
                    pieceCaptured = bor.removePiece(posP);
                    captured.Add(pieceCaptured);
                }
            }

            return pieceCaptured;

        }

        public void undosMoviment(Position origin, Position destination, Piece pieceCaptured)
        {
            Piece p = bor.removePiece(destination);
            p.decrementMoviment();
            if (pieceCaptured != null)
            {
                bor.putPiece(pieceCaptured, destination);
                captured.Remove(pieceCaptured);
            }
            bor.putPiece(p, origin);
            // #jogadaespecial small roque
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position originTower = new Position(origin.Line, origin.Column + 3);
                Position destinationTower = new Position(origin.Line, origin.Column + 1);
                Piece T = bor.removePiece(destinationTower);
                T.decrementMoviment();
                bor.putPiece(T, originTower);
            }

            // #jogadaespecial big roque
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originTower = new Position(origin.Line, origin.Column - 4);
                Position destinationTower = new Position(origin.Line, origin.Column - 1);
                Piece T = bor.removePiece(destinationTower);
                T.decrementMoviment();
                bor.putPiece(T, originTower);
            }
            // #jogadaespecial en passant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && pieceCaptured == vulnerableEnPassant)
                {
                    Piece pawn = bor.removePiece(destination);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destination.Column);
                    }
                    else
                    {
                        posP = new Position(4, destination.Column);
                    }
                    bor.putPiece(pawn, posP);
                }
            }


        }

        public void gamedPerforms(Position origin, Position destination)
        {
            Piece pieceCaptured = runMoviment(origin, destination);
            Piece p = bor.piece(destination);

            // #jogadaespecial promocao
            if (p is Pawn)
            {
                if ((p.Color == Color.White && destination.Line == 0) || (p.Color == Color.Black && destination.Line == 7))
                {
                    p = bor.removePiece(destination);
                    pieces.Remove(p);
                    Piece lady = new Lady(bor, p.Color);
                    bor.putPiece(lady, destination);
                    pieces.Add(lady);
                }
            }
            
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
            if (!bor.piece(origin).possibleMoviment(destination))
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
        
        public HashSet<Piece> pieceInGame(Color color)
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
        
            
            private Color adversary(Color color)
            {
                if (color == Color.White)
                {
                    return Color.Black;
                }
                else
                {
                    return Color.White;
                }
            }         
             
        /*
            private Piece king(Color color)
            {
                foreach (Piece x in pieceInGame(color))
                {
                    if (x is King)
                    {
                        return x;
                    }
                }
                return null;
            }
            
    */
           /* 
            public bool thisCheckmate(Color color)
            {
                Piece K = king(color);
                if (K == null)
                {
                    throw new BoardException("Don't have king " + color + " in the board");
                }

                foreach (Piece x in pieceInGame(adversary(color)))
                {
                    bool[,] array = x.movimetsPosible();
                    if (array[K.Position.Line, K.Position.Column])
                    {
                        return true;
                    }

                }
                return false;
            }
            */

            public void putNewPiece(char column, int line, Piece piece)
        {
            bor.putPiece(piece, new XadrezPosition(column, line).toPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {
            putNewPiece('a', 2, new Pawn(bor, Color.White, this));
            putNewPiece('b', 2, new Pawn(bor, Color.White, this));
            putNewPiece('c', 2, new Pawn(bor, Color.White, this));
            putNewPiece('d', 2, new Pawn(bor, Color.White, this));
            putNewPiece('e', 2, new Pawn(bor, Color.White, this));
            putNewPiece('f', 2, new Pawn(bor, Color.White, this));
            putNewPiece('g', 2, new Pawn(bor, Color.White, this));
            putNewPiece('h', 2, new Pawn(bor, Color.White, this));
            putNewPiece('a', 1, new Tower(bor, Color.White));
            putNewPiece('b', 1, new Horse(bor, Color.White));
            putNewPiece('c', 1, new Bishop(bor, Color.White));
            putNewPiece('d', 1, new Lady(bor, Color.White));
            putNewPiece('e', 1, new King(bor, Color.White));
            putNewPiece('f', 1, new Bishop(bor, Color.White));
            putNewPiece('g', 1, new Horse(bor, Color.White));
            putNewPiece('h', 1, new Tower(bor, Color.White));



            putNewPiece('a', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('b', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('c', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('d', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('e', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('f', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('g', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('h', 7, new Pawn(bor, Color.Black, this));
            putNewPiece('a', 8, new Tower(bor, Color.Black));
            putNewPiece('b', 8, new Horse(bor, Color.Black));
            putNewPiece('c', 8, new Bishop(bor, Color.Black));
            putNewPiece('d', 8, new Lady(bor, Color.Black));
            putNewPiece('e', 8, new King(bor, Color.Black));
            putNewPiece('f', 8, new Bishop(bor, Color.Black));
            putNewPiece('g', 8, new Horse(bor, Color.Black));
            putNewPiece('h', 8, new Tower(bor, Color.Black));


        }

    }
}
