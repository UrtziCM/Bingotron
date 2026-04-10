using UnityEngine;
using static UnityEngine.ParticleSystem;

[CreateAssetMenu(fileName = "BingoTileDrum", menuName = "Bingo/Tiles/BingoTileDrum")]
public class BingoTileDrum : BingoTile, IMarkable, IMusicable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        PlayNote();

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}
