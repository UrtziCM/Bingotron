using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ERROR_THIS-SHOULD-NOT-BE-POSSIBLE", menuName = "Bingo/Tiles/BingoTile (Not-Instanceable)", order = -1)]
public abstract class BingoTile : ScriptableObject
{
    internal Vector2 pos;
    internal BingoSpace space;
    internal int value = 1;

    public BingoSpace GetSpace()
    {
        return space;
    }

    public bool IsAt(Vector2 pos)
    {
        return pos == this.pos;
    }

}
