using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Tilemaps;

 enum MarkState
{
    Unmarked,
    Markable,
    Marked,
}
public class BingoSpace
{
    private BingoTile tile;
    private BingoSticker number;
    private Vector2 pos;
    private MarkState state;
    private BingoCard card;

    public BingoTile GetTile() 
    {
        return tile;
    }

    public BingoSticker GetNumber()
    {
        return number;
    }

    // TODO: TERMINAR
    public void Mark()
    {
    }

    public bool IsMarkable()
    {
        return state == MarkState.Markable;
    }

    public bool IsMarked()
    {
        return state == MarkState.Marked;
    }
}
