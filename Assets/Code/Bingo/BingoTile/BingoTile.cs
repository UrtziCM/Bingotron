using UnityEngine;

public abstract class BingoTile
{
    private Vector2 pos;
    private BingoSpace space;

    public BingoSpace GetSpace()
    {
        return space;
    }

    public bool IsAt(Vector2 pos)
    {
        return pos == this.pos;
    }

}
