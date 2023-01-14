using System;
using System.Threading.Tasks.Dataflow;

namespace ticTacToe
{
    class Program
    {
        //array containing the positions for the board
        static int[] gameBoard = new int[9];
        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                gameBoard[i] = 0;
            }

            int userTurn = -1;
            int compTurn = -1;
            //creating a random number
            Random random = new Random();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tic Tac Toe game\n");
                Console.WriteLine("Press 1 start a game");
                Console.WriteLine("Press X To close the program\n");
                //Waitng for user input
                int input = (int)Console.ReadKey(true).Key;

                switch(input)
                {
                    case '1':
                        //the game
                        while (checkWinner() == 0)
                        {
                            //check  position i occupied
                            while (userTurn == -1 || gameBoard[userTurn] != 0)
                            {
                                Console.WriteLine("Player 1 - Choose a number between 0 and 8");

                                //save the user input
                                var turnAsString = Console.ReadLine();
                               // int userTurn;
                                bool parseSucess = int.TryParse(turnAsString, out userTurn);
                                //userTurn = int.tryParse(Console.ReadLine());
                                if (userTurn <= 8 && parseSucess)
                                    Console.WriteLine("Player 1 picked numner " + userTurn + "\n");
                                else
                                    Console.WriteLine("You need to pick a number between 0 and 8 \n  Try again");
                                    break;
                            }
                                {
                                gameBoard[userTurn] = 1;
                            }
                            
                            //check if gameboard is filled
                            if (fullBoard())
                                break;
                            //check if position is occupied
                            while (compTurn == -1 || gameBoard[compTurn] != 0)
                            {
                                //computer picks random number
                                compTurn = random.Next(8);
                                Console.WriteLine("Computer picked numner " + compTurn + "\n");
                            }
                            gameBoard[compTurn] = 2;
                            //check if gameboard is filled
                            if (fullBoard())
                                break;

                            printGameBoard();
                        }

                        Console.WriteLine("Player " + checkWinner() + " won this game");
                        Console.ReadLine();
                        break;
                    
                    case 88:
                        //End the application
                        Environment.Exit(0);
                        break;
                }

               

        }
        }
        //method that returns 0 if noone wins, 1 if user won and 2 if computer did
        private static int checkWinner()
        {
            //row1
            if (gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2])
            {
                //return winner
                return gameBoard[0];
            }
            //row2
            if (gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5])
            {
                //return winner
                return gameBoard[3];
            }
            //row3
            if (gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8])
            {
                //return winner
                return gameBoard[6];
            }
            //column1
            if (gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6])
            {
                //return winner
                return gameBoard[0];
            }
            //column2
            if (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7])
            {
                //return winner
                return gameBoard[1];
            }
            //column3
            if (gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8])
            {
                //return winner
                return gameBoard[2];
            }
            //diaganol
            if (gameBoard[0] == gameBoard[4] && gameBoard[8] == gameBoard[8])
            {
                //return winner
                return gameBoard[0];
            }
            //diaganol
            if (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6])
            {
                //return winner
                return gameBoard[2];
            }
            return 0;
        }

        private static void printGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                if (gameBoard[i] == 0)
                {
                    Console.Write(".");
                }
                if (gameBoard[i] == 1)
                {
                    Console.Write("X");
                }
                if (gameBoard[i] == 2)
                {
                    Console.Write("O");
                }

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }

            }
        }

        private static bool fullBoard()
        {
            bool isFilled = true;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] == 0)
                {
                    isFilled = false;
                }
            }
            return isFilled;

        }
    }
}