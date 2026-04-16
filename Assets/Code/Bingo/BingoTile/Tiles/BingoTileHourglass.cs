using UnityEngine;

public class BingoTileHourglass : BingoTile, IMarkable, IRoller
{
    [SerializeField]
    private int basevalue;
    [SerializeField]
    private int substractedValue;
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();
        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void OnRoll(BingoBall ball)
    {
        value = Mathf.Clamp(value - substractedValue, 0, int.MaxValue);
    }

    //falta que all empezar una ronda se resetee
}
