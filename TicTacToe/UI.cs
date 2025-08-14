namespace TicTacToe;

public static class UI
{
    
    // Method to display current state of the board.
    public static void DisplayBoard()
    {
        Console.Clear();
        Console.WriteLine("Tic Tac Toe - You are X, Computer is O\n");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {Program.board[i, 0]} | {Program.board[i, 1]} | {Program.board[i, 2]} ");
            if (i < 2)
                Console.WriteLine("---|---|---");
        }

        Console.WriteLine();
    }

    //Method to control player moves.
    public static void PlayerMove()
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
                    if (Program.board[row, col] != 'X' && Program.board[row, col] != 'O')
                    {
                        Program.board[row, col] = 'X';
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

    // Method to control AI moves.
    public static void AIMove()
    {
        Console.WriteLine("Computer is thinking...");
        System.Threading.Thread.Sleep(1000); // Pause for dramatic effect

        // Find first available spot
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Program.board[i, j] != 'X' && Program.board[i, j] != 'O')
                {
                    Program.board[i, j] = 'O';
                    return;
                }
            }
        }
    }
  
    // Method for output to user.
    public static void OutputToUser(string message)
    {
        Console.WriteLine(message);
    }
    
    // Method for reading char user enters
    public static ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    
}