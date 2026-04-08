using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBank", menuName = "Bingo/Tiles/BingoTileBank")]
public class BingoTileBank : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        float moneyValue = bc.GetPropertyValue(BingoCard.MONEY_PROPERTY) /3;
        
        this.value = (int)moneyValue;
    
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
