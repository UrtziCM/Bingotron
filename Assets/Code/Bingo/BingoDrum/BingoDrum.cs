using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BingoDrum : Service
{
    private const int totalNumbers = 90;
    public List<BingoBall> balls = new();
    public Queue<BingoBall> drumQueue = new();
    public BingoBall currentBingoBall;

    private void Init()
    {
        for (int i = 0; i < totalNumbers; i++)
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

    void Start()
    {
        Init();
        ServiceLocator.AddService<BingoDrum>(this);
    }

    public BingoBall PeekNextBall()
    {
        return drumQueue.Peek();
    }

    public BingoBall GetNextBall()
    {
        currentBingoBall = drumQueue.Dequeue();
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
