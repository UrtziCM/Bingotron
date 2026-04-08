using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTree", menuName = "Bingo/Tiles/BingoTileTree")]
public class BingoTileTree : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
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
        ExtraMethods.Spread(this);
    }
}
