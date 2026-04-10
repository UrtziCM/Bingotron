using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWaterMill", menuName = "Bingo/Tiles/BingoTileWaterMill")]
public class BingoTileWaterMill : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void Wet()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY, bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + 2);
    }
}
