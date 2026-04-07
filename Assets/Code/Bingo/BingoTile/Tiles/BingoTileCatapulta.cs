using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCatapulta", menuName = "BingoTiles/BingoTileCatapulta")]
public class BingoTileCatapulta : BingoTile, IMarkable, IFlamable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();

        bc?.MarkSpace(thisTilePos + 2 * Vector2.right); //Ni idea de lo que estoy haciendo, si esta mal por favor ayuda - Unax

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
        ExtraMethods.Spread(this);
    }
}
