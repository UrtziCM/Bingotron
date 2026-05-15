using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BingoDrum : CustomService
{
    private const int TOTAL_NUMBERS = 50;
    public List<BingoBall> balls = new();
    public Queue<BingoBall> drumQueue = new();
    public List<BingoBall> droppedBalls = new();
    public BingoBall currentBingoBall;

    public UnityEvent OnRollBall;
    public UnityEvent<BingoBall> OnBallEffectStart;
    public UnityEvent<BingoBall> OnBallEffectEnd;


    private void Awake()
    {
        ServiceLocator.AddService<BingoDrum>(this);
        Init();


    }

    void Start()
    {
    }

    private void Init()
    {
        for (int i = 1; i <= TOTAL_NUMBERS; i++)
        {
            BingoBall ball = new BingoBall();
            ball.number = i;
            balls.Add(ball);
        }
    }

    public void ShuffledListIntoQueue()
    {
        Debug.Log(balls.Count);
        droppedBalls.Clear();
        drumQueue.Clear();
        List<BingoBall> disposableCopy = new List<BingoBall>(balls);

        foreach (BingoBall currentBall in disposableCopy.OrderBy(x => UnityEngine.Random.Range(0, TOTAL_NUMBERS))) {
            drumQueue.Enqueue(currentBall);
        }
        
    }

    public BingoBall PeekNextBall()
    {
        return drumQueue.Peek();
    }

    public BingoBall GetNextBall()
    {
        OnBallEffectEnd?.Invoke(currentBingoBall);
        
        currentBingoBall = drumQueue.Dequeue();
        droppedBalls.Add(currentBingoBall);
        Utils.BingoCard.OnBallRolled?.Invoke(currentBingoBall);

        OnBallEffectStart?.Invoke(currentBingoBall);
        OnRollBall?.Invoke();
        return currentBingoBall;
    }

    private BingoBall GetBallByNumber(int number)
    {
        return balls.Where((ball) => ball.number == number).FirstOrDefault(null);
    }

    public void ReplaceBall(int number, BingoBall ball)
    {
        balls.RemoveAt(number);
        balls.Add(ball);
        balls.Sort((ballA, ballB) => { return ballA.number.CompareTo(ballB.number); });
    }


}
