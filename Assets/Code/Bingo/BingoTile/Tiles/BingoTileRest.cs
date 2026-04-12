using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileRest", menuName = "Bingo/Tiles/Rest")]
public class BingoTileRest : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + 50);

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
