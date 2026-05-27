using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    [SerializeField] private GameObject tooltipPanel;
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private RectTransform canvasRect;

    private void Awake()
    {
        Instance = this;
        tooltipPanel.SetActive(false);
    }

    private void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            Vector2 localPoint;
            //mueve el tooltipText a la posicion del raton
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                Input.mousePosition,
                null,
                out localPoint
            );
            tooltipPanel.GetComponent<RectTransform>().anchoredPosition = localPoint + new Vector2(15, -15);
        }
    }

    public void ShowTooltip(string text)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = text;
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}