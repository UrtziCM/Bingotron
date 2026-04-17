using UnityEngine;

public class BingoStickerQuestionMark : BingoSticker, IRoller
{
    [SerializeField]
    protected int number;
    public int Number { get { return number; } }

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
