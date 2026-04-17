using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWizard", menuName = "Bingo/Tiles/Wizard")]
public class BingoTileWizard : BingoTile, IMarkable, ICasteable, IGamble
{
    public float BaseProbability => 0.2f;

    public int LowManaCost => 1;

    public int MidManaCost => 0;

    public int HighManaCost => 0;

    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();

        Cast((int)bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY));

        ScoreManager sm = Utils.ScoreManager;
        sm.AddScore(value + GetSpace().GetSticker().value);
    }
    public void Cast(int mana)
    {
        BingoCard bc = GetSpace().GetCard();

        while (mana > LowManaCost)
        {
            //Aplicar un multiplicador de 0.1

            mana -= LowManaCost;
            bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana);
        }
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
