class TicTacToe
{
    static void Main()
    {
        //Player
        Player playerX = new Player("X");
        Player playerO = new Player("O");

        //Board
        Board board = new Board();

        // Who play first?
        var rand = new Random();
        Player activePlayer = rand.NextSingle() < 0.5 ? playerO : playerX;
       
        Player? winner = null;

        //---------------------------ALTERNATIVE-----------------------------//
        // while (true)
        // {
        //     Refresh(board);

        //     // Select Position
        //     var selectedPosition = GetInputPosition(activePlayer, board);

        //     // Set Piece on Position
        //     board.SetPiece(selectedPosition, activePlayer);

        //     // Check if there is a winner
        //     winner = board.GetWinner();

        //     // if there is no winner, change turns and repeat to selecting position
        //     if (winner == null && board.IsNotFull())
        //     {
        //         activePlayer = activePlayer == playerO ? playerX : playerO;
        //     }
        //     // if there is a winner goto GameOver 
        //     else
        //     {
        //         Refresh(board);
        //         GameOver(winner);
        //         break;
        //     }
        // }

        //---------------------------ALTERNATIVE-----------------------------//
        while (winner == null && board.IsNotFull())
        {
            Refresh(board);
           
            // Select Position
            var selectedPosition = GetInputPosition(activePlayer, board);

            // Set Piece on Position
            board.SetPiece(selectedPosition, activePlayer);

            // Check if there is a winner
            winner = board.GetWinner();

            // Change turns
            activePlayer = activePlayer == playerO ? playerX : playerO;            
        }

        Refresh(board);
        GameOver(winner);
    }

    static void GameOver(Player? winner)
    {
        if (winner == null)
        {
            Console.WriteLine("Draw");
        }
        else
        {
            Console.WriteLine($"Player {winner.GetValue()}  Win.");
        }
    }

    static void PrintPiece(Piece piece)
    {
        Console.WriteLine(piece.GetValue());
    }

    static void Refresh(Board board)
    {
        Console.Clear();
        board.Print();
    }

    static int GetInputPosition(Player activePlayer, Board board)
    {
        while (true)
        {
            Console.WriteLine($"Player {activePlayer.GetValue()} please choose a position(number): ");

            string input = Console.ReadLine() ?? "";

            if (Int32.TryParse(input, out int result) && board.IsValid(result))
            {
                return result;
            }
            else
            {
                Refresh(board);
                Console.WriteLine($"\"{input}\" is not a valid input. Try again");
            }
        }
    }
}