using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTree", menuName = "Bingo/Tiles/Tree")]
public class BingoTileTree : BingoTile, IMarkable, IFlammable
{
    public bool burning { get; set; }

    public void Mark()
    {
    }

    public void OnFlame()
    {
        Mark();

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
