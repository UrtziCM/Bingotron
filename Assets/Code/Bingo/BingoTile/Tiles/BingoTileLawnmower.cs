using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileLawnmower", menuName = "Bingo/Tiles/Lawnmower")]
public class BingoTileLawnmower : BingoTile, IMarkable, IChargeable
{
    [SerializeField] private Vector2 direction;

    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        Discharge((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));

        sm.AddScore(value + GetSpace().GetSticker().value);
    }
    public void Discharge(int charge)
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
        Vector2 nextTilePos = GetSpace().GetPosition() + direction;

        while (bc.GetSpaceAt(nextTilePos) != null)
        {
            if(charge <= 0)
                break;

            if(bc.IsMarkable(nextTilePos))
                (bc.GetSpaceAt(nextTilePos) as IMarkable).Mark();

            charge--;
            nextTilePos += direction;
        }
    }
}
