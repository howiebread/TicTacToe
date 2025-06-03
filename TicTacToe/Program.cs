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
    
    
}
