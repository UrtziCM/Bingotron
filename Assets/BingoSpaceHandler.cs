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

    private Hover hover;
    [Header("Initial configuration")]
    public BingoTile initialTile;
    public BingoStickerNumeric initialSticker;

    private Vector3 initialPosition;

    private bool mouseEntered;

    void Awake()
    {
        bingoSpace = new(positionInGrid, UnityEngine.Random.Range(1,51), initialTile, initialSticker);
        bingoSpace.transform = transform;
        card = transform.GetComponentInParent<BingoCard>();
        card.AddBingoSpace(bingoSpace);
        stickerNumberText.text = bingoSpace.Sticker.Number.ToString();
        hover = card.GetComponentInChildren<Hover>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (mouseEntered)
            OnShowHover();
    }

    private void ChangeTile(BingoTile tile)
    {
        bingoSpace.Tile = tile;
    }
    

    private void OnMouseDown()
    {
        if (!Utils.BingoCard.ConstructionMode && Utils.RoundManager.RoundActive)
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
                stickerNumberText.color = rewardSticker.textColor;
                stickerNumberText.text = rewardSticker.Number.ToString();
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
        mouseEntered = true;
    }
    private void OnMouseExit()
    {
        mouseEntered = false;
    }

    private void OnShowHover()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hover.ShowDescriptionHover(tile, sticker);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            hover.UnShowDescriptionHover();
        }
    }
}
