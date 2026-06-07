using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Hover : MonoBehaviour
{
    [Header("Description hover")]
    [SerializeField]
    private GameObject DescriptionHover;
    [SerializeField]
    private TextMeshProUGUI tileName;
    [SerializeField]
    private TextMeshProUGUI tileDescription;
    [SerializeField]
    private Image tileSprite;
    [SerializeField]
    private TextMeshProUGUI tileTag1;
    [SerializeField]
    private Image tagImage1;
    [SerializeField]
    private TextMeshProUGUI tileTag2;
    [SerializeField]
    private Image tagImage2;

    [SerializeField]
    private TextMeshProUGUI stickerName;
    [SerializeField]
    private TextMeshProUGUI stickerNumber;
    [SerializeField]
    private TextMeshProUGUI stickerDescription;

    [Header("Stats hover")]
    [SerializeField]
    private GameObject StatsHover;
    [SerializeField]
    private TextMeshProUGUI roundNumbers;
    [SerializeField]
    private TextMeshProUGUI totalPoints;
    [SerializeField]
    private TextMeshProUGUI tiradaPoints;
    [SerializeField]
    private TextMeshProUGUI multiply;
    [SerializeField]
    private TextMeshProUGUI stats;

    public void ShowDescriptionHover(BingoTile tile, BingoSticker sticker)
    {
        StatsHover.SetActive(false);
        DescriptionHover.SetActive(true);

        tileSprite.sprite = tile.sprite;

        tileName.text = tile.Name;
        tileDescription.text = tile.Description;

        stickerName.text = sticker.Name;

        BingoStickerNumeric numericSticker = sticker as BingoStickerNumeric;
        if (numericSticker != null)
        {
            stickerNumber.text = numericSticker.Number.ToString();
            stickerNumber.color = numericSticker.textColor;
        }
        else
        {
            stickerNumber.text = "";
        }

        stickerDescription.text = sticker.Description;

        if (tile.tags.Length > 0)
        {
            tileTag1.text = BingoTile.TAGS[(int)tile.tags[0]];

            Color c1 = Utils.GetTagColor(tile.tags[0]);
            c1.a = 150f / 255f;
            tagImage1.color = c1;

            if (tile.tags.Length > 1)
            {
                tileTag2.text = BingoTile.TAGS[(int)tile.tags[1]];

                Color c2 = Utils.GetTagColor(tile.tags[1]);
                c2.a = 150f / 255f;
                tagImage2.color = c2;
            }
            else
            {
                tileTag2.text = "";

                Color c = tagImage2.color;
                c.a = 0f;
                tagImage2.color = c;
            }
        }
        else
        {
            tileTag1.text = "";

            Color c1 = tagImage1.color;
            c1.a = 0f;
            tagImage1.color = c1;

            tileTag2.text = "";

            Color c2 = tagImage2.color;
            c2.a = 0f;
            tagImage2.color = c2;
        }
    }
    public void UnShowDescriptionHover()
    {
        DescriptionHover.SetActive(false);

        tileName.text = "";
        tileDescription.text = "";

        stickerName.text = "";
        stickerNumber.text = "";
        stickerDescription.text = "";

        StatsHover.SetActive(true);
    }

    public void UpdateHoverObjetive(float objetive)
    {
        roundNumbers.text = objetive.ToString();
    }
    public void UpdateHoverTotalPoints(float points)
    {
        totalPoints.text = points.ToString();
    }
    public void UpdateHoverPointsMult(float points, float mult)
    {
        tiradaPoints.text = points.ToString();
        multiply.text = mult.ToString();
    }
    public void UpdateHoverStats(float money, float charge, float mana, float gamble, float music)
    {
        stats.text = 
            money.ToString() + "\n" + 
            charge.ToString() + "\n" + 
            mana.ToString() + "\n" + 
            gamble.ToString() + "\n" + 
            music.ToString();
    }
}
