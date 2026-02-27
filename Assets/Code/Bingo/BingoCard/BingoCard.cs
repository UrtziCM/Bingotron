using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class BingoCard
{
    private List<BingoSpace> tileList;
    private List<BingoProperty> properties;

    public Action<BingoSpace, Vector2> OnMark;
    public Action<List<BingoSpace>> OnLine;
    public Action<List<BingoSpace>> OnBingo;

    public BingoTile GetTileAt(Vector2 pos)
    {
        foreach (BingoSpace bs in tileList)
        {
            if (bs.position == pos)
            {
                return bs;
            }
        }
        return null;
    }

    public void MarkSpace(Vector2 pos)
    {

    }
    
    public int AddProperty(BingoProperty property)
    {
        properties.Add(property);
        return properties.IndexOf(property);
    }


    public BingoProperty? GetPropertyByName(string name)
    {
        foreach (BingoProperty bingoProperty in properties)
        {
            if (bingoProperty.name == name)
            {
                return bingoProperty;
            }

        }
        return null;
    }
}
