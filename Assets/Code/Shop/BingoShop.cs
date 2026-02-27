using UnityEngine;
using System.Collections.Generic;

public class BingoShop
{
    private List<BingoTile> tiles;
    private List<BingoSticker> stickers;
    //private List<BingoBall> balls;

    public static BingoShop GenerateShop()
    {
        return new BingoShop();
    }

    public static BingoTile[] GenerateTilePack()
    {
        return null;
    }

    public static BingoSticker[] GenerateStickerPack()
    {
        return null;
    }

    //public static BingoBall[] GenerateBallPack()
    //{
    //    return null;
    //}

    public List<BingoTile> GetTiles()
    {
        return tiles;
    }

    public List<BingoSticker> GetStickers()
    {
        return stickers;
    }

    //public List<BingoBall> GetBalls()
    //{
    //    return balls;
    //}



}
