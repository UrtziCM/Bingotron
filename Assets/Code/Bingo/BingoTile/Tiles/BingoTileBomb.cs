using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBomb", menuName = "Bingo/Tiles/BingoTileBomb")]
public class BingoTileBomb : BingoTile, IMarkable, IFlamable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        bc.MarkSpace(thisTilePos + Vector2.up);
        bc.MarkSpace(thisTilePos + Vector2.down);
        bc.MarkSpace(thisTilePos + Vector2.left);
        bc.MarkSpace(thisTilePos + Vector2.right);
    }

    public void OnFlame()
    {
        Mark();
    }
    public void PostFlame(){}
    public void PreFlame(){}
    public void Spread()
    {
        //hay que implementar la funcion de esparcir el fuego
        throw new System.NotImplementedException();
    }
}
