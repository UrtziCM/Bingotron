using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileGenerator", menuName = "Bingo/Tiles/Generator")]
public class BingoTileGenerator : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY, bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY) + bc.GetAllSpacesOfType<BingoTileWire>().Length);

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
