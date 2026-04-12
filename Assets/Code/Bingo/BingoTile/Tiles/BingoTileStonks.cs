using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStonks", menuName = "Bingo/Tiles/Stonks")]
public class BingoTileStonks : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        value = (int)bc.GetPropertyValue(BingoCard.MONEY_PROPERTY);

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
