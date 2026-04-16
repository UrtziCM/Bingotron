using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWheat", menuName = "Bingo/Tiles/Wheat")]
public class BingoTileWheat : BingoTile, IMarkable, IFlammable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
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

    public void Wet()
    {
        value++;
    }
}
