using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BingoDrumHelper : MonoBehaviour
{

    [SerializeField]
    public bool RoundActive = false;
    [SerializeField, Tooltip("Time that a ball remains visible as new and applies its effects."), Range(0f, 10f)]
    private float activeBallTime = 3;
    private BingoDrum drum;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Transform ballSpawnpos;
    [SerializeField]
    private Transform ballTargetPos;

    private BallHolder ballHolder;

    private float accumulatedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool droppedBall;

    [SerializeField]
    private Animator drumAnimator;
    private void Awake()
    {
        Utils.BingoCard.OnRoundStart.AddListener(StartRound);
        drum = GetComponent<BingoDrum>();
        ballHolder = GetComponentInChildren<BallHolder>();
        
    }


    void Start()
    {
        StartCoroutine(PlayDrumRoll());
    }

    public void Drop()
    {
        droppedBall = true;
    }

    private IEnumerator PlayDrumRoll()
    {
        yield return new WaitForSeconds(2f);

        if (!RoundActive)
        {
            droppedBall = true;
            yield break; 
        }


        drumAnimator.SetTrigger("Roll");

        List<BingoSpace> spaces = new(Utils.BingoCard.GetAllSpacesOfType<IFlammable>());

        List<BingoSpace> spaceToSpread = new();


        if (Utils.ScoreManager.totalScore >= Utils.RoundManager.ActualRound.pointsToWin)
        {
            foreach (BingoSpace space in spaces)
            {
                if (space.Tile is IFlammable tile)
                {
                    tile.burning = false;
                }
            }

            spaceToSpread.Clear();
            spaces.Clear();
        }

        foreach (BingoSpace space in spaces)
        {
            if (space.Tile is IFlammable tile && tile.burning)
            {
                spaceToSpread.Add(space);
            }
        }
        foreach (BingoSpace space in spaceToSpread)
        {
            if (space.Tile is IFlammable tile && tile.burning)
            {
                Debug.Log("Burn");
                Utils.Spread(space.GetPosition());
                tile.burning = false;
                Utils.BingoCard.ForceMark(space);
            }
        }

        spaces.Clear();
        spaceToSpread.Clear();
        

        yield return new WaitForSeconds(1f);
        //Sonido de roll
        Utils.AudioManager.PlayDrumRoll();

    }

    // Update is called once per frame
    void Update()
    {
        if (!RoundActive)
            return;

        accumulatedTime += Time.deltaTime;
        //if (accumulatedTime > activeBallTime)
        if (droppedBall)
        {
            droppedBall = false;
            StartCoroutine(PlayDrumRoll());
            NextBall();
            if (drum.drumQueue.Count == 0) 
            {
                RoundActive = false;
            }
        }

    }

    public void StartRound()
    {
        drum.ShuffledListIntoQueue();
        ballHolder.ClearHolder();
        RoundActive = true;
    }

    public BingoBall NextBall()
    {
        AddBallToRolledBoard(drum.currentBingoBall);
        BingoBall b = drum.GetNextBall();

        GameObject spawnedBall = Instantiate(ball, ballSpawnpos);
        spawnedBall.GetComponentInChildren<TMP_Text>().text = b.number.ToString();
        StartCoroutine(MoveBallTowards(spawnedBall.transform, b.number));
        return b;
    }

    private void AddBallToRolledBoard(BingoBall ball)
    {

    }


    private IEnumerator MoveBallTowards(Transform ball, int ballNum)
    {
        //Sonido de roll
        Utils.AudioManager.StopDrumRoll();
        Utils.AudioManager.PlaySFX(Utils.AudioManager.ballSound);

        while (Vector3.Distance(ball.position, ballTargetPos.position) > 0.01f)
        {
            ball.position = Vector3.MoveTowards(
                ball.position,
                ballTargetPos.position,
                3 * Time.deltaTime
            );

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        ballHolder.PlaceBall(ball, ballNum);
    }
}
