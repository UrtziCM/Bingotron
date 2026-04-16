using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileReverb", menuName = "Bingo/Tiles/Reverb")]
public class BingoTileReverb : BingoTile, IMarkable, IMusicable
{
    string musicProperty = BingoCard.MUSIC_ADDEDVALUE_PROPERTY;

    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;

        bc.SetPropertyValue(musicProperty, bc.GetPropertyValue(musicProperty) + bc.GetAllSpacesOfType<IMusicable>().Length);

        PlayNote();

        ScoreManager sm = Utils.ScoreManager;
        sm.AddScore(value + GetSpace().GetNumber().value + (int)bc.GetPropertyValue(musicProperty));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}
