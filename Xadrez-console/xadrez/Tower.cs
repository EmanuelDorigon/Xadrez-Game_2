﻿using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace xadrez
{
    class Tower : Piece
    {
        public Tower(Board boar, Color color) : base(boar, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
