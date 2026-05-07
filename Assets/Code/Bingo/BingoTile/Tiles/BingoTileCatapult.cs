using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCatapult", menuName = "Bingo/Tiles/Catapult")]
public class BingoTileCatapult : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = Utils.ScoreManager;

        if (bc.IsMarkable(pos + 2 * Vector2.right))
        {
            bc.MarkSpace(pos + 2 * Vector2.right);
        }
        
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
