using UnityEngine;

public class BingoProperty
{
    private int id;
    private string name;
    private int value;

    public BingoProperty(int id, string name, int value) 
    {
        this.id = id;
        this.name = name;
        this.value = value;
    }


    public int GetID()
    {
        return id;
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
    public bool CompareID(int id)
    {
        return id == this.id;
    }

}
