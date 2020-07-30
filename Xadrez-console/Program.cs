using System;
using board;
using xadrez;
using Xadrez_console.xadrez;
using Xadrez_console;


namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board bor = new Board(8, 8);

            bor.putPiece(new Tower(bor, Color.Black), new Position(0, 0));
            bor.putPiece(new Tower(bor, Color.Black), new Position(1, 3));
            bor.putPiece(new Tower(bor, Color.Black), new Position(0, 2));
            bor.putPiece(new Tower(bor, Color.White), new Position(3, 5));


            Screen.printBoard(bor);
        }
    }
}
