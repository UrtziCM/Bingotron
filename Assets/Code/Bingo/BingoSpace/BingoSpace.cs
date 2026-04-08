using System.Collections.Generic;
using UnityEngine;

 enum MarkState
{
    Unmarked,
    Markable,
    Marked,
}

//[CreateAssetMenu(fileName = "BaseBingoSpace", menuName = "Bingo/Spaces/BaseSpace")]
public class BingoSpace// : ScriptableObject
{
    private BingoTile tile;
    private BingoSticker number;
    private Vector2 position;
    private MarkState state;
    private BingoCard card;
    private List<string> tags;

    public BingoSpace(Vector2 position)
    {
        this.position = position;
    }

    public BingoTile GetTile() 
    {
        return tile;
    }
    public Vector2 GetPosition()
    {
        return position;
    }

    public BingoCard GetCard()
    {
        return card;
    }

    public BingoSticker GetNumber()
    {
        return number;
    }

    // TODO: TERMINAR
    public void Mark()
    {
        state = MarkState.Marked;

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
