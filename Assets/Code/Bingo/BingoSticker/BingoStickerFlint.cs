using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerFlint", menuName = "Bingo/Stickers/Flint")]
public class BingoStickerFlint : BingoStickerNumeric
{
    public BingoStickerFlint(int number) : base(number)
    {
    }
    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number)
        {
            if (GetSpace().Tile is IFlammable tile)
                tile.OnFlame();

            return true;
        }
        return false;
    }
}
