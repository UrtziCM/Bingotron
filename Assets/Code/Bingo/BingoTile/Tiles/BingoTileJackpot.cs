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

        sm.AddScore(Gamble() ? sm.Score : value + bc.GetSpaceAt(thisTilePos).GetNumber().value);

        bc.GetProperty(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY).SetValue(bc.GetPropertyValue(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY) + 0.01f);
    }
    public bool Gamble()
    {
        BingoCard bc = GetSpace().GetCard();

        return Random.Range(0, 1) > BaseProbability + bc.GetPropertyValue(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY);
    }
}
