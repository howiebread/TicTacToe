namespace TicTacToe;

class Program
{
    // The game board - starts with numbers 1-9 for positions
    static char[,] board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    const char PLAYER_MARK = 'X'; // Player uses X
    const char COMPUTER_MARK = 'O'; // Computer uses O

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        Console.WriteLine("You are X, Computer is O");
        Console.WriteLine("Enter numbers 1-9 to make your move\n");
    }

    // Method to display current state of the board.
    static void DisplayBoard()
    {
        Console.Clear();
        Console.WriteLine("Tic Tac Toe - You are X, Computer is O\n");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
            if (i < 2)
                Console.WriteLine("---|---|---");
        }

        Console.WriteLine();
    }

    static void AIMove()
    {
        Console.WriteLine("Computer is thinking...");
        System.Threading.Thread.Sleep(1000); // Pause for dramatic effect

        // Find first available spot
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] != 'X' && board[i, j] != 'O')
                {
                    board[i, j] = 'O';
                    return;
                }
            }
        }
    }

    static void PlayerMove()
    {
        bool validMove = false;

        while (!validMove)
        {
            Console.Write("Enter your move (1-9): ");
            string input = Console.ReadLine();

            // Try to convert input to a number
            if (int.TryParse(input, out int choice))
            {
                // Check if number is between 1 and 9
                if (choice >= 1 && choice <= 9)
                {
                    // Convert to array position (1->0, 2->1, etc.)
                    int position = choice - 1;
                    int row = position / 3;
                    int col = position % 3;

                    // Check if spot is empty
                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = 'X';
                        validMove = true; // Exit the loop
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 9!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }
}
