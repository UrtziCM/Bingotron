using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerDouble", menuName = "Bingo/Stickers/Double")]
public class BingoStickerDouble : BingoStickerNumeric
{
    [SerializeField]
    protected int number1;
    [SerializeField]
    protected int number2;

    public BingoStickerDouble(int number1, int number2) : base(number1)
    {
        this.number1 = number1;
        this.number2 = number2;
    }
    public int Number1 { get { return number1; } set { number1 = value; } }
    public int Number2 { get { return number2; } set { number2 = value; } }

    public override bool IsMarkable(BingoBall ball)
    {
        return ball.number == number1 || ball.number == number2;
    }
}
