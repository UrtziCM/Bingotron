using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStrawLoft", menuName = "Bingo/Tiles/StrawLoft")]
public class BingoTileStrawLoft : BingoTile, IMarkable, IFlammable, IGamble
{
    public bool burning { get; set; }

    public float BaseProbability => 0.3f;

    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        if (Gamble())
            sm.AddScore(10);
    }

    public void OnFlame()
    {
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
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability, GetSpace().transform.position);
    }
}
