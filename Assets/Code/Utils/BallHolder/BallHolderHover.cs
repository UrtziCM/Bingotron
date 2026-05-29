using TMPro;
using UnityEngine;

public class BallHolderHover : MonoBehaviour
{
    [SerializeField]
    private TMP_Text roundNum;
    [SerializeField]
    private TMP_Text leftBalls;

    public void UpdateHoverRound(int round)
    {
        roundNum.text = "RONDA " + (round + 1).ToString();
    }
    public void UpdateHoverBalls(int ballsLeft)
    {
        leftBalls.text = ballsLeft.ToString();
    }
}
