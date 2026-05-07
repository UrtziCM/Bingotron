using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileElectricGuitar", menuName = "Bingo/Tiles/ElectricGuitar")]
public class BingoTileElectricGuitar : BingoTile, IMarkable, IMusicable, IChargeable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard;

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
        BingoCard bc = Utils.BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();

        sm.AddScore((int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }
}
