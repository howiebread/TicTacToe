namespace TicTacToe;

public static class UI
{
    
    // Method to display current state of the board.
    public static void DisplayBoard(int gridSize, char[,] board)
    {
        Console.Clear();
        Console.WriteLine($"Tic Tac Toe ({gridSize}x{gridSize}- You are X, Computer is O)\n");
        
        for (int i = 0; i < gridSize; i++)
        {
            // Print the row
            for (int j = 0; j < gridSize; j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < gridSize - Constants.SUBTRACT_FROM_GRIDSIZE)
                    Console.Write("|");
            }
            Console.WriteLine();
            
            // Print separator line (except for last row)
            if (i < gridSize - Constants.SUBTRACT_FROM_GRIDSIZE)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write("---");
                    if (j < gridSize - Constants.SUBTRACT_FROM_GRIDSIZE)
                        Console.Write("+");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine();
       
    }

    //Method to control player moves.
    public static void MovePlayer(int gridSize, char[,] board)
    {
        bool validMove = false;
        int maxPosition = gridSize * gridSize;

        while (!validMove)
        {
            Console.Write($"Enter your move (1-{maxPosition}): ");
            string input = Console.ReadLine();

            // Try to convert input to a number
            if (int.TryParse(input, out int choice))
            {
                // Check if number is within valid range
                if (choice >= Constants.MINIMUN_VALID_RANGE && choice <= maxPosition)
                {
                    // Convert to array position 
                    int position = choice - Constants.MINIMUN_VALID_RANGE;
                    int row = position / gridSize;
                    int col = position % gridSize;

                    // Check if spot is empty
                    if (board[row, col] != Constants.X_SYMBOL && board[row, col] != Constants.O_SYMBOL)
                    {
                        board[row, col] = Constants.X_SYMBOL;
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
    public static void MoveAI(int gridSize, char[,] board)
    {
        Console.WriteLine("Computer is thinking...");
        Thread.Sleep(1000); // Pause for dramatic effect

        // Find first available spot
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (board[i, j] != Constants.X_SYMBOL && board[i, j] != Constants.O_SYMBOL)
                {
                    board[i, j] = Constants.O_SYMBOL;
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