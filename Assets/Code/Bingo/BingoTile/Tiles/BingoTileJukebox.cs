using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJukebox", menuName = "Bingo/Tiles/BingoTileJukebox")]
public class BingoTileJukebox : BingoTile, IMarkable, IGamble, IMusicable
{
    public float BaseProbability => 0.2f;

    public void Mark()
    {
        PlayNote();
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }

    public void PlayNote()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        int nextMusicValue = (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1;

        bc.SetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY, nextMusicValue);

        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + nextMusicValue);

        while (Gamble()) // && cuando se pasa de tirada
        {
            nextMusicValue = (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1;

            bc.SetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY, nextMusicValue);

            sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + nextMusicValue);
        }
    }
}
