using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerSpell", menuName = "Bingo/Stickers/Spell")]
public class BingoStickerSpell : BingoStickerNumeric, IClickable
{
    public override bool IsMarkable(BingoBall ball)
    {
        return ball.number == number;
    }

    public bool OnClick()
    {
        if (Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) >= 100)
        {
            Utils.BingoCard.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) - 100);
            return true;
        }
        else
            return false;
    }
}
