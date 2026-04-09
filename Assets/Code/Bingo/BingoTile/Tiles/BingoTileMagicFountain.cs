using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMagicFountain", menuName = "Bingo/Tiles/BingoTileMagicFountain")]
public class BingoTileMagicFountain : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Vector2 thisTilePos = GetSpace().GetPosition();

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 pos = thisTilePos + direction;

            if (bc.GetSpaceAt(pos).GetTile() is IPermeable tile)
                tile.Wet();
        }

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void Wet()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        Vector2 thisTilePos = GetSpace().GetPosition();

        int permebleCount = 0;

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 pos = thisTilePos + direction;

            if (bc.GetSpaceAt(pos).GetTile() is IPermeable tile)
                permebleCount++;
        }

        bc.GetProperty(BingoCard.MANA_COUNT_PROPERTY).SetValue(bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + (20 * permebleCount));
    }
}
