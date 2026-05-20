using System;
using System.Collections.Generic;
using UnityEngine;

public enum MarkState
{
    Unmarked,
    Markable,
    Marked,
}

//[CreateAssetMenu(fileName = "BaseBingoSpace", menuName = "Bingo/Spaces/BaseSpace")]
[Serializable]
public class BingoSpace
{
    private BingoTile tile;
    public BingoTile Tile { get { return tile; } set { tile = value; } }

    public BingoStickerNumeric sticker;
    public BingoStickerNumeric Sticker { get { return sticker; } set { sticker = value; } }

    private Vector2 position;
    private MarkState state = MarkState.Unmarked;
    public MarkState State { get { return state; } set { state = value; } }
    private BingoCard card;
    private List<string> tags;

    public Transform transform;
    

    public BingoSpace(Vector2 position, int number, BingoTile initialTile, BingoStickerNumeric initialSticker)
    {
        this.position = position;
        this.sticker = GameObject.Instantiate(initialSticker);
        this.sticker.space = this;
        this.sticker.Number = number;
        this.tile = GameObject.Instantiate(initialTile);
        this.tile.pos = position;
        this.tile.space = this;
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public BingoCard GetCard()
    {
        return card;
    }

    public void Mark()
    {
        state = MarkState.Marked;
        if (sticker is IMarkable markableNumber)
            markableNumber.Mark();
        if (tile is IMarkable markableTile)
            markableTile.Mark();
        Utils.ScoreManager.AddScore(tile.value + sticker.value);
        transform.GetComponent<BingoSpaceHandler>().ChangeLooks(State);
        //Particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.markParticle, transform.position);
    }

    public bool IsMarkable()
    {
        return state == MarkState.Markable;
    }

    public bool IsMarked()
    {
        return state == MarkState.Marked;
    }

    internal void SetTile(BingoTile tile)
    {
        this.tile = tile;
    }
}
