namespace TicTacToe;

public static class Program
{
    // Grid size - this can be changed depending on what the user selects.
    public static int gridSize;
    // The game board is now dynamically sized.
    public static char[,] board;

    public static char currentPlayer = 'X'; // Player uses X


    static void Main(string[] args)
    {
        UI.OutputToUser("Welcome to Tic Tac Toe!");
        UI.OutputToUser("Enter grid size (3 for classic, 4-10 recommended): ");
        
        if (int.TryParse(UI.TakeInput(), out int size) && size >= 3 && size <= 10)
        {
            gridSize = size;
        }
        else
        {
            Console.WriteLine("Invalid size. Using default size 3.");
            gridSize = 3;
        }
        
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
            if (Logic.CheckWin())
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
