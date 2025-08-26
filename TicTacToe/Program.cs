namespace TicTacToe;

public static class Program
{
    // The game board - starts with numbers 1-9 for positions
    public static char[,] board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    public static char currentPlayer = 'X'; // Player uses X


    static void Main(string[] args)
    {
        UI.OutputToUser("Welcome to Tic Tac Toe!");
        UI.OutputToUser("You are X, Computer is O");
        UI.OutputToUser("Enter numbers 1-9 to make your move\n");

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
