using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBase", menuName = "BingoTiles/BingoTileBase")]
public class BingoTileBase : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
