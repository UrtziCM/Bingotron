using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWheat", menuName = "Bingo/Tiles/Wheat")]
public class BingoTileWheat : BingoTile, IMarkable, IFlammable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
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
