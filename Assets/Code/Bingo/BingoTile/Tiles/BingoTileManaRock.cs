using UnityEngine;

public class BingoTileManaRock : BingoTile, IMarkable, IRoller
{
    [SerializeField]
    private int addedMana;
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();
        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void OnRoll(BingoBall ball)
    {
        Utils.BingoCard.SetPropertyValue(
            BingoCard.MANA_COUNT_PROPERTY,
            Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + addedMana);
    }
}
