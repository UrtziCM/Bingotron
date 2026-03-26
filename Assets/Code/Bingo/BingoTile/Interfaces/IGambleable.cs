using UnityEngine;

public interface IGambleable 
{
    public float baseProbability {  get; }
    public float probability {  get; }
    public void UpgradeProbability(float cuantity);
    public void ResetProbability();
    public bool Gamble();
}
