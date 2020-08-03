using System;
using System.Collections.Generic;
using board;
using xadrez;

namespace Xadrez_console
{
    class Screen
    {
        public static void printBoard(Board bor)
        {

            for (int i = 0; i < bor.Lines; i++)
            {
                Console.Write((i - 8) * (-1) + " ");
                for (int j = 0; j < bor.Columns; j++)
                {
                    if (bor.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.printPiece(bor.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static void printPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;

            }
        }

        public static XadrezPosition readPositionXadrez()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new XadrezPosition(column, line);
        }
    }
}
