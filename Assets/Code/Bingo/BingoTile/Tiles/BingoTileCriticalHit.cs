using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCriticalHit", menuName = "Bingo/Tiles/CriticalHit")]
public class BingoTileCriticalHit : BingoTile, IMarkable, IGamble
{
    public float BaseProbability => 0.05f;

    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        sm.AddScore(value + GetSpace().GetSticker().value + (Gamble() ? 100 : 0));
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
