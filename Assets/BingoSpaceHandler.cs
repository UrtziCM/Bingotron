using System;
using UnityEngine;
using TMPro;

public class BingoSpaceHandler : MonoBehaviour
{
    private BingoSpace bingoSpace;
    public Vector2 positionInGrid;
    private BingoCard card;
    public BingoStickerNumeric sticker => bingoSpace.GetSticker();
    public BingoTile tile => bingoSpace.GetTile();

    [SerializeField]
    private TMP_Text stickerNumberText;

    void Start()
    {
        bingoSpace = new(positionInGrid, UnityEngine.Random.Range(1,91));
        card = transform.GetComponentInParent<BingoCard>();
        card.AddBingoSpace(bingoSpace);
        stickerNumberText.text = bingoSpace.GetSticker().Number.ToString();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        card.MarkSpace(positionInGrid);
    }

    public BingoSpace GetSpace()
    {
        return bingoSpace;
    }
}
