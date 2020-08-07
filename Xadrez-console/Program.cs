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
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(game);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readPositionXadrez().toPosition();
                        game.validPositionTheOrigin(origin);
                        bool[,] positionPosible = game.bor.piece(origin).movimetsPosible();

                        Console.Clear();
                        Screen.printBoard(game.bor, positionPosible);



                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.Write("Destination: ");
                        Position destination = Screen.readPositionXadrez().toPosition();
                        game.validateTargetPosition(origin, destination);

                        game.gamedPerforms(origin, destination);
                    }
                    catch (BoardException c)
                    {
                        Console.WriteLine(c.Message);
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                    }

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
