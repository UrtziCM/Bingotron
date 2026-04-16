using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTree", menuName = "Bingo/Tiles/Tree")]
public class BingoTileTree : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;
        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void OnFlame()
    {
        Mark();
    }

    public void PostFlame()
    {
    }

    public void PreFlame()
    {
    }

    public void Spread()
    {
        Utils.Spread(this);
    }
}
