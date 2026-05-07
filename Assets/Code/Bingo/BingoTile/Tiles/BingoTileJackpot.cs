using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJackpot", menuName = "Bingo/Tiles/Jackpot")]
public class BingoTileJackpot : BingoTile, IMarkable, IGamble
{
    public float BaseProbability => 0.5f;

    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        if(Gamble())
            sm.AddScore(sm.Score);
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
