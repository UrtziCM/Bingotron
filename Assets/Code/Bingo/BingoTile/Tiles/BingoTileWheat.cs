using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWheat", menuName = "Bingo/Tiles/Wheat")]
public class BingoTileWheat : BingoTile, IMarkable, IFlammable, IPermeable
{
    public void Mark()
    {
    }

    public void OnFlame()
    {
        Mark();
    }

    public void PostFlame()
    {
    }

    public void PreFlame()
    {
    }

    public void Spread()
    {
        Utils.Spread(this);
    }

    public void Wet()
    {
        value++;

        //Particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.waterParticle, space.transform.position);
    }
}
