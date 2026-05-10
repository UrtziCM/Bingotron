using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerQuestionMark", menuName = "Bingo/Stickers/QuestionMark")]
public class BingoStickerQuestionMark : BingoStickerNumeric, IRoller
{
    public BingoStickerQuestionMark(int number) : base(number)
    {
    }

    public override bool IsMarkable(BingoBall ball)
    {
        return ball.number == number;
    }

    //faltaria implementar la parte visual de cuando cambia de valor 
    public void OnRoll(BingoBall ball)
    {
        number = Random.Range(1,90);
    }
}
