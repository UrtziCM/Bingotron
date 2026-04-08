using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileGoldenRatio", menuName = "Bingo/Tiles/BingoTileGoldenRatio")]
public class BingoTileGoldenRatio : BingoTile, IMarkable
{

    List<int> fibonacciNumbers = new List<int> { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        foreach (int num in fibonacciNumbers)
        {
            //if (bc.GetSpaceAt(thisTilePos).GetNumber() == num) //falta comprobar si el numero de la casilla coincide con los numeros
            {
                int AddMoney = bc.GetValueFromProperty(BingoCard.MONEY_PROPERTY) + 5;
                bc.GetPropertyByName(BingoCard.MONEY_PROPERTY).SetValue(AddMoney);
                break;
            }
        }
    }
}
