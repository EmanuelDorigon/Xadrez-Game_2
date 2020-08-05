using System;
using System.Collections.Generic;
using System.Text;
using xadrez;
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
            return "R";
        }
        private bool canMoviment(Position pos)
        {
            Piece p = Boar.piece(pos);
            return p == null || p.Color != Color;
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

            return array;
        }

    }

}
