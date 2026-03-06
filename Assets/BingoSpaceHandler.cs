using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BingoSpaceHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BingoSpace bingoSpace;

    public BingoSticker sticker => bingoSpace.GetNumber();
    public BingoTile tile => bingoSpace.GetTile();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
