using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerDouble", menuName = "Bingo/Stickers/Double")]
public class BingoStickerDouble : BingoSticker
{
    [SerializeField]
    protected int number1;
    [SerializeField]
    protected int number2;
    public int Number1 { get { return number1; } }
    public int Number2 { get { return number2; } }


    public override bool IsMarkable(BingoBall ball)
    {
        return ball.number == number1 || ball.number == number2;
    }
}
