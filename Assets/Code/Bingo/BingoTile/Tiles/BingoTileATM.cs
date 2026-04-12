using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileATM", menuName = "Bingo/Tiles/ATM")]
public class BingoTileATM : BingoTile, IMarkable, IChargeable, IGamble
{
    public float BaseProbability => 0.2f;

    private int specialValue = 1;

    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Discharge((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));

        sm.AddScore((Gamble() ? value : specialValue) + GetSpace().GetNumber().value);
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
