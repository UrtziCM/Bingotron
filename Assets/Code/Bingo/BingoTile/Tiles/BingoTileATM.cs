using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileATM", menuName = "Bingo/Tiles/ATM")]
public class BingoTileATM : BingoTile, IMarkable, IChargeable, IGamble
{
    public float BaseProbability => 0.2f;

    private int specialValue = 1;

    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Discharge((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));

        sm.AddScore((Gamble() ? value : specialValue) + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
    public void Discharge(int charge)
    {
        value = charge;
        specialValue = 2 * charge;
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
