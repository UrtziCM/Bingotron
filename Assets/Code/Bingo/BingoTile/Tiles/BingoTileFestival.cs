using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFestival", menuName = "Bingo/Tiles/Festival")]
public class BingoTileFestival : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        PlayNote();

        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        bc.SetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY, 
            (bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 5) * 2);
    }
}
