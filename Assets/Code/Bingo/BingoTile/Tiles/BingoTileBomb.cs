using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBomb", menuName = "Bingo/Tiles/BingoTileBomb")]
public class BingoTileBomb : BingoTile, IMarkable, IFlamable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
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
    }

    public void OnFlame()
    {
        Mark();
    }
    public void PostFlame(){}
    public void PreFlame(){}
    public void Spread()
    {
        ExtraMethods.Spread(this);
    }
}
