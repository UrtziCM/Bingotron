using UnityEngine;

public interface IFlammable
{
    public void PreFlame();
    public void OnFlame();
    public void PostFlame();
    public void Spread();
}
