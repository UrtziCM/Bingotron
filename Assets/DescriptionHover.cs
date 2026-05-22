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
    private TextMeshProUGUI stickerName;
    [SerializeField]
    private TextMeshProUGUI stickerDescription;

    [Header("Description hover")]
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
        stickerDescription.text = sticker.Description;
    }

    public void UnShowDescriptionHover()
    {
        DescriptionHover.SetActive(false);

        tileName.text = "";
        tileDescription.text = "";

        stickerName.text = "";
        stickerDescription.text = "";

        StatsHover.SetActive(true);
    }

    public void UpdateHoverRound(float roundNum, float objetive)
    {
        roundNumbers.text = (roundNum + 1).ToString() + "\n" + objetive.ToString();
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
