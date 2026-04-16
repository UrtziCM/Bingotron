using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerGold", menuName = "Bingo/Stickers/Gold")]
public class BingoStickerGold : BingoSticker
{
    [SerializeField]
    protected int number;
    public int Number { get { return number; } }


    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MONEY_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) + 1);
            return true;
        }
        else
            return false;
    }
}
