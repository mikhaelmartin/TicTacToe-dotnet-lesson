class Board
{
    Piece[] pieces = new Piece[9];

    public Board()
    {
        for (int i = 0; i < 9; i++)
        {
            pieces[i] = new Empty(i + 1);
        }
    }

    public void Print()
    {
        Console.WriteLine($"[{pieces[0].GetValue()}][{pieces[1].GetValue()}][{pieces[2].GetValue()}]");
        Console.WriteLine($"[{pieces[3].GetValue()}][{pieces[4].GetValue()}][{pieces[5].GetValue()}]");
        Console.WriteLine($"[{pieces[6].GetValue()}][{pieces[7].GetValue()}][{pieces[8].GetValue()}]");
    }

    public bool IsValid(int position)
    {
        return
            position >= 1 &&
            position <= 9 &&
            pieces[position - 1] is Empty;
    }

    public void SetPiece(int position, Piece newPiece)
    {
        this.pieces[position - 1] = newPiece;
    }

    public bool IsNotFull()
    {
        //---------------------------ALTERNATIVE-----------------------------//
        // foreach (var item in pieces)
        // {
        //     if (item is Empty)
        //         return true;
        // }
        // return false;

        return pieces.Any(CheckIsEmpty);
    }

    public bool CheckIsEmpty(Piece p)
    {
        return p is Empty;
    }

    public Player? GetWinner()
    {
        //---------------------------ALTERNATIVE-----------------------------//
        // var checkPos = new int[8, 3] {
        //     {0,1,2},
        //     {3,4,5},
        //     {6,7,8},
        //     {0,3,6},
        //     {1,4,7},
        //     {2,5,8},
        //     {0,4,8},
        //     {2,4,6},
        // };

        // for (int i = 0; i < checkPos.GetLength(0); i++)
        // {
        //     Player? player = pieces[checkPos[i, 0]] as Player;

        //     if (player == null)
        //         continue;

        //     if(pieces[checkPos[i,1]] == player && pieces[checkPos[i,2]] == player)  
        //         return player;
        // }

        var checkPos = new int[][]{
            new int[] {0,1,2},
            new int[] {3,4,5},
            new int[] {6,7,8},
            new int[] {0,3,6},
            new int[] {1,4,7},
            new int[] {2,5,8},
            new int[] {0,4,8},
            new int[] {2,4,6},
        };

        foreach (int[] pos in checkPos)
        {
            Player? player = pieces[pos[0]] as Player;
            if (player == null)
                continue;

            if (pieces[pos[1]] == player && pieces[pos[2]] == player)
                return player;
        }       

        return null;
    }
}