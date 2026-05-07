using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileVolcano", menuName = "Bingo/Tiles/Volcano")]
public class BingoTileVolcano : BingoTile, IMarkable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        (Utils.GetRandomUnmarkedTyped<IFlammable>().GetTile() as IFlammable)?.OnFlame();

    }
}
