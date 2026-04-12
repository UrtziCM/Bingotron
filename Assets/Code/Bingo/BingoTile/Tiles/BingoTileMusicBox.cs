using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMusicBox", menuName = "Bingo/Tiles/MusicBox")]
public class BingoTileMusicBox : BingoTile, IMarkable, IFlammable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(pos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }
    public void PlayNote()
    {
        Utils.PlayNote();
    }

    public void OnFlame()
    {
        PlayNote();
        Mark();
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
