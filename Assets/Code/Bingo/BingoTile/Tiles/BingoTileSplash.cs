using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BingoTileSplash", menuName = "Bingo/Tiles/Splash")]
public class BingoTileSplash : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        List<IPermeable> permeableList = new List<IPermeable>();

        foreach (BingoSpace bt in bc.GetAllSpacesOfType<IPermeable>())
        {
            permeableList.Add(bt as IPermeable);
        }

        permeableList[Random.Range(0, permeableList.Count)].Wet();

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}