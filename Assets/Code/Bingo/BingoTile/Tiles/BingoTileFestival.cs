using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFestival", menuName = "Bingo/Tiles/Festival")]
public class BingoTileFestival : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        PlayNote();

        BingoCard bc = Utils.BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();

        sm.AddScore(value + GetSpace().GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        BingoCard bc = Utils.BingoCard;

        bc.SetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY, 
            (bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 5) * 2);
    }
}
