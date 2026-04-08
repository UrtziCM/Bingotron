using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCatapult", menuName = "BingoTiles/BingoTileCatapult")]
public class BingoTileCatapult : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        if (bc.IsMarkable(thisTilePos + 2 * Vector2.right))
        {
            bc.MarkSpace(thisTilePos + 2 * Vector2.right);
        }
        
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
