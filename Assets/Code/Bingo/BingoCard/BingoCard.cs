using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BingoCard : CustomService
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

    public int height = 5;
    public int width = 5;

    public UnityAction<BingoSpace, Vector2> OnMark;
    public UnityAction<BingoSpace[]> OnLine;
    public UnityAction<BingoSpace[]> OnBingo;

    public UnityAction<BingoBall> OnBallRolled;
    public UnityAction OnRoundStart;



    public IEnumerable<BingoSpace> AllSpaces()
    {
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                yield return GetSpaceAt(x, y);
            }
        }
    }

    public BingoSpace GetRandomBingoSpace()
    {
        return GetSpaceAt(Random.Range(0, width), Random.Range(0, height));
    }

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        ServiceLocator.AddService<BingoCard>(this);

        CreateProperties();

        OnBallRolled += ball => BallRolled(ball);
    }

    private void CreateProperties()
    {
        properties.Add(new BingoProperty(MONEY_PROPERTY, 10));
        properties.Add(new BingoProperty(MUSIC_ADDEDVALUE_PROPERTY, 0));
        properties.Add(new BingoProperty(CHARGE_PROPERTY, 0));
        properties.Add(new BingoProperty(GAMBLER_ADDEDPROBABILITY_PROPERTY, 0));
        properties.Add(new BingoProperty(MANA_COUNT_PROPERTY, 0));
        properties.Add(new BingoProperty(FIRE_PROBABILITY_PROPERTY, 0, 50));
    }

    public BingoSpace GetSpaceAt(int x, int y)
    {
        return GetSpaceAt(new Vector2(x, y));
    }

    public BingoSpace[] GetAllSpacesOfType<T>()
    {
        List<BingoSpace> spaces = new List<BingoSpace>();
        foreach (BingoSpace space in AllSpaces())
        {
            if (space.GetTile() is T)
                spaces.Add(space);
        }
        return spaces.ToArray();
    }
    
    
    public BingoSpace GetRandomSpaceOfType<T>()
    {
        BingoSpace[] spacesOfType = GetAllSpacesOfType<T>();
        if (spacesOfType.Length <= 0)
            return null;

        return spacesOfType[UnityEngine.Random.Range(0, spacesOfType.Length)];

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
        BingoSticker sticker = GetSpaceAt(pos).GetSticker();
        if (IsSpaceMarked(pos) && sticker != null)
            return false;
        BingoDrum bingoDrum = (ServiceLocator.GetService<BingoDrum>() as BingoDrum);
        return sticker.IsMarkable(bingoDrum.currentBingoBall);
    }

    public void MarkSpace(Vector2 pos)
    {
        BingoSpace spaceToMark = GetSpaceAt(pos);
        if (spaceToMark.GetSticker() is IClickable clickable)
            if (!clickable.OnClick()) 
                if (spaceToMark.GetSticker().IsMarkable(ServiceLocator.GetService<BingoDrum>().currentBingoBall))
                {
                    spaceToMark.Mark();
                    OnMark?.Invoke(spaceToMark, pos);
                }



        if (WillThisBeColumn(pos))
        {
            OnLine?.Invoke(GetColumn((int)pos.x));
        }
        if (WillThisBeLine(pos))
        {
            OnLine?.Invoke(GetLine((int)pos.y));
        }

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


    public BingoProperty GetProperty(string name)
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

    public float GetPropertyValue(string name)
    {
        return GetProperty(name).GetValue();
    }

    public void SetPropertyValue(string name, float value)
    {
        BingoProperty property = GetProperty(name);
        property.SetValue(value);
    }

    public void AddBingoSpace(BingoSpace bs)
    {
        tileList.Add(bs);
    }

    private void BallRolled(BingoBall ball)
    {
        foreach (BingoSpace bs in AllSpaces())
        {
            if (bs is IRoller roller)
            {
                roller.OnRoll(ball);
            }
        }
    }

    public List<BingoSpace> GetTiles()
    {
        return tileList;
    }
}
