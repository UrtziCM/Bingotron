using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

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
        stickerNumber.text = (sticker as BingoStickerNumeric).Number.ToString();
        stickerNumber.color = (sticker as BingoStickerNumeric).textColor;
        stickerDescription.text = sticker.Description;

        if (tile.tags.Length > 0)
        {
            tileTag1.text = tile.tags[0].ToString();
            tagImage1.color = Utils.GetTagColor(tile.tags[0]).WithAlpha(150);

            if (tile.tags.Length > 1)
            {
                tileTag2.text = tile.tags[1].ToString();
                tagImage2.color = Utils.GetTagColor(tile.tags[1]).WithAlpha(150);
            }
            else
            {
                tileTag2.text = "";
                tagImage2.color = tagImage2.color.WithAlpha(0);
            }
        }
        else
        {
            tileTag1.text = "";
            tagImage1.color = tagImage1.color.WithAlpha(0);
            tileTag2.text = "";
            tagImage2.color = tagImage2.color.WithAlpha(0);
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
