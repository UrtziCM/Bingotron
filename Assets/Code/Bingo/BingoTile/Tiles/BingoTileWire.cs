using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileDrum", menuName = "Bingo/Tiles/BingoTileDrum")]
public class BingoTileWire : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY ,bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + 1);

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
