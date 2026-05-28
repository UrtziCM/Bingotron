using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerQuestionMark", menuName = "Bingo/Stickers/QuestionMark")]
public class BingoStickerQuestionMark : BingoStickerNumeric, IRoller
{
    public BingoStickerQuestionMark(int number) : base(number)
    {
    }

    public override bool IsMarkable(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return false;

        return ball.number == number;
    }

    //faltaria implementar la parte visual de cuando cambia de valor 
    public void OnRoll(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return;

        number = Random.Range(1,51);
        GetSpace().transform.GetComponentInChildren<TMP_Text>().text = number.ToString();
    }
}
