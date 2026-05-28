using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerSpell", menuName = "Bingo/Stickers/Spell")]
public class BingoStickerSpell : BingoStickerNumeric
{
    [SerializeField]
    private int manaCost = 100;
    public BingoStickerSpell(int number) : base(number)
    {
    }
    public override bool IsMarkable(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return false;

        if (ball.number == number)
        {
            return true;
        }
        else if (Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) >= manaCost)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MANA_COUNT_PROPERTY, 
                Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) - manaCost);
            return true;
        }

        return false;
    }
}
