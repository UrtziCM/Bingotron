using UnityEngine;
using static UnityEngine.ParticleSystem;

[CreateAssetMenu(fileName = "BingoTileDrum", menuName = "Bingo/Tiles/Drum")]
public class BingoTileDrum : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        PlayNote();

        sm.AddScore(value + GetSpace().GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}
