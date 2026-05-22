using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileMusicBox", menuName = "Bingo/Tiles/MusicBox")]
public class BingoTileMusicBox : BingoTile, IMarkable, IFlammable, IMusicable
{
    public bool burning { get; set; }

    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        sm.AddScore((int)bc.GetPropertyValue(BingoCard.MUSIC_ADDEDVALUE_PROPERTY));
    }
    public void PlayNote()
    {
        Utils.PlayNote(GetSpace().transform.position);
    }

    public void OnFlame()
    {
        PlayNote();
        Mark();
        Utils.BingoCard.ForceMark(space);
        burning = true;

        //particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.fireParticle, GetSpace().transform.position);
    }

    public void PostFlame()
    {
    }

    public void PreFlame()
    {
    }

    public void Spread()
    {
        Utils.Spread(pos);
    }
}
