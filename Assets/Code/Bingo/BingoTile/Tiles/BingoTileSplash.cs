using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BingoTileSplash", menuName = "Bingo/Tiles/BingoTileSplash")]
public class BingoTileSplash : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        List<IPermeable> permeableList = new List<IPermeable>();

        foreach (BingoSpace bt in bc.AllTiles())
        {
            if (bt.GetTile() is IPermeable tile)
                permeableList.Add(tile);
        }

        permeableList[Random.Range(0, permeableList.Count)].Wet();

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}