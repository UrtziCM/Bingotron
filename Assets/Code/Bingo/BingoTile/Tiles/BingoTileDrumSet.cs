using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileDrumSet", menuName = "Bingo/Tiles/DrumSet")]
public class BingoTileDrumSet : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        PlayNote();

        foreach (BingoSpace space in bc.GetAllSpacesOfType<BingoTileDrum>())
        {
            (space.GetTile() as BingoTileDrum).PlayNote();
        }

        sm.AddScore(value + GetSpace().GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}