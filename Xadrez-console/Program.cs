using System;
using board;
using xadrez;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XadrezGame game = new XadrezGame();
                while (!game.Finish) 
                {
                    Console.Clear();
                    Screen.printBoard(game.bor);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionXadrez().toPosition();
                    bool[,] positionPosible = game.bor.piece(origin).movimetsPosible();

                    Console.Clear();
                    Screen.printBoard(game.bor, positionPosible);



                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.readPositionXadrez().toPosition();

                    game.runMoviment(origin, destination);

                }
                Screen.printBoard(game.bor);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
