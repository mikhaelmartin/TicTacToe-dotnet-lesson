class Empty : Piece
{
    int position;

    public Empty(int position)
    {
        this.position = position;
    }

    public override string GetValue()
    {
        return position.ToString();
    }
}
