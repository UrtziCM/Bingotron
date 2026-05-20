using System.Collections;
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
        BingoSpace[] spaces = Utils.BingoCard.GetAllSpacesOfType<IFlammable>();
        foreach (BingoSpace space in spaces)
        {
            if (space.Tile is IFlammable tile && tile.burning)
            {
                Debug.Log("Burn");
                Utils.Spread(space.GetPosition());
                tile.burning = false;
                Utils.BingoCard.ForceMark(space);
            }
        }

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
        Debug.Log("Round start");
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
