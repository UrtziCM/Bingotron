using UnityEngine;

public abstract class BingoProperty
{
    private int id;
    private string name;

    public BingoProperty(int id, string name) 
    {
        this.id = id;
        this.name = name;
    }


    public int GetID()
    {
        return id;
    }
    public string GetName()
    {
        return name;
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
