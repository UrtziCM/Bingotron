using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStrawLoft", menuName = "Bingo/Tiles/StrawLoft")]
public class BingoTileStrawLoft : BingoTile, IMarkable, IFlammable, IGamble
{
    public float BaseProbability => 0.3f;

    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        if (Gamble())
            sm.AddScore(value + GetSpace().GetNumber().value + 10);
    }

    public void OnFlame()
    {
        Mark();
    }

    public void PostFlame()
    {
    }

    public void PreFlame()
    {
    }

    public void Spread()
    {
        Utils.Spread(this);
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
