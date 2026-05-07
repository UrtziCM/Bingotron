using System.Collections.Generic;
using UnityEngine;

public enum MarkState
{
    Unmarked,
    Markable,
    Marked,
}

//[CreateAssetMenu(fileName = "BaseBingoSpace", menuName = "Bingo/Spaces/BaseSpace")]
public class BingoSpace// : ScriptableObject
{
    private BingoTile tile;
    private BingoStickerNumeric sticker;
    private Vector2 position;
    private MarkState state = MarkState.Unmarked;
    public MarkState State { get { return state; } }
    private BingoCard card;
    private List<string> tags;

    public BingoSpace(Vector2 position, int number)
    {
        this.position = position;
        this.sticker = ScriptableObject.CreateInstance<BingoStickerNumeric>();
        this.sticker.space = this;
        this.sticker.Number = number;
        this.tile = ScriptableObject.CreateInstance<BingoTile>();
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

    public BingoStickerNumeric GetSticker()
    {
        return sticker;
    }

    // TODO: TERMINADO?
    public void Mark()
    {
        state = MarkState.Marked;
        if (sticker is IMarkable markableNumber)
            markableNumber.Mark();
        if (tile is IMarkable markableTile)
            markableTile.Mark();
        Utils.ScoreManager.AddScore(tile.value + sticker.value);
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
