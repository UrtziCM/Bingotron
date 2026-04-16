using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileGoldenRatio", menuName = "Bingo/Tiles/GoldenRatio")]
public class BingoTileGoldenRatio : BingoTile, IMarkable
{

    List<int> fibonacciNumbers = new List<int> { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

    public void Mark()
    {
        BingoCard bc = Utils.BingoCard;
        BingoSticker sticker = GetSpace().GetNumber();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();

        if (!(sticker is BingoStickerNumeric)) return;

        if(fibonacciNumbers.Contains((sticker as BingoStickerNumeric).Number))
        {
            int AddMoney = (int)bc.GetPropertyValue(BingoCard.MONEY_PROPERTY) + 5;
            bc.SetPropertyValue(BingoCard.MONEY_PROPERTY, AddMoney);
        }
    }
}
