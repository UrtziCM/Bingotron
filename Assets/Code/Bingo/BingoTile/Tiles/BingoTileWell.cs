using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BingoTileWell", menuName = "Bingo/Tiles/BingoTileWell")]
public class BingoTileWell : BingoTile, IMarkable, IGamble, IPermeable
{
    public float BaseProbability => 0.2f;

    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void Wet()
    {
        if (Gamble())
        {
            BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

            List<BingoSpace> permeableSpaces = new List<BingoSpace>(bc.GetAllSpacesOfType<IPermeable>());

            int wetCount = 0;

            while (permeableSpaces.Count > 0 && wetCount < 2)
            {
                int i = Random.Range(0, permeableSpaces.Count);

                if (permeableSpaces[i].GetTile() == this)
                {
                    permeableSpaces.RemoveAt(i);
                    continue;
                }

                if (permeableSpaces[i].GetTile() is IPermeable tile)
                { 
                    tile.Wet();
                    wetCount++;
                }
            }
        }
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
