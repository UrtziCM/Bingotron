using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileDrumSet", menuName = "Bingo/Tiles/DrumSet")]
public class BingoTileDrumSet : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        PlayNote();

        foreach (BingoSpace space in bc.GetAllSpacesOfType<BingoSpace>())
        {
            if (space.GetTile() is BingoTileDrum drum)
            {
                drum.PlayNote();
            }
        }

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}