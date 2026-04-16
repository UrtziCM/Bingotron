using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerFlint", menuName = "Bingo/Stickers/Flint")]
public class BingoStickerFlint : BingoSticker
{
    [SerializeField]
    protected int number;
    public int Number { get { return number; } }

    public override bool IsMarkable(BingoBall ball)
    {
        if (ball.number == number && GetSpace().GetTile() is IFlammable tile)
            tile.OnFlame();
        
        return ball.number == number;
    }
}
