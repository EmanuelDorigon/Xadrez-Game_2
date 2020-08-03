using System;
using System.Collections.Generic;
using System.Text;
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
    }

}
