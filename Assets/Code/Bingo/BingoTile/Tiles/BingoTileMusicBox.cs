using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMusicBox", menuName = "BingoTiles/BingoTileMusicBox")]
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

            sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + bc.GetValueFromProperty("music"));
        }
    }
    public void PlayNote()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        int nextMusicValue = bc.GetValueFromProperty("music") + 1;

        bc.GetPropertyByName("music").SetValue(nextMusicValue);

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
        ExtraMethods.Spread(this);
    }
}
