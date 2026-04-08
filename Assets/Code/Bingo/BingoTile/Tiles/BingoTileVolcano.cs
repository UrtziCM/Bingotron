using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileVolcano", menuName = "BingoTiles/BingoTileVolcano")]
public class BingoTileVolcano : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        List<IFlammable> permeableList = new List<IFlammable>();

        foreach (BingoSpace bt in bc.AllTiles())
        {
            if (bt.GetTile() is IFlammable tile)
                permeableList.Add(tile);
        }

        permeableList[Random.Range(0, permeableList.Count)].OnFlame();

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
