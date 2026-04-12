using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBomb", menuName = "Bingo/Tiles/Bomb")]
public class BingoTileBomb : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Vector2 thisTilePos = GetSpace().GetPosition();

        Vector2[] directions =
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        foreach (Vector2 direction in directions)
        {
            Vector2 pos = thisTilePos + direction;

            if (bc.IsMarkable(pos))
                bc.MarkSpace(pos);
        }

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void OnFlame()
    {
        Mark();
    }
    public void PostFlame(){}
    public void PreFlame(){}
    public void Spread()
    {
        Utils.Spread(this);
    }
}
