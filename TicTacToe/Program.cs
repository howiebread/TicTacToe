namespace TicTacToe;

class Program
{
    // The game board - starts with numbers 1-9 for positions
    char[,] board =
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
}
