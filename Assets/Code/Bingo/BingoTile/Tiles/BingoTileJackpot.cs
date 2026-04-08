using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJackpot", menuName = "Bingo/Tiles/BingoTileJackpot")]
public class BingoTileJackpot : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        if (Random.Range(0, 100) > 50)
            sm.AddScore(sm.Score);
        else
            sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
