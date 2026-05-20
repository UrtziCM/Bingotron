using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileLighter", menuName = "Bingo/Tiles/Lighter")]
public class BingoTileLighter : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        OnFlame();

    }

    public void OnFlame()
    {
        if(!Utils.BingoCard.IsSpaceMarked(pos))
            Mark();

        //particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.fireParticle, GetSpace().transform.position);
    }

    public void PostFlame(){}
    
    public void PreFlame(){}

    public void Spread()
    {
        Utils.Spread(pos);
    }
}
