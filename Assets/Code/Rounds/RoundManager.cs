using UnityEngine;

public class RoundManager : CustomService
{
    public Round ActualRound;
    private int roundNum = 0;

    [SerializeField]
    private int ballQuantity = 20;

    [SerializeField]
    private float wid = 0.1f;
    [SerializeField]
    private float amp = 25;
    public bool RoundActive { get { return Utils.BingoDrum.GetComponent<BingoDrumHelper>().RoundActive;  } }

    private void Awake()
    {
        ServiceLocator.AddService<RoundManager>(this);
    }

    private void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        if (ActualRound == null)
        {
            ActualRound = new Round(0,0);
        }
        ActualRound.pointsToWin = CalculateRoundPoints();
        ActualRound.ballsQuantity = 20;

        ActualRound.StartRound();

        Utils.BingoDrum.gameObject.GetComponent<BingoDrumHelper>().RoundActive = true;

        //ActualizarHover
        Utils.BingoCard.hover.UpdateHoverObjetive(ActualRound.pointsToWin);
        Utils.BingoDrum.BallHolderHover.UpdateHoverRound(roundNum);
    }

    public void NextRound()
    {
        roundNum++;
        StartRound();
    }

    public int CalculateRoundPoints()
    {
        //float exponent = Mathf.Log(roundNum, 25);
        //float num = Mathf.Cos(roundNum * wid) * amp + roundNum;
        return Mathf.RoundToInt((roundNum + 1) * 1.5f);
    }

    public int CalculateRoundBalls()
    {
        return ballQuantity;
    }
}
