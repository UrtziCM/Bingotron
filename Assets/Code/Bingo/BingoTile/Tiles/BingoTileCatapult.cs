using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCatapult", menuName = "Bingo/Tiles/Catapult")]
public class BingoTileCatapult : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        if (bc.IsMarkable(pos + 2 * Vector2.right))
        {
            bc.MarkSpace(pos + 2 * Vector2.right);
        }
        
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
