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
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        float addedProb = bc.GetValueFromProperty(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY);

        if (Random.Range(0.0f, 1.0f) < BaseProbability + addedProb)
        {
            bc.GetPropertyByName(BingoCard.GAMBLER_ADDEDPROBABILITY_PROPERTY).SetValue(addedProb + 0.01f);
            return true;
        }
        else 
            return false;
    }

    public void PlayNote()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        int nextMusicValue = bc.GetValueFromProperty(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1;

        bc.GetPropertyByName(BingoCard.MUSIC_ADDEDVALUE_PROPERTY).SetValue(nextMusicValue);

        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + nextMusicValue);

        while (Gamble()) // && cuando se pasa de tirada
        {
            nextMusicValue = bc.GetValueFromProperty(BingoCard.MUSIC_ADDEDVALUE_PROPERTY) + 1;

            bc.GetPropertyByName(BingoCard.MUSIC_ADDEDVALUE_PROPERTY).SetValue(nextMusicValue);

            sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value + nextMusicValue);
        }
    }
}
