using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileElectricGuitar", menuName = "Bingo/Tiles/BingoTileElectricGuitar")]
public class BingoTileElectricGuitar : BingoTile, IMarkable, IMusicable, IChargeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        Discharge(bc.GetValueFromProperty(BingoCard.CHARGE_PROPERTY));
    }
    public void Discharge(int charge)
    {
        for (int i = 0; i < charge; i++)
        {
            PlayNote();
        }
    }
    public void PlayNote()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        int nextMusicValue = bc.GetValueFromProperty(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1;

        bc.GetPropertyByName(BingoCard.MUSIC_ADDEDVALUE_PROPERTY).SetValue(nextMusicValue);

        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + nextMusicValue);
    }
}
