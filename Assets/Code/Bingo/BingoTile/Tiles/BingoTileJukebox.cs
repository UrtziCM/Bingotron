using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileJukebox", menuName = "Bingo/Tiles/Jukebox")]
public class BingoTileJukebox : BingoTile, IMarkable, IGamble, IMusicable
{
    public float BaseProbability => 0.2f;

    private bool onGamble = true;

    public void Mark()
    {
        ServiceLocator.GetService<BingoDrum>().OnBallEffectEnd.AddListener((call) => { onGamble = false; });
        PlayNote();

        BingoCard bc = Utils.BingoCard as BingoCard;

        bc.StartCoroutine(OnGamble());

        ScoreManager sm = Utils.ScoreManager;
        sm.AddScore((int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }

    public void PlayNote()
    {
        Utils.PlayNote();
    }

    private IEnumerator OnGamble()
    {
        while (Gamble() && onGamble) 
        {
            PlayNote();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
