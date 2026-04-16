using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerBong", menuName = "Bingo/Stickers/Bong")]
public class BingoStickerBong : BingoSticker
{
    [SerializeField]
    protected int number;
    [SerializeField]
    protected int addedNotes;
    public int Number { get { return number; } }


    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MUSIC_ADDEDVALUE_PROPERTY, 
                Utils.BingoCard.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + addedNotes);
            return true;
        }
        else
            return false;
    }
}
