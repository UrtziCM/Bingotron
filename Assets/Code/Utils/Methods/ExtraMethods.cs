using UnityEngine;

public static class ExtraMethods 
{
    public static void Spread(BingoTile bingoTile)
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = bingoTile.GetSpace().GetPosition();

        float prob = bc.GetValueFromProperty(BingoCard.FIRE_PROBABILITY_PROPERTY);

        if (Random.Range(0.0f, 1.0f) > prob)
            return;

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

            if (!bc.IsMarkable(pos))
                continue;
            
            if(bc.GetSpaceAt(pos).GetTile() is IFlammable tile)
                tile.OnFlame();
        }
    }
}
