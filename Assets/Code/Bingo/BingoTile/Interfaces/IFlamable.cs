using UnityEngine;

public interface IFlamable
{
    public void PreFlame();
    public void OnFlame();
    public void PostFlame();
    public void Spread();
}
