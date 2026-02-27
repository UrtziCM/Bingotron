using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class BingoCard
{
    private List<BingoSpace> tileList;
    private List<BingoProperty> properties;

    public Action<BingoTile, Vector2> OnMark;
    public Action<List<BingoSpace>> OnLine;
    public Action<List<BingoSpace>> OnBingo;

    public BingoTile GetTileAt(int index)
    {
        return null;
    }

}
