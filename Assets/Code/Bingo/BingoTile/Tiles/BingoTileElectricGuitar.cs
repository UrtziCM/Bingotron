using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileElectricGuitar", menuName = "Bingo/Tiles/ElectricGuitar")]
public class BingoTileElectricGuitar : BingoTile, IMarkable, IMusicable, IChargeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        Discharge((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));
    }
    public void Discharge(int charge)
    {
        for (int i = 0; i < charge; i++)
        {
            PlayNote();
            AddPoints();
        }
    }
    public void PlayNote()
    {
        Utils.PlayNote();
    }
    private void AddPoints()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }
}
