using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileVolcano", menuName = "Bingo/Tiles/Volcano")]
public class BingoTileVolcano : BingoTile, IMarkable
{
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        (Utils.GetRandomUnmarkedTyped<IFlammable>().GetTile() as IFlammable)?.OnFlame();

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
