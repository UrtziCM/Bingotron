using UnityEngine;
[CreateAssetMenu(fileName = "BingoStickerNumeric", menuName = "Bingo/Stickers/Numeric")]
public class BingoStickerNumeric : BingoSticker
{
    [SerializeField]
    private int number;
    public int Number { get { return number; } }


    public override bool IsMarkable(BingoBall ball)
    {
        return ball.number == number;
    }
}
