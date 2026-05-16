using UnityEngine;

public enum Tags
{
    Inflamable,
    Cargable,
    Musical,
    Permeable,
    Ludopata,
    Conjurable
}

[CreateAssetMenu(fileName = "BingoTile", menuName = "Bingo/Tiles/BingoTile", order = -1)]
public class BingoTile : ScriptableObject
{
    internal Vector2 pos;
    internal BingoSpace space;
    [SerializeField]
    internal int value = 1;
    [SerializeField]
    public string Name;
    [SerializeField, TextArea]
    public string Description;
    [SerializeField]
    public Tags[] tags;
    [SerializeField]
    public Sprite sprite;

    public BingoSpace GetSpace()
    {
        return space;
    }

    public bool IsAt(Vector2 pos)
    {
        return pos == this.pos;
    }
}
