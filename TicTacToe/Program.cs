namespace TicTacToe;

public static class Program
{
    
  
    
    


    public static void Main(string[] args)
    {
    // Grid size - this can be changed depending on what the user selects.
     int gridSize;
    // The game board is now dynamically sized.
     char[,] board;
     char currentPlayer = 'X'; // Player uses X
         
        // Ask user what size grid they want.
       UI.OutputToUser("Welcome to Tic Tac Toe!");
       gridSize = Logic.GetGridSize();
        
        //Initialize the board with the chosen size.
        board = Logic.InitializeBoard(gridSize);
        
        UI.OutputToUser("\nYou are X, Computer is O");
        UI.OutputToUser($"Enter numbers 1-{gridSize * gridSize} to make your move\n");
        
        //Main game loop.
        while (true)
        {
            // Show the current board
            UI.DisplayBoard(gridSize, board);

            if (currentPlayer == 'X')
            {
                // Human player's turn
                UI.MovePlayer(gridSize, board);
            }
            else
            {
                // AI player's turn
                UI.MoveAI(gridSize, board);
            }

            // Check if someone won
            if (Logic.CheckWin(currentPlayer, board, gridSize))
            {
                UI.DisplayBoard(gridSize, board);
                if (currentPlayer == 'X')
                    UI.OutputToUser("You win! 🎉");
                else
                    UI.OutputToUser("Computer wins! 🤖");
                break;
            }

            // Check if board is full (tie game)
            if (Logic.IsBoardFull(gridSize, board))
            {
                UI.DisplayBoard(gridSize, board);
                UI.OutputToUser("It's a tie! 🤝");
                break;
            }

            // Switch to the other player
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        UI.OutputToUser("Press any key to exit...");
        UI.ReadKey();
    }
}
