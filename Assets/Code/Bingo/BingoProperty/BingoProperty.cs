using UnityEngine;

public class BingoProperty
{
    private int baseValue;
    private string name;
    private int value;

    public BingoProperty(string name, int value, int baseValue = int.MinValue) 
    {
        this.name = name;
        this.value = value;
        this.baseValue = (baseValue != int.MinValue) ? baseValue:value;
    }

    public void Reset()
    {
        value = baseValue;
    }
    public string GetName()
    {
        return name;
    }
    public void SetValue(int value)
    {
        this.value = value;
    }
    public int GetValue()
    {
        return value;
    }
    public bool CompareName(string name)
    {
        return name == this.name;
    }

}
