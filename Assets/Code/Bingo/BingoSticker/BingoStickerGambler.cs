using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerGambler", menuName = "Bingo/Stickers/Gambler")]
public class BingoStickerGambler : BingoStickerNumeric, IRoller, IGamble
{
    public BingoStickerGambler(int number) : base(number)
    {
    }

    public float BaseProbability => 0.01f;

    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability, GetSpace().transform.position);
    }
    public void OnRoll(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return;

        if (GetSpace().IsMarkable())
            if (Gamble())
                GetSpace().Mark();
    }
}
