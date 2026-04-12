using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCriticalHit", menuName = "Bingo/Tiles/CriticalHit")]
public class BingoTileCriticalHit : BingoTile, IMarkable, IGamble
{
    public float BaseProbability => 0.05f;

    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (Gamble() ? 100 : 0));
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
