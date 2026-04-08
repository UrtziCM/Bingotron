using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileLawnmower", menuName = "Bingo/Tiles/BingoTileLawnmower")]
public class BingoTileLawnmower : BingoTile, IMarkable, IChargeable
{
    [SerializeField] private Vector2 direction;

    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Discharge(bc.GetValueFromProperty("charge"));

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
    public void Discharge(int charge)
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 nextTilePos = GetSpace().GetPosition() + direction;

        while (bc.GetSpaceAt(nextTilePos) != null)
        {
            if(charge <= 0)
                break;

            if(bc.IsMarkable(nextTilePos))
                if (bc.GetSpaceAt(nextTilePos).GetTile() is IMarkable tile)
                    tile.Mark();

            charge--;
            nextTilePos += direction;
        }
    }
}
