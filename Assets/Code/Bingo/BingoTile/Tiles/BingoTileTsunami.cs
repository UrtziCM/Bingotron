using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTsunami", menuName = "Bingo/Tiles/Tsunami")]
public class BingoTileTsunami : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = Utils.ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetSticker().value);
    }

    public void Wet()
    {
        BingoCard bc = Utils.BingoCard as BingoCard;

        bool line = Random.value > 0.5f;

        BingoSpace[] spaces = line? 
            bc.GetLine(Random.Range(0, bc.width)) : 
            bc.GetColumn(Random.Range(0, bc.height));

        foreach (BingoSpace bingoSpace in spaces)
        {
            if (bingoSpace.GetTile() is IPermeable tile)
            {
                if (bingoSpace.GetTile() is not BingoTileTsunami)
                    tile.Wet();
            }
        }
    }
}
