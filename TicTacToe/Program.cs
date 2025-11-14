namespace TicTacToe;

public static class Program
{ 
    public static void Main(string[] args)
    {
    // Grid size - this can be changed depending on what the user selects.
     int gridSize;
    // The game board is now dynamically sized.
     char[,] board;
     char currentPlayer = Constants.X_SYMBOL; // Player uses X
         
        // Ask user what size grid they want.
       UI.OutputToUser("Welcome to Tic Tac Toe!");
       gridSize = Logic.GetGridSize();
        
       //Initialize the board with the chosen size.
       board = Logic.InitializeBoard(gridSize);
       
        //Main game loop.
        while (true)
        {
            // Show the current board
            UI.DisplayBoard(gridSize, board);

            if (currentPlayer == Constants.X_SYMBOL)
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
                if (currentPlayer == Constants.X_SYMBOL)
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
            currentPlayer = (currentPlayer == Constants.X_SYMBOL) ? Constants.O_SYMBOL : Constants.X_SYMBOL;
        }

        UI.OutputToUser("Press any key to exit...");
        UI.ReadKey();
    }
}
