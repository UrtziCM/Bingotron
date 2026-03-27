using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFisher", menuName = "BingoTiles/BingoTileFisher")]
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
