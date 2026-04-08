using System;
using UnityEngine;

public class BingoSpaceHandler : MonoBehaviour
{
    private BingoSpace bingoSpace;
    public Vector2 positionInGrid;
    private BingoCard card;
    public BingoSticker sticker => bingoSpace.GetNumber();
    public BingoTile tile => bingoSpace.GetTile();

    void Start()
    {
        bingoSpace = new(positionInGrid);
        card = transform.GetComponentInParent<BingoCard>();
        card.AddBingoSpace(bingoSpace);
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (card.IsMarkable(positionInGrid))
        {
            card.MarkSpace(positionInGrid);
        }
    }

    public BingoSpace GetSpace()
    {
        return bingoSpace;
    }
}
