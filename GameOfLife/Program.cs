using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            board[4][4] = 1;
            board[4][5] = 1;
            board[4][6] = 1;
            board[5][3] = 1;
            board[5][4] = 1;
            board[5][5] = 1;






            while (true)
            {

                showBoard();
                lives();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
               
                clearBoard();
                
                boardtoBoard2();

                clearBoard2();

            }

           


        }

        





        private static int boardHeight = 15;
        private static int boardWidth = 15;

        private static int[][] board = Enumerable.Range(0, boardHeight + 2).Select(n => new int[boardWidth + 2]).ToArray();
        private static int[][] board2 = Enumerable.Range(0, boardHeight + 2).Select(n => new int[boardWidth + 2]).ToArray();

        public static void showBoard()
        {
            for (int i = 0; i < (boardHeight); i++)
            {
                for (int n = 0; n < (boardWidth); n++)
                {
                    Console.Write(board[i][n]);
                }

                Console.WriteLine();

            }

        }


        public static void showBoard2() //just used for some troubleshooting
        {
            for (int i = 0; i < (boardHeight); i++)
            {
                for (int n = 0; n < (boardWidth); n++)
                {
                    Console.Write(board2[i][n]);
                }

                Console.WriteLine();

            }

        }




        public static void clearBoard()
        {
            for (int e = 0; e < (boardHeight); e++)
            {
                for (int f = 0; f < (boardWidth); f++)
                {
                    board[e][f] = 0;
                }



            }

        }


        public static void clearBoard2()
        {
            for (int c = 0; c < (boardHeight); c++)
            {
                for (int d = 0; d < (boardWidth); d++)
                {
                    board2[c][d] = 0;
                }



            }

        }

        public static void boardtoBoard2()
        {
            for (int c = 0; c < (boardHeight); c++)
            {
                for (int d = 0; d < (boardWidth); d++)
                {
                    if (board2[c][d] == 1)
                        board[c][d] = 1;
                    else board[c][d] = 0;
                }

            }

        }




        public static void lives()
        {
            for (int a = 0; a < (boardHeight); a++)
            {
                for (int b = 0; b < (boardWidth); b++)
                {
                    if (b == boardWidth && a == boardHeight)
                        board2[a][b] = 0;


                    else if (b == boardWidth)
                        board2[a][b] = 0;

                    else if (a == boardHeight)
                        board2[a][b] = 0;

                    if (b == -1 && a == -1)
                        board2[a][b] = 0;

                    else if (b - 1 == -1)
                        board2[a][b] = 0;



                    else if (a - 1 == -1)
                        board2[a][b] = 0;

                    else if (board[a][b] == 1)
                    {

                        if (board[a - 1][b - 1] + board[a - 1][b] + board[a - 1][b + 1] + board[a][b + 1] + board[a][b - 1] + board[a + 1][b - 1] + board[a + 1][b] + board[a + 1][b + 1] > 3)
                        {
                            board2[a][b] = 0;
                        }

                        else if (board[a - 1][b - 1] + board[a - 1][b] + board[a - 1][b + 1] + board[a][b + 1] + board[a][b - 1] + board[a + 1][b - 1] + board[a + 1][b] + board[a + 1][b + 1] == 3 || board[a - 1][b - 1] + board[a - 1][b] + board[a - 1][b + 1] + board[a][b + 1] + board[a][b - 1] + board[a + 1][b - 1] + board[a + 1][b] + board[a + 1][b + 1] == 2)
                        {
                            board2[a][b] = 1;
                        }

                        else if (board[a - 1][b - 1] + board[a - 1][b] + board[a - 1][b + 1] + board[a][b + 1] + board[a][b - 1] + board[a + 1][b - 1] + board[a + 1][b] + board[a + 1][b + 1] < 2)
                        {
                            board2[a][b] = 0;
                        }

                    }

                    else if (board[a][b] == 0)
                    {
                        if (board[a - 1][b - 1] + board[a - 1][b] + board[a - 1][b + 1] + board[a][b + 1] + board[a][b - 1] + board[a + 1][b - 1] + board[a + 1][b] + board[a + 1][b + 1] == 3)
                        {
                            board2[a][b] = 1;
                        }
                    }
                }
            }




          

        }
    }
}


//Nothing important, just a test



//http://stackoverflow.com/questions/33461683/how-do-i-generate-several-lists-using-a-for-loop