namespace TicTacToe;

public static class Logic
{
    // method to initialize the board.
    public static char[,] InitializeBoard(int gridSize)
    {
        char[,] board = new char[gridSize, gridSize];
        

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                board[i, j] = ' ';
            }
        } 
        return board;
    }  
    // Method to check if player has won.
    public static bool CheckWinRows(char currentPlayer, char[,] board, int gridSize)
    {
        // Check rows
        for (int i = 0; i < gridSize; i++)
        {
            bool rowWin = true;
            for (int j = 0; j < gridSize; j++)
            {
                if (board[i, j] != currentPlayer)
                {
                    rowWin = false;
                    break;
                }
            }

            if (rowWin) return true;
        }
        return false;
    }

    public static bool CheckWinColumns(char currentPlayer, char[,] board, int gridSize)
    {
        // Check columns
        for (int j = 0; j < gridSize; j++)
        {
            bool colWin = true;
            for (int i = 0; i < gridSize; i++)
            {
                if (board[i, j] != currentPlayer)
                {
                    colWin = false;
                    break;
                }
            }

            if (colWin) return true;
            
        }
        return false;
    }

    public static bool CheckWinDiagonalTopLeftToBottomRight(char currentPlayer, char[,] board, int gridSize)
    {
        // Check diagonal top left to bottom right.
        bool topLeftBottomRight = true;
        for (int i = 0; i < gridSize; i++)
        {
            if (board[i, i] != currentPlayer)
            {
                topLeftBottomRight = false;
                break;
            }
        }

        if (topLeftBottomRight) return true;
        return false;
    }

    public static bool CheckWinDiagonalTopRightToBottomLeft(char currentPlayer, char[,] board, int gridSize)
    {
        // Check diagonal top right to bottom left.
        bool topRightBottomLeft = true;
        for (int i = 0; i < gridSize; i++)
        {
            if (board[i, gridSize - 1 - i] != currentPlayer)
            {
                topRightBottomLeft = false;
                break;
            }
        }

        if (topRightBottomLeft) return true;
        return false;
    }

    // Method to check if board is full.
       public static bool IsBoardFull(int gridSize, char[,] board)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
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