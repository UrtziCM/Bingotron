using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBanco", menuName = "BingoTiles/BingoTileBanco ")]
public class BingoTileBanco : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        float moneyValue = bc.GetValueFromProperty("money") /3;
        
        this.value = (int)moneyValue;
    
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
