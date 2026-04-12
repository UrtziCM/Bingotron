using UnityEngine;
[CreateAssetMenu(fileName = "BingoStickerNumeric", menuName = "Bingo/Stickers/Numeric")]
public class BingoStickerNumeric : ScriptableObject
{
    [SerializeField]
    private int number;
    public int Number { get { return number; } }


    public bool IsMarkable(BingoBall ball)
    {
        return ball.number == number;
    }
}
