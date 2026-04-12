using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileReverb", menuName = "Bingo/Tiles/Reverb")]
public class BingoTileReverb : BingoTile, IMarkable, IMusicable
{
    string musicProperty = BingoCard.MUSIC_ADDEDVALUE_PROPERTY;

    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        bc.SetPropertyValue(musicProperty, bc.GetPropertyValue(musicProperty) + bc.GetAllSpacesOfType<IMusicable>().Length);

        PlayNote();

        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(musicProperty));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}
