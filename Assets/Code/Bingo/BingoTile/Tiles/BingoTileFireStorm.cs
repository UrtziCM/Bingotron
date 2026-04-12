using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BingoTileFireStorm", menuName = "Bingo/Tiles/BingoTileFireStorm")]
public class BingoTileFireStorm : BingoTile, IMarkable, ICasteable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Cast((int)bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY));

        sm.AddScore( value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
    public void Cast(int mana)
    {
        BingoCard bc = GetSpace().GetCard();

        List<BingoSpace> allSpaces = new List<BingoSpace>(bc.GetAllSpacesOfType<BingoSpace>());

        while (mana >= 10 && allSpaces.Count > 0)
        {
            int i = Random.Range(0, allSpaces.Count);

            if (allSpaces[i].GetTile() is IFlammable tile)
                tile.OnFlame(); //no se si quema lo que ya estaba quemado

            allSpaces.RemoveAt(i);

            mana--;
            bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana);
        }
    }
}
