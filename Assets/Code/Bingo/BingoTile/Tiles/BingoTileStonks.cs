using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStonks", menuName = "Bingo/Tiles/BingoTileStonks")]
public class BingoTileStonks : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        this.value = bc.GetValueFromProperty("money");
    }
}
