using UnityEngine;

public class BingoTileLightingBolt : BingoTile, IMarkable, ICasteable
{
    public int LowManaCost => 10;

    public int MidManaCost => 0;

    public int HighManaCost => 0;
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Cast((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));

        Utils.ScoreManager.AddScore(value + GetSpace().GetNumber().value);       
    }
    public void Cast(int mana)
    {
        for (int i = 0; i < mana; i += 10)
        {
            BingoSpace space = Utils.GetRandomUnmarkedTyped<IChargeable>();
            if (space == null) break;

            space.Mark();

            BingoCard bc = GetSpace().GetCard();
            bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana - i);
        }
    }
}
