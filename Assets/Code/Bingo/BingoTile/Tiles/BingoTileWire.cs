using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWire", menuName = "Bingo/Tiles/Wire")]
public class BingoTileWire : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY ,bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + 1);

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
