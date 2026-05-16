using UnityEngine;
[CreateAssetMenu(fileName = "BingoStickerNumeric", menuName = "Bingo/Stickers/Numeric")]
public class BingoStickerNumeric : BingoSticker
{
    [SerializeField]
    protected int number;
    public int Number { get { return number; } set { number = value; } }

    public BingoStickerNumeric(int number)
    {
        this.number = number;
    }

    public override bool IsMarkable(BingoBall ball)
    {
        if (ball == null) return false;

        return ball.number == number;
    }
}
