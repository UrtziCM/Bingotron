using UnityEngine;

public class BingoTileFisher : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
    }

    public void Wet()
    {
        value++;
    }
}
