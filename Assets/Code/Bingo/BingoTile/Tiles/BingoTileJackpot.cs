using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJackpot", menuName = "Bingo/Tiles/BingoTileJackpot")]
public class BingoTileJackpot : BingoTile, IMarkable, IGamble
{
    public float BaseProbability => 0.5f;

    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);

        if(Gamble())
            sm.AddScore(sm.Score);
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
