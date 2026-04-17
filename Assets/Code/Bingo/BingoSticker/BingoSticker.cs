using UnityEngine;
[CreateAssetMenu (fileName = "ERROR_ABSTRACT_CLASS", menuName = "Bingo/Stickers/BaseNumber")]
public abstract class BingoStickerNumeric : ScriptableObject
{
    private BingoSpace space;
    public int value;

    public virtual bool IsMarkable(BingoBall ball)
    {
        return false;
    }
    public BingoSpace GetSpace()
    {
        return space;
    }
}
