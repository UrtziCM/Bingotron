using UnityEngine;

public class RoundManager : CustomService
{
    public Round ActualRound;
    private int roundNum;

    [SerializeField]
    private int ballQuantity;

    [SerializeField]
    private float f = 2;
    [SerializeField]
    private float b = 2;
    [SerializeField]
    private float a = 2;
    [SerializeField]
    private float s = 2;

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
    }

    public void NextRound()
    {
        roundNum++;
        StartRound();
    }

    public int CalculateRoundPoints()
    {
        return 2;
            //(int)((Mathf.Cos(roundNum * f) / b) + (roundNum / a) + s);
    }

    public int CalculateRoundBalls()
    {
        return ballQuantity;
    }
}
