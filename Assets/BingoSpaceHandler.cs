using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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

    [SerializeField]
    private GameObject descriptionHover;
    private GameObject activeHover;

    void Start()
    {
        bingoSpace = new(positionInGrid, UnityEngine.Random.Range(1,51));
        card = transform.GetComponentInParent<BingoCard>();
        card.AddBingoSpace(bingoSpace);
        stickerNumberText.text = bingoSpace.Sticker.Number.ToString();
    }

    private void Update()
    {
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
            if (Utils.Rewards.Selected is BingoStickerNumeric sticker)
                card.ReplaceAt(positionInGrid, sticker);
            else if (Utils.Rewards.Selected is BingoTile tile)
                card.ReplaceAt(positionInGrid, tile);
            Utils.Rewards.ToggleHide();
            Utils.Rewards.boughtItems++;
        }

    }

    public void ChangeLooks(MarkState state)
    {
        switch (state)
        {
            case MarkState.Marked:
                GetComponent<SpriteRenderer>().color = markedColor;
                break;
            case MarkState.Unmarked:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    public BingoSpace GetSpace()
    {
        return bingoSpace;
    }

    private void OnMouseEnter()
    {
        if (activeHover) Destroy(activeHover);


         activeHover = Instantiate(descriptionHover, transform.position, transform.rotation);

        descriptionHover.GetComponent<DescriptionHover>().ShowHover(tile);
    }

    private void OnMouseExit()
    {
        if (activeHover) Destroy(activeHover);
    }
}
