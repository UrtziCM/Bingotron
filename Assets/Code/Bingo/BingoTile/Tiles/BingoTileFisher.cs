using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFisher", menuName = "BingoTiles/BingoTileFisher")]
public class BingoTileFisher : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void Wet()
    {
        value++;
    }
}
