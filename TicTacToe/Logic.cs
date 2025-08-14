namespace TicTacToe;

public static class Logic
{
    
    
    // Method to check if player has won.
    public static bool CheckWin()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (Program.board[i, 0] == Program.currentPlayer && Program.board[i, 1] == Program.currentPlayer &&Program.board[i, 2] == Program.currentPlayer)
                return true;
        }
        
        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (Program.board[0, i] == Program.currentPlayer && Program.board[1, i] == Program.currentPlayer && Program.board[2, i] == Program.currentPlayer)
                return true;
        }
        
        // Check diagonals
        if (Program.board[0, 0] == Program.currentPlayer && Program.board[1, 1] == Program.currentPlayer && Program.board[2, 2] == Program.currentPlayer)
            return true;
        
        if (Program.board[0, 2] == Program.currentPlayer && Program.board[1, 1] == Program.currentPlayer && Program.board[2, 0] == Program.currentPlayer)
            return true;
        
        return false;
    }
    
    // Method to check if board is full.
    public static bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Program.board[i, j] != 'X' && Program.board[i, j] != 'O')
                    return false;
            }
        }

        return true;
    }

}