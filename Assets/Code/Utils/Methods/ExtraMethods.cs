using System.Collections.Generic;
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

    public static readonly Vector2[] TouchingPositions = { Top, Bottom, Left, Right };
    public static readonly Vector2[] SurroundingPositions = { Top, Bottom, Left, Right, TopRight, TopLeft, BottomRight, BottomLeft };

    private static BingoCard bingoCard => ServiceLocator.GetService<BingoCard>() as BingoCard;


    public static void Spread(BingoTile bingoTile)
    {
        Vector2 thisTilePos = bingoTile.GetSpace().GetPosition();

        float prob = bingoCard.GetPropertyValue(BingoCard.FIRE_PROBABILITY_PROPERTY);

        if (Random.Range(0.0f, 1.0f) > prob)
            return;

        foreach (Vector2 direction in TouchingPositions)
        {
            Vector2 pos = thisTilePos + direction;

            if (!bingoCard.IsMarkable(pos))
                continue;

            if (bingoCard.GetSpaceAt(pos).GetTile() is IFlammable tile)
                tile.OnFlame();
        }
    }

    public static bool Gamble(float baseProb)
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        float addedProb = bingoCard.GetPropertyValue(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY);

        if (Random.Range(0.0f, 1.0f) < baseProb + addedProb)
        {
            bingoCard.SetPropertyValue(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY, addedProb + 0.01f);
            return true;
        }
        else
            return false;
    }

    public static void PlayNote()
    {

        bingoCard.SetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY, bingoCard.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1);
    }

    public static BingoSpace GetRandomUnmarked()
    {
        BingoSpace bs;
        int search = 0;
        do
        {
            bs = bingoCard.GetTiles()[Random.Range(0, 25)];
            search++; // Just in case everything is marked we would not like a crash / hang on a bingo
        } while (bs.IsMarked() || search >= 25);
        if (search == 25)
            return null;
        return bs;
    }

    public static BingoSpace GetRandomUnmarkedTyped<T>() 
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        BingoSpace bs;
        List<BingoSpace> typedSpaces = new(bingoCard.GetAllSpacesOfType<T>());
        if (!(typedSpaces.Count > 0))
            return null;
        do
        {
            bs = typedSpaces[Random.Range(0, typedSpaces.Count)];
        } while (bs.IsMarked());
        return bs;
    }

    public static List<BingoTile> GetTilesOfType<T>() 
    {
        List<BingoTile> tileList = new List<BingoTile>();
        foreach (BingoSpace bs in bingoCard.GetAllSpacesOfType<T>())
            tileList.Add(bs.GetTile());

        return (tileList.Count > 0) ? tileList : null;
    }

    public static List<BingoSpace> GetTouchingSpacesFrom(Vector2 pos)
    {
        List < BingoSpace > touchingSpaces = new List<BingoSpace>();
        foreach (Vector2 direction in TouchingPositions)
        {
            Vector2 targetPos = pos + direction;
            BingoSpace touchingSpace = bingoCard.GetSpaceAt(targetPos);
            if (touchingSpace != null)
                touchingSpaces.Add(touchingSpace);
        }
        return touchingSpaces;
    }

    public static List<BingoSpace> GetSurroundingSpacesFrom(Vector2 pos)
    {
        List<BingoSpace> touchingSpaces = new List<BingoSpace>();
        foreach (Vector2 direction in SurroundingPositions)
        {
            Vector2 targetPos = pos + direction;
            BingoSpace touchingSpace = bingoCard.GetSpaceAt(targetPos);
            if (touchingSpace != null)
                touchingSpaces.Add(touchingSpace);
        }
        return touchingSpaces;
    }
}
