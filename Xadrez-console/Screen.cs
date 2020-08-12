using System;
using System.Collections.Generic;
using board;
using xadrez;

namespace Xadrez_console
{
    class Screen
    {
        public static void printMatch(XadrezGame match)
        {
            printBoard(match.bor);
            Console.WriteLine();
            printPieceCapture(match);
            Console.WriteLine();
            Console.WriteLine("Round: " + match.round);
            Console.WriteLine("Waiting played pieces " + match.CurrentePlayer);
            if (match.CheckMate)
            {
                Console.WriteLine("Checkmate");
            }
        }
        public static void printPieceCapture(XadrezGame match)
        {
            Console.WriteLine("Captured pieces");
            Console.Write("White: ");
            printAssembli(match.pieceCaptured(Color.White));
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printAssembli(match.pieceCaptured(Color.Black));
            Console.ForegroundColor = aux;
        }
        public static void printAssembli(HashSet<Piece> assembli)
        {
            Console.Write("[");
            foreach (Piece x in assembli)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

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
            if (s[0] == 'a' || s[0] == 'b' || s[0] == 'c' || s[0] == 'd' || s[0] == 'e' || s[0] == 'f' || s[0] == 'g' || s[0] == 'h' ||
                s[0] == 'A' || s[0] == 'B' || s[0] == 'C' || s[0] == 'D' || s[0] == 'E' || s[0] == 'F' || s[0] == 'G' || s[0] == 'H')
            {
            }
            else
            {
                throw new BoardException("Invalid caracter");
            }

            int line = int.Parse(s[1] + "");
            if (line > 8 || line < 1)
            {
                throw new BoardException("Invalid number");
            }
            return new XadrezPosition(column, line);
        }
    }
}
