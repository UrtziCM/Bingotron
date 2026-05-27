using UnityEngine;
[CreateAssetMenu (fileName = "ERROR_ABSTRACT_CLASS", menuName = "Bingo/Stickers/BaseNumber")]
public abstract class BingoSticker : ScriptableObject, ShopItem
{
    public BingoSpace space;
    public int value;

    [SerializeField]
    public string Name;
    [SerializeField, TextArea]
    public string Description;
    [SerializeField]
    public Tags[] tags;
    [SerializeField]
    public Color textColor;
    public virtual bool IsMarkable(BingoBall ball)
    {
        return false;
    }
    public BingoSpace GetSpace()
    {
        return space;
    }
}
