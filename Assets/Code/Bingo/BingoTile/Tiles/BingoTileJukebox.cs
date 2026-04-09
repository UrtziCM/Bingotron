using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJukebox", menuName = "Bingo/Tiles/BingoTileJukebox")]
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
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + (int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
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
