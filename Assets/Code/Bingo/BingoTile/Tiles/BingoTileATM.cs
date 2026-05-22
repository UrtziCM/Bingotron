using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileATM", menuName = "Bingo/Tiles/ATM")]
public class BingoTileATM : BingoTile, IMarkable, IChargeable, IGamble
{
    public float BaseProbability => 0.2f;

    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = Utils.ScoreManager;

        Discharge((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));
    }
    public void Discharge(int charge)
    {
        value = charge;

        if (Gamble())
            Utils.ScoreManager.AddScore(value);
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability, GetSpace().transform.position);
    }
}
