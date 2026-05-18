using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BingoSpaceHandler : MonoBehaviour
{
    [SerializeField]
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

    private DescriptionHover descriptionHover;
    [Header("Initial configuration")]
    public BingoTile initialTile;
    public BingoStickerNumeric initialSticker;

    private Vector3 initialPosition;

    void Start()
    {
        bingoSpace = new(positionInGrid, UnityEngine.Random.Range(1,51), initialTile, initialSticker);
        bingoSpace.transform = transform;
        card = transform.GetComponentInParent<BingoCard>();
        card.AddBingoSpace(bingoSpace);
        stickerNumberText.text = bingoSpace.Sticker.Number.ToString();
        descriptionHover = card.GetComponentInChildren<DescriptionHover>();
        initialPosition = transform.position;
    }

    private void Update()
    {
    }

    private void ChangeTile(BingoTile tile)
    {
        bingoSpace.Tile = tile;
    }
    

    private void OnMouseDown()
    {
        if (!Utils.BingoCard.ConstructionMode)
        {
            card.MarkSpace(positionInGrid);
            ChangeLooks(bingoSpace.State);
            return;
        }
        if (Utils.BingoCard.ConstructionMode)
        {
            Utils.Rewards.boughtItems++;
            if (Utils.Rewards.Selected is BingoStickerNumeric rewardSticker)
            {
                card.ReplaceAt(positionInGrid, rewardSticker);
            }
            else if (Utils.Rewards.Selected is BingoTile rewardTile)
            {
                card.ReplaceAt(positionInGrid, rewardTile);
                GetComponent<SpriteRenderer>().sprite = rewardTile.sprite;
            }
            Utils.Rewards.ToggleHide();
        }

    }

    public void ChangeLooks(MarkState state)
    {
        switch (state)
        {
            case MarkState.Marked:
                GetComponent<SpriteRenderer>().color = markedColor;
                transform.position = initialPosition + Vector3.down * .2f;
                break;
            case MarkState.Unmarked:
                GetComponent<SpriteRenderer>().color = Color.white;
                transform.position = initialPosition;
                break;
        }
    }

    public BingoSpace GetSpace()
    {
        return bingoSpace;
    }

    private void OnMouseEnter()
    {
        descriptionHover.ShowHover(tile, sticker);
    }

    private void OnMouseExit()
    {
        descriptionHover.UnShowHover();
    }
}
