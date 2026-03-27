using UnityEngine;

public interface IGamble 
{
    public float BaseProbability {  get; }
    public bool Gamble();
}
