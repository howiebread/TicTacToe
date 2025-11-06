namespace TicTacToe;

public static class UI
{
    
    // Method to display current state of the board.
    public static void DisplayBoard()
    {
        Console.Clear();
        Console.WriteLine($"Tic Tac Toe ({Program.gridSize}x{Program.gridSize}- You are X, Computer is O)\n");
        
        for (int i = 0; i < Program.gridSize; i++)
        {
            // Print the row
            for (int j = 0; j < Program.gridSize; j++)
            {
                Console.Write($" {Program.board[i, j]} ");
                if (j < Program.gridSize - 1)
                    Console.Write("|");
            }
            Console.WriteLine();
            
            // Print separator line (except for last row)
            if (i < Program.gridSize - 1)
            {
                for (int j = 0; j < Program.gridSize; j++)
                {
                    Console.Write("---");
                    if (j < Program.gridSize - 1)
                        Console.Write("+");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine();
       
    }

    //Method to control player moves.
    public static void MovePlayer()
    {
        bool validMove = false;
        int maxPosition = Program.gridSize * Program.gridSize;

        while (!validMove)
        {
            Console.Write($"Enter your move (1-{maxPosition}): ");
            string input = Console.ReadLine();

            // Try to convert input to a number
            if (int.TryParse(input, out int choice))
            {
                // Check if number is within valid range
                if (choice >= 1 && choice <= maxPosition)
                {
                    // Convert to array position 
                    int position = choice - 1;
                    int row = position / Program.gridSize;
                    int col = position % Program.gridSize;

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
                    Console.WriteLine($"Please enter a number between 1 and {maxPosition}!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }

    // Method to control AI moves.
    public static void MoveAI()
    {
        Console.WriteLine("Computer is thinking...");
        Thread.Sleep(1000); // Pause for dramatic effect

        // Find first available spot
        for (int i = 0; i < Program.gridSize; i++)
        {
            for (int j = 0; j < Program.gridSize; j++)
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

    // Method for reading input user enters
    public static string TakeInput()
    {
        return Console.ReadLine();
    }
}