using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerBong", menuName = "Bingo/Stickers/Bong")]
public class BingoStickerBong : BingoStickerNumeric
{

    [SerializeField]
    protected int addedNotes;

    public BingoStickerBong(int number) : base(number)
    {
    }

    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MUSIC_ADDEDVALUE_PROPERTY, 
                Utils.BingoCard.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + addedNotes);
            return true;
        }
        return false;
    }
}
