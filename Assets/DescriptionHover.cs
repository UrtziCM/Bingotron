using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DescriptionHover : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tileName;
    [SerializeField]
    private TextMeshProUGUI tileDescription;

    public void ShowHover(BingoTile tile)
    {
        tileName.text = tile.Name;
        tileDescription.text = tile.Description;
    }
}
