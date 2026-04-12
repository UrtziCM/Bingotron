using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileVolcano", menuName = "Bingo/Tiles/Volcano")]
public class BingoTileVolcano : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        (Utils.GetRandomUnmarkedTyped<IFlammable>().GetTile() as IFlammable)?.OnFlame();

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
