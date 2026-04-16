using System.Collections.Generic;
using System.Linq;
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
        
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < TOTAL_NUMBERS; i++)
        {
            var ball = new BingoBall();
            ball.number = i;
            balls.Add(ball);
        }
    }

    public void ShuffledListIntoQueue()
    {
        drumQueue.Clear();
        List<BingoBall> disposableCopy = new(balls);
        for (int i = Random.Range(0, disposableCopy.Count); disposableCopy.Count > 0; i = Random.Range(0, disposableCopy.Count))
        {
            var disposable = disposableCopy[i];
            drumQueue.Enqueue(disposable);
            disposableCopy.Remove(disposable);
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
