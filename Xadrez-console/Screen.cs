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
                    printPiece(bor.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void printBoard(Board bor, bool[,] positionPosible)
        {
            ConsoleColor bottonOriginal = Console.BackgroundColor;
            ConsoleColor bottonChanged = ConsoleColor.DarkGray;


            for (int i = 0; i < bor.Lines; i++)
            {
                Console.Write((i - 8) * (-1) + " ");
                for (int j = 0; j < bor.Columns; j++)
                {
                    if (positionPosible[i, j])
                    {
                        Console.BackgroundColor = bottonChanged;         //fundo cinza para selecionar a possição desejada
                    }
                    else 
                    {
                        Console.BackgroundColor = bottonOriginal;
                    }
                    printPiece(bor.piece(i, j));
                    Console.BackgroundColor = bottonOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = bottonOriginal;

        }


        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
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
