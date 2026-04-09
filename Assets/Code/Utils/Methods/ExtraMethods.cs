using UnityEngine;

public static class Utils 
{
    public static readonly Vector2 Top = Vector2.up;
    public static readonly Vector2 Bottom = Vector2.down;
    public static readonly Vector2 Left = Vector2.left;
    public static readonly Vector2 Right = Vector2.right;

    public static readonly Vector2 TopRight = Vector2.up + Vector2.right;
    public static readonly Vector2 TopLeft = Vector2.up + Vector2.left;
    public static readonly Vector2 BottomRight = Vector2.down + Vector2.right;
    public static readonly Vector2 BottomLeft = Vector2.down + Vector2.left;

    public static readonly Vector2[] TouchingPositions = {Top, Bottom, Left, Right};
    public static readonly Vector2[] SurroundingPositions = { Top, Bottom, Left, Right, TopRight, TopLeft, BottomRight, BottomLeft };


    public static void Spread(BingoTile bingoTile)
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = bingoTile.GetSpace().GetPosition();

        float prob = bc.GetPropertyValue(BingoCard.FIRE_PROBABILITY_PROPERTY);

        if (Random.Range(0.0f, 1.0f) > prob)
            return;

        foreach (Vector2 direction in TouchingPositions)
        {
            Vector2 pos = thisTilePos + direction;

            if (!bc.IsMarkable(pos))
                continue;
            
            if(bc.GetSpaceAt(pos).GetTile() is IFlammable tile)
                tile.OnFlame();
        }
    }

    public static bool Gamble(float baseProb)
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        float addedProb = bc.GetPropertyValue(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY);

        if (Random.Range(0.0f, 1.0f) < baseProb + addedProb)
        {
            bc.SetPropertyValue(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY, addedProb + 0.01f);
            return true;
        }
        else
            return false;
    }
}
