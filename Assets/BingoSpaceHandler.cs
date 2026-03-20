using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BingoSpaceHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BingoSpace bingoSpace;
    public Vector2 positionInGrid;

    public BingoSticker sticker => bingoSpace.GetNumber();
    public BingoTile tile => bingoSpace.GetTile();

    void Start()
    {
        BingoSpace bingoSpace = new(positionInGrid);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
