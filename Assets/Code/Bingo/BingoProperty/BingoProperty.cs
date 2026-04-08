using UnityEngine;

public class BingoProperty
{
    private float baseValue;
    private string name;
    private float value;

    public BingoProperty(string name, float value, float baseValue = float.MinValue) 
    {
        this.name = name;
        this.value = value;
        this.baseValue = (baseValue != float.MinValue) ? baseValue:value;
    }

    public void Reset()
    {
        value = baseValue;
    }
    public string GetName()
    {
        return name;
    }
    public void SetValue(float value)
    {
        this.value = value;
    }
    public float GetValue()
    {
        return value;
    }
    public bool CompareName(string name)
    {
        return name == this.name;
    }

}
