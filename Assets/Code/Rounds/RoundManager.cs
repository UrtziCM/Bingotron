using UnityEngine;

public class RoundManager : CustomService
{
    public Round ActualRound;
    private int roundNum;

    [SerializeField]
    private int ballQuantity = 20;

    [SerializeField]
    private float wid = 0.1f;
    [SerializeField]
    private float amp = 25;

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
        ActualRound = new Round(CalculateRoundPoints(), CalculateRoundBalls());
        Utils.BingoCard.ResetCard();
    }

    public void NextRound()
    {
        roundNum++;
        StartRound();
    }

    public int CalculateRoundPoints()
    {
        return (int)(Mathf.Pow((Mathf.Cos(roundNum * wid) * amp + roundNum), Mathf.Log(roundNum, 250)));
    }

    public int CalculateRoundBalls()
    {
        return ballQuantity;
    }
}
