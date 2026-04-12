using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWaterMill", menuName = "Bingo/Tiles/WaterMill")]
public class BingoTileWaterMill : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void Wet()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY, bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + 2);
    }
}
