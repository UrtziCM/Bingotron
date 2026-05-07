using UnityEngine;
using static UnityEngine.ParticleSystem;

[CreateAssetMenu(fileName = "BingoTileDrum", menuName = "Bingo/Tiles/Drum")]
public class BingoTileDrum : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        PlayNote();

        sm.AddScore((int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}
