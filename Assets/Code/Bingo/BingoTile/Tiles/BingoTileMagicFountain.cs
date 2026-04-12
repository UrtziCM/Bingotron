using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMagicFountain", menuName = "Bingo/Tiles/MagicFountain")]
public class BingoTileMagicFountain : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 targetPos = pos + direction;

            if (bc.GetSpaceAt(targetPos).GetTile() is IPermeable tile)
                tile.Wet();
        }

        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void Wet()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        int permebleCount = 0;

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 targetPos = pos + direction;

            if (bc.GetSpaceAt(targetPos).GetTile() is IPermeable tile)
                permebleCount++;
        }

        bc.GetProperty(BingoCard.MANA_COUNT_PROPERTY).SetValue(bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + (20 * permebleCount));
    }
}
