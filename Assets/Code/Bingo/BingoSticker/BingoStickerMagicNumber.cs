using UnityEngine;

public class BingoStickerMagicNumber : BingoSticker
{
    [SerializeField]
    protected int number;
    [SerializeField]
    protected int addedMana = 10;
    public int Number { get { return number; } }
    


    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MANA_COUNT_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + addedMana);
            return true;
        }
        else
            return false;
    }
}
