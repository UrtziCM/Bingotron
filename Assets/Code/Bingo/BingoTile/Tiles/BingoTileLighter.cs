using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileLighter", menuName = "Bingo/Tiles/Lighter")]
public class BingoTileLighter : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        OnFlame();

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void OnFlame()
    {
    }

    public void PostFlame(){}
    
    public void PreFlame(){}
}
