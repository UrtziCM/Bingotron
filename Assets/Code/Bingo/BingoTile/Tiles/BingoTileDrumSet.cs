using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileDrumSet", menuName = "Bingo/Tiles/DrumSet")]
public class BingoTileDrumSet : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        PlayNote();

        foreach (BingoSpace space in bc.GetAllSpacesOfType<BingoTileDrum>())
        {
            (space.GetTile() as BingoTileDrum).PlayNote();
        }

        sm.AddScore(value + GetSpace().GetSticker().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}