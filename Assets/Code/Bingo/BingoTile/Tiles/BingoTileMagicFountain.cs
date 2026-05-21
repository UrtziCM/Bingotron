using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMagicFountain", menuName = "Bingo/Tiles/MagicFountain")]
public class BingoTileMagicFountain : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 targetPos = pos + direction;

            BingoSpace targetSpace = Utils.BingoCard.GetSpaceAt(targetPos);

            if (targetSpace != null && targetSpace.Tile is IPermeable permeableTile)
                permeableTile.Wet();
        }

    }

    public void Wet()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;

        int permebleCount = 0;

        //Particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.waterParticle, GetSpace().transform.position);

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 targetPos = pos + direction;

            BingoSpace targetSpace = Utils.BingoCard.GetSpaceAt(targetPos);

            if (targetSpace != null && targetSpace.Tile is IPermeable permeableTile)
                permebleCount++;
        }

        bc.GetProperty(BingoCard.MANA_COUNT_PROPERTY).SetValue(bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + (20 * permebleCount));
        //particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.magicParticle, GetSpace().transform.position);
    }
}
