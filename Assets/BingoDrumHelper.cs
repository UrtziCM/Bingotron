using UnityEngine;

public class BingoDrumHelper : MonoBehaviour
{

    [SerializeField]
    public bool RoundActive = false;
    [SerializeField, Tooltip("Time that a ball remains visible as new and applies its effects."), Range(0f, 10f)]
    private float activeBallTime = 3;
    private BingoDrum drum;

    private float accumulatedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drum = GetComponent<BingoDrum>();
        Utils.BingoCard.OnRoundStart.AddListener(StartRound);
    }

    // Update is called once per frame
    void Update()
    {
        if (!RoundActive)
            return;

        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > activeBallTime)
        {
            accumulatedTime = 0;
            Debug.Log(NextBall().number);
            if (drum.drumQueue.Count == 0) 
            {
                RoundActive = false;
            }
        }

    }

    public void StartRound()
    {
        drum.ShuffledListIntoQueue();
        RoundActive = true;
        activeBallTime = 3;
    }

    public BingoBall NextBall()
    {
        AddBallToRolledBoard(drum.currentBingoBall);
        BingoBall b = drum.GetNextBall();


        return b;
    }

    private void AddBallToRolledBoard(BingoBall ball)
    {

    }
}
