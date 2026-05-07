using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWire", menuName = "Bingo/Tiles/Wire")]
public class BingoTileWire : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY ,bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + 1);

    }
}
