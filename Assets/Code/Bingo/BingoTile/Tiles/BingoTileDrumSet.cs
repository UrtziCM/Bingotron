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
            (space.Tile as BingoTileDrum).PlayNote();
        }

        sm.AddScore((int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}