using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileVolcano", menuName = "Bingo/Tiles/BingoTileVolcano")]
public class BingoTileVolcano : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        (bc.GetRandomSpaceOfType<IFlammable>() as IFlammable)?.OnFlame();

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
