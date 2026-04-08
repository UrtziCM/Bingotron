using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;



public class BingoCard : Service
{
    public static readonly string MONEY_PROPERTY = "money";
    public static readonly string MUSIC_ADDEDVALUE_PROPERTY = "music";
    public static readonly string CHARGE_PROPERTY = "charge";
    public static readonly string GAMBLER_ADDEDPROBABILITY_PROPERTY = "gambler";
    public static readonly string MANA_COUNT_PROPERTY = "mana";
    public static readonly string FIRE_PROBABILITY_PROPERTY = "fire_probabilty";

    readonly Vector2 Center = Vector2.one * 2;
    readonly Vector2 First  = Vector2.one * 0;
    readonly Vector2 Last   = Vector2.one * 4;

    private List<BingoSpace> tileList = new();
    private List<BingoProperty> properties = new();

    private int height;
    private int width;

    public Action<BingoSpace, Vector2> OnMark;
    public Action<BingoSpace[]> OnLine;
    public Action<BingoSpace[]> OnBingo;


    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        ServiceLocator.AddService(this);

        CreateProperties();

        foreach (BingoSpace space in transform.GetComponentsInChildren<BingoSpace>())
        {
            AddBingoSpace(space);
        }
    }

    private void CreateProperties()
    {
        properties.Add(new BingoProperty(MONEY_PROPERTY, 10));
        properties.Add(new BingoProperty(MUSIC_ADDEDVALUE_PROPERTY, 0));
        properties.Add(new BingoProperty(CHARGE_PROPERTY, 0));
        properties.Add(new BingoProperty(GAMBLER_ADDEDPROBABILITY_PROPERTY, 0));
        properties.Add(new BingoProperty(MANA_COUNT_PROPERTY, 0));
        properties.Add(new BingoProperty(FIRE_PROBABILITY_PROPERTY, 0));
    }

    public BingoSpace GetSpaceAt(int x, int y)
    {
        return GetSpaceAt(new Vector2(x, y));
    }
    public BingoSpace GetSpaceAt(Vector2 pos)
    {
        foreach (BingoSpace bs in tileList)
        {
            if (bs.GetPosition() == pos)
            {
                return bs;
            }
        }
        return null;
    }

    public bool IsMarkable(Vector2 pos)
    {
        BingoSticker sticker = GetSpaceAt(pos).GetNumber();
        if (IsSpaceMarked(pos) && sticker != null)
            return false;
        BingoDrum bingoDrum = (ServiceLocator.GetService<BingoDrum>() as BingoDrum);
        return sticker.IsMarkable(bingoDrum.currentBingoBall);
    }

    public void MarkSpace(Vector2 pos)
    {
        if (WillThisBeColumn(pos))
        {
            OnLine?.Invoke(GetColumn((int)pos.x));
        }
        if (WillThisBeLine(pos))
        {
            OnLine?.Invoke(GetLine((int)pos.y));
        }

        OnMark?.Invoke(GetSpaceAt(pos), pos);
        if (HasBingo())
        {
            OnBingo?.Invoke(tileList.ToArray());
        }
    }

    public BingoSpace[] GetLine(int line)
    {
        BingoSpace[] spaces = new BingoSpace[height];
        for (int x  = 0; x < width; x++)
        {
            spaces[x] = GetSpaceAt(x, line);
        }
        return spaces;
    }

    public BingoSpace[] GetColumn(int column)
    {
        BingoSpace[] spaces = new BingoSpace[height];
        for (int y = 0; y < width; y++)
        {
            spaces[y] = GetSpaceAt(column, y);
        }
        return spaces;
    }

    public bool IsSpaceMarked(Vector2 pos)
    {
        return GetSpaceAt(pos).IsMarked();
    }

    public bool IsColumnMarked(int column)
    {
        for (int y = 0; y < height; y++)
        {
            if (!IsSpaceMarked(new Vector2(column,y)))
                return false;
        }
        return true;
    }

    public bool IsLineMarked(int line)
    {
        for (int x = 0; x < height; x++)
        {
            if (!IsSpaceMarked(new Vector2(x, line)))
                return false;
        }
        return true;
    }

    public bool WillThisBeLine(Vector2 pos)
    {
        for (int x = 0; x < width; x++)
        {
            if (pos.x == x)
                continue;
            if (!IsSpaceMarked(new Vector2(x, pos.y)))
            {
                return false;
            }
        }
        return !IsSpaceMarked(pos);
    }

    public bool WillThisBeColumn(Vector2 pos)
    {
        for (int y = 0; y < height; y++)
        {
            if (pos.y == y)
                continue;
            if (!IsSpaceMarked(new Vector2(pos.x, y)))
            {
                return false;
            }
        }
        return !IsSpaceMarked(pos);
    }

    public bool HasBingo()
    {
        foreach (BingoSpace bs in tileList)
        {
            if (!bs.IsMarked())
                return false;
        }
        return true;
    }
    
    public int AddProperty(BingoProperty property)
    {
        properties.Add(property);
        return properties.IndexOf(property);
    }


    public BingoProperty GetPropertyByName(string name)
    {
        foreach (BingoProperty bingoProperty in properties)
        {
            if (bingoProperty.CompareName(name))
            {
                return bingoProperty;
            }

        }
        return null;
    }

    public int GetValueFromProperty(string name)
    {
        return GetPropertyByName(name).GetValue();
    }

    public void AddBingoSpace(BingoSpace bs)
    {
        tileList.Add(bs);
    }
}
