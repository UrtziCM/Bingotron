using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFisher", menuName = "Bingo/Tiles/Fisher")]
public class BingoTileFisher : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        sm.AddScore(value + GetSpace().GetSticker().value);
    }

    public void Wet()
    {
        value++;
    }
}
