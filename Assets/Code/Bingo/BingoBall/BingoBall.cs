using UnityEngine;

public class BingoBall
{
    public int number;
    public bool isActive;
    public virtual void Roll() {}
    public virtual bool IsActive()
    { 
        return isActive;
    }
    public virtual void Line() {}
    public virtual void Bingo() {}

}
