using NUnit.Framework;
using System.Collections;
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
        BingoCard bc = Utils.BingoCard;

        Cast((int)bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY));

    }
    public void Cast(int mana)
    {
        Utils.BingoCard.StartCoroutine(addMultiply(mana));
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }

    private IEnumerator addMultiply(int mana)
    {
        while (mana > LowManaCost)
        {
            Utils.ScoreManager.AddMultiply(0.01f);

            mana -= LowManaCost;
            Utils.BingoCard.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
