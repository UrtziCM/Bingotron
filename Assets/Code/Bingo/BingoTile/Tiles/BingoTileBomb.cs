using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBomb", menuName = "BingoTiles/BingoTileBomb")]
public class BingoTileBomb : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        bc.MarkSpace(thisTilePos + Vector2.up);
        bc.MarkSpace(thisTilePos + Vector2.down);
        bc.MarkSpace(thisTilePos + Vector2.left);
        bc.MarkSpace(thisTilePos + Vector2.right);
    }
}
