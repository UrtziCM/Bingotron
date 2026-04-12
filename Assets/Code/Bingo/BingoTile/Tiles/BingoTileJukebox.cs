using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJukebox", menuName = "Bingo/Tiles/Jukebox")]
public class BingoTileJukebox : BingoTile, IMarkable, IGamble, IMusicable
{
    public float BaseProbability => 0.2f;

    public void Mark()
    {
        PlayNote();

        while (Gamble()) // && cuando se pasa de tirada
        {
            PlayNote();
        }

        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + GetSpace().GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }
}
