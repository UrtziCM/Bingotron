using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BingoTileFireStorm", menuName = "Bingo/Tiles/FireStorm")]
public class BingoTileFireStorm : BingoTile, IMarkable, ICasteable
{
    public int LowManaCost => 10;
    public int MidManaCost => 0;
    public int HighManaCost => 0;
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = Utils.ScoreManager;

        Cast((int)bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY));

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
    public void Cast(int mana)
    {
        BingoCard bc = GetSpace().GetCard();

        List<BingoSpace> allSpaces = new List<BingoSpace>(bc.GetAllSpacesOfType<BingoSpace>());

        while (mana >= LowManaCost && allSpaces.Count > 0)
        {
            int i = Random.Range(0, allSpaces.Count);

            if (allSpaces[i].GetTile() is IFlammable tile)
                tile.OnFlame(); //no se si quema lo que ya estaba quemado

            allSpaces.RemoveAt(i);

            mana -= LowManaCost;
            bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana);
        }
    }
}
