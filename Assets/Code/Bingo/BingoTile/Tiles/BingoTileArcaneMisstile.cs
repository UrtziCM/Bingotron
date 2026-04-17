using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileArcaneMisstile", menuName = "Bingo/Tiles/ArcaneMisstile")]
public class BingoTileArcaneMisstile : BingoTile, IMarkable, ICasteable
{
    public int LowManaCost => 10;

    public int MidManaCost => 20;

    public int HighManaCost => 30;

    public void Mark()
    {
        BingoCard bc = Utils.BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        Cast((int)bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY));

        sm.AddScore(value + GetSpace().GetSticker().value);
    }
    public void Cast(int mana)
    {
        if (mana < LowManaCost) return;

        BingoCard bc = Utils.BingoCard;

        int spacesToBurn = 1;

        if (mana > HighManaCost)
            spacesToBurn = 1;
        else if (mana > MidManaCost)
            spacesToBurn = 2;

        for (int i = 0; i < spacesToBurn; i++)
        {
            BingoSpace space = Utils.GetRandomUnmarked();
            space?.Mark();

            bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, mana - HighManaCost);
        }
    }
}
