using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BingoDrum : CustomService
{
    private const int TOTAL_NUMBERS = 90;
    public List<BingoBall> balls = new();
    public Queue<BingoBall> drumQueue = new();
    public List<BingoBall> droppedBalls = new();
    public BingoBall currentBingoBall;




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
        drumQueue.Clear();
        List<BingoBall> disposableCopy = new List<BingoBall>(balls);

        foreach (BingoBall currentBall in disposableCopy.OrderBy(x => UnityEngine.Random.Range(0, 90))) {
            drumQueue.Enqueue(currentBall);
        }
        
    }

    public BingoBall PeekNextBall()
    {
        return drumQueue.Peek();
    }

    public BingoBall GetNextBall()
    {
        currentBingoBall = drumQueue.Dequeue();
        droppedBalls.Add(currentBingoBall);
        Utils.BingoCard.OnBallRolled.Invoke(currentBingoBall);

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
