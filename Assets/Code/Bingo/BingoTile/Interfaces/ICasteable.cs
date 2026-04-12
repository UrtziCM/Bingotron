using UnityEngine;

public interface ICasteable
{
    public int LowManaCost { get;}
    public int MidManaCost { get;}
    public int HighManaCost { get;}
    public void Cast(int mana);
}
