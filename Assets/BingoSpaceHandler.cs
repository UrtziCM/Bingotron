using System;
using UnityEngine;
using TMPro;

public class BingoSpaceHandler : MonoBehaviour
{
    private BingoSpace bingoSpace;
    public Vector2 positionInGrid;
    private BingoCard card;
    public BingoStickerNumeric sticker => bingoSpace.Sticker;
    public BingoTile tile => bingoSpace.Tile;

    [SerializeField]
    private TMP_Text stickerNumberText;

    [SerializeField]
    private Color markedColor;
    private Color unmarkedColor;

    void Start()
    {
        bingoSpace = new(positionInGrid, UnityEngine.Random.Range(1,91));
        card = transform.GetComponentInParent<BingoCard>();
        card.AddBingoSpace(bingoSpace);
        stickerNumberText.text = bingoSpace.Sticker.Number.ToString();
    }

    private void OnMouseDown()
    {
        if (card.ConstructionMode)
            if (Utils.Rewards.Selected is BingoStickerNumeric sticker)
                card.ReplaceAt(positionInGrid, sticker);
            else if (Utils.Rewards.Selected is BingoTile tile)
                card.ReplaceAt(positionInGrid, tile);
            else
                card.MarkSpace(positionInGrid);
        ChangeLooks(bingoSpace.State);
    }

    private void ChangeLooks(MarkState state)
    {
        switch (state)
        {
            case MarkState.Marked:
                GetComponent<SpriteRenderer>().color = markedColor;
                break;
        }
    }

    public BingoSpace GetSpace()
    {
        return bingoSpace;
    }
}
