using Unity.VisualScripting;
using UnityEngine;

public class BingoStickerToll : BingoSticker
{
    [SerializeField]
    private int cost;
    public override bool IsMarkable(BingoBall ball)
    {
        if (Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) >= cost)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MONEY_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) - cost);
            return true;
        }
        else
            return false;
    }
}
