using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTeslaTower", menuName = "Bingo/Tiles/TeslaTower")]
public class BingoCardTeslaTower : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Dupe((int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY));
        ScoreManager sm = Utils.ScoreManager;
        sm.AddScore(value + GetSpace().GetSticker().value);
    }

    public void Dupe(int a)
    {
        BingoCard bc = GetSpace().GetCard();
        bc.SetPropertyValue(BingoCard.CHARGE_PROPERTY, (int)bc.GetPropertyValue(BingoCard.CHARGE_PROPERTY)*2);
        
    }
}
