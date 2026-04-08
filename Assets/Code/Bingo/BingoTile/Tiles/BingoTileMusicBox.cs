using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMusicBox", menuName = "Bingo/Tiles/BingoTileMusicBox")]
public class BingoTileMusicBox : BingoTile, IMarkable, IFlammable, IMusicable
{
    private bool burnt = false;

    public void Mark()
    {
        if (burnt)
            PlayNote();
        else
        {
            BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
            Vector2 thisTilePos = GetSpace().GetPosition();
            ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

            sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
        }
    }
    public void PlayNote()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        int nextMusicValue = (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1;

        bc.SetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY,nextMusicValue);

        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + nextMusicValue);
    }

    public void OnFlame()
    {
        burnt = true;
        Mark();
        PlayNote();
    }

    public void PostFlame()
    {
    }

    public void PreFlame()
    {
    }

    public void Spread()
    {
        Utils.Spread(this);
    }
}
