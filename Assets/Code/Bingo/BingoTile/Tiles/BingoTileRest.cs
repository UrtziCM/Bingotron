using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileRest", menuName = "Bingo/Tiles/Rest")]
public class BingoTileRest : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + 50);

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
