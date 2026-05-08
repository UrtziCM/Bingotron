using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTile", menuName = "Bingo/Tiles/BingoTile", order = -1)]
public class BingoTile : ScriptableObject
{
    internal Vector2 pos;
    internal BingoSpace space;
    [SerializeField]
    internal int value = 1;
    [SerializeField, TextArea]
    private string Description;


    public BingoSpace GetSpace()
    {
        return space;
    }

    public bool IsAt(Vector2 pos)
    {
        return pos == this.pos;
    }

}
