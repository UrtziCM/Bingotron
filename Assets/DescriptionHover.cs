using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DescriptionHover : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tileName;
    [SerializeField]
    private TextMeshProUGUI tileDescription;

    [SerializeField]
    private TextMeshProUGUI stickerName;
    [SerializeField]
    private TextMeshProUGUI stickerDescription;

    public void ShowHover(BingoTile tile, BingoSticker sticker)
    {
        tileName.text = tile.Name;
        tileDescription.text = tile.Description;

        stickerName.text = sticker.Name;
        stickerDescription.text = sticker.Description;
    }

    public void UnShowHover()
    {
        tileName.text = "";
        tileDescription.text = "";

        stickerName.text = "";
        stickerDescription.text = "";
    }
}
