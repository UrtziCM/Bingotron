using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWaterMill", menuName = "Bingo/Tiles/WaterMill")]
public class BingoTileWaterMill : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
    }

    public void Wet()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY, bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + 2);
    }
}
