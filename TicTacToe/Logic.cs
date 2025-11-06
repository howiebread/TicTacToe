namespace TicTacToe;

public static class Logic
{
    // method to initialize the board.
    public static void InitializeBoard()
    {
        Program.board = new char[Program.gridSize, Program.gridSize];
        int number = 1;

        for (int i = 0; i < Program.gridSize; i++)
        {
            for (int j = 0; j < Program.gridSize; j++)
            {
                // For single digit numbers, use the number
                // For larger numbers, use letters or symbols
                if (number <= 9)
                    Program.board[i, j] = number.ToString()[0];
                else if (number <= 35)
                    Program.board[i, j] = (char)('A' + number - 10); // A, B, C, etc.
                else
                    Program.board[i, j] = '*'; // Fallback for very large grids

                number++;
            }
        }
    }

    // Method to check if player has won.
       public static bool CheckWin(char currentPlayer)
        {
            // Check rows
            for (int i = 0; i < Program.gridSize; i++)
            {
                bool rowWin = true;
                for (int j = 0; j < Program.gridSize; j++)
                {
                    if (Program.board[i, j] != currentPlayer)
                    {
                        rowWin = false;
                        break;
                    }
                }
                if (rowWin) return true;
            }

            // Check columns
            for (int j = 0; j < Program.gridSize; j++)
            {
                bool colWin = true;
                for (int i = 0; i < Program.gridSize; i++)
                {
                    if (Program.board[i, j] != currentPlayer)
                    {
                        colWin = false;
                        break;
                    }
                }
                if (colWin) return true;
            }

            // Check diagonal top left to bottom right.
            bool topLeftBottomRight = true;
            for (int i = 0; i < Program.gridSize; i++)
            {
                if (Program.board[i, i] != currentPlayer)
                {
                    topLeftBottomRight = false;
                    break;
                }
            }
            if (topLeftBottomRight) return true;
            
            // Check diagonal top right to bottom left.
            bool topRightBottomLeft = true;
            for (int i = 0; i < Program.gridSize; i++)
            {
                if (Program.board[i, Program.gridSize - 1 - i] != currentPlayer)
                {
                    topRightBottomLeft = false;
                    break;
                }
            }
            if (topRightBottomLeft) return true;
            return false;
        }
    

        // Method to check if board is full.
       public static bool IsBoardFull()
        {
            for (int i = 0; i < Program.gridSize; i++)
            {
                for (int j = 0; j < Program.gridSize; j++)
                {
                    if (Program.board[i, j] != 'X' && Program.board[i, j] != 'O')
                        return false;
                }
            }

            return true;
        }

       // Method to get grid size from user input.
       public static int GetGridSize()
       {
           UI.OutputToUser("Enter grid size: ");
           if (int.TryParse(UI.TakeInput(), out int size) && size >= Constants.MIN_SIZE && size <= Constants.MAX_SIZE)
           {
               return size;
           }

           UI.OutputToUser("Invalid size. Using default size 3.");
           
           return Constants.DEFAULT_SIZE;


       }
}