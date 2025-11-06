namespace TicTacToe;

public static class Program
{
    // Grid size - this can be changed depending on what the user selects.
    public static int gridSize;
    // The game board is now dynamically sized.
    public static char[,] board;
    
    


    public static void Main(string[] args)
    {
         char currentPlayer = 'X'; // Player uses X
         
        // Ask user what size grid they want.
       UI.OutputToUser("Welcome to Tic Tac Toe!");
       gridSize = Logic.GetGridSize();
        
        //Initialize the board with the chosen size.
        Logic.InitializeBoard();
        
        UI.OutputToUser("\nYou are X, Computer is O");
        UI.OutputToUser($"Enter numbers 1-{gridSize * gridSize} to make your move\n");
        
        //Main game loop.
        while (true)
        {
            // Show the current board
            UI.DisplayBoard();

            if (currentPlayer == 'X')
            {
                // Human player's turn
                UI.MovePlayer();
            }
            else
            {
                // AI player's turn
                UI.MoveAI();
            }

            // Check if someone won
            if (Logic.CheckWin(currentPlayer))
            {
                UI.DisplayBoard();
                if (currentPlayer == 'X')
                    UI.OutputToUser("You win! 🎉");
                else
                    UI.OutputToUser("Computer wins! 🤖");
                break;
            }

            // Check if board is full (tie game)
            if (Logic.IsBoardFull())
            {
                UI.DisplayBoard();
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
