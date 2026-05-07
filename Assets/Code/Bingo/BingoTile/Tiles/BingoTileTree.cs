using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTree", menuName = "Bingo/Tiles/Tree")]
public class BingoTileTree : BingoTile, IMarkable, IFlammable
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
}
