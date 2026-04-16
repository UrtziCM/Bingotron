using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBank", menuName = "Bingo/Tiles/Bank")]
public class BingoTileBank : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = Utils.ScoreManager;

        float moneyValue = bc.GetPropertyValue(BingoCard.MONEY_PROPERTY) /3;
        
        this.value = (int)moneyValue;
    
        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
