using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBasic", menuName = "Bingo/Tiles/Basic")]
public class BingoTileBasic : BingoTile, IMarkable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;
        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
