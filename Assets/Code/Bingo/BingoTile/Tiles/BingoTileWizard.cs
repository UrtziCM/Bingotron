using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileWizard", menuName = "Bingo/Tiles/Wizard")]
public class BingoTileWizard : BingoTile, IMarkable, ICasteable, IGamble
{
    public float BaseProbability => 0.2f;
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();

        Cast((int)bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY));

        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
    public void Cast(int mana)
    {
        BingoCard bc = GetSpace().GetCard();

        while (mana > 0)
        {
            //Aplicar un multiplicador de 0.1

            mana--;
            bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana);
        }
    }
    public bool Gamble()
    {
        return Utils.Gamble(BaseProbability);
    }
}
