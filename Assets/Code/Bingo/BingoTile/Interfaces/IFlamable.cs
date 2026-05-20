using UnityEngine;

public interface IFlammable
{
    public bool burning {  get; set; }
    public void PreFlame();
    public void OnFlame();
    public void PostFlame();
    public void Spread();
}
