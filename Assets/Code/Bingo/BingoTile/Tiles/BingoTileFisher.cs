using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFisher", menuName = "Bingo/Tiles/Fisher")]
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
