using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStrawLoft", menuName = "Bingo/Tiles/StrawLoft")]
public class BingoTileStrawLoft : BingoTile, IMarkable, IFlammable, IGamble
{
    public float BaseProbability => 0.3f;

    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        if (Gamble())
            sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + 10);
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
