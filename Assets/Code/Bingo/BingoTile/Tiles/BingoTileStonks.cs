using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStonks", menuName = "Bingo/Tiles/Stonks")]
public class BingoTileStonks : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        value = (int)bc.GetPropertyValue(BingoCard.MONEY_PROPERTY);

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
