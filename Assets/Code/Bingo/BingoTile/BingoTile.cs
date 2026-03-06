using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ERROR_THIS-SHOULD-NOT-BE-POSSIBLE", menuName = "BingoTiles/BingoTile (Not-Instanceable)")]
public abstract class BingoTile : ScriptableObject
{
    private Vector2 pos;
    private BingoSpace space;

    public BingoSpace GetSpace()
    {
        return space;
    }

    public bool IsAt(Vector2 pos)
    {
        return pos == this.pos;
    }

}
