using System;
using System.Collections.Generic;
using System.Text;
using board;
using xadrez;

namespace xadrez
{
    class Pawn : Piece
    {
        public Pawn(Board boar, Color color) : base(boar, color)
        {
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
                pos.defineValue(Position.Line - 2, Position.Column);
                if (MovimentQuantity == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }
            }
            else           
            {
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
                pos.defineValue(Position.Line + 2, Position.Column);
                if (MovimentQuantity == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }

            }




            return array;
        }
    }
}




