using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerToll", menuName = "Bingo/Stickers/Toll")]
public class BingoStickerToll : BingoStickerNumeric
{
    [SerializeField]
    private int cost;

    public BingoStickerToll(int number) : base(number)
    {
    }

    public override bool IsMarkable(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return false;

        if (ball.number == number)
        {
            return true;
        }
        else if (Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) >= cost)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MONEY_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) - cost);
            return true;
        }
        
        return false;
    }
}
