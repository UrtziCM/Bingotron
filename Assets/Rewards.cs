using UnityEngine;

public class Rewards : CustomService
{
    public ScriptableObject Selected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        ServiceLocator.AddService<Rewards>(this);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {

    }
}
