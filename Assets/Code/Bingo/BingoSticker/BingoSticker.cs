using UnityEngine;

public abstract class BingoSticker
{
    private BingoSpace space;

    public virtual bool IsMarkable()
    {
        return false;
    }
    public BingoSpace GetSpace()
    {
        return space;
    }
}
