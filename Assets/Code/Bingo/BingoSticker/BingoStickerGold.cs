using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerGold", menuName = "Bingo/Stickers/Gold")]
public class BingoStickerGold : BingoStickerNumeric
{
    [SerializeField]
    protected int addedMoney;

    public BingoStickerGold(int number) : base(number)
    {
    }

    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MONEY_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) + addedMoney);
            return true;
        }
        return false;
    }
}
