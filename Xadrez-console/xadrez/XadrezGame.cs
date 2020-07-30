using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace Xadrez_console.xadrez
{
    class XadrezGame
    {
        private Board bor;
        private int round;
        private Color currentePlayer;

        public XadrezGame()
        {
            bor = new Board(8, 8);
            round = 1;
            currentePlayer = Color.White;
        }

        public void runMoviment(Position origin, Position dastination)
        { 
        
        }
    
    }
}
