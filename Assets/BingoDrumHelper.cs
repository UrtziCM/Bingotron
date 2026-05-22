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
    private TMP_Text currentBallTextMesh;

    private float accumulatedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool droppedBall;

    [SerializeField]
    private Animator drumAnimator;
    private void Awake()
    {
        Utils.BingoCard.OnRoundStart.AddListener(StartRound);
        drum = GetComponent<BingoDrum>();
        
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
        yield return new WaitForSeconds(1f);
        drumAnimator.SetTrigger("Roll");

        List<BingoSpace> spaces = new(Utils.BingoCard.GetAllSpacesOfType<IFlammable>());

        List<BingoSpace> spaceToSpread = new();


        if (Utils.ScoreManager.Score >= Utils.RoundManager.ActualRound.pointsToWin)
        {
            Debug.Log("ola");
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
        RoundActive = true;
    }

    public BingoBall NextBall()
    {
        AddBallToRolledBoard(drum.currentBingoBall);
        BingoBall b = drum.GetNextBall();

        currentBallTextMesh.text = b.number.ToString();
        return b;
    }

    private void AddBallToRolledBoard(BingoBall ball)
    {

    }
}
