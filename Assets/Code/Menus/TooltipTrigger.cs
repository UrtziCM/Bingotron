using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    [TextArea]
    [SerializeField] public string tooltipMessage = "texto aqui";

    private void OnMouseEnter()
    {
        TooltipController.Instance.ShowTooltip(tooltipMessage);
    }

    private void OnMouseExit()
    {
        TooltipController.Instance.HideTooltip();
    }
}
