using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTsunami", menuName = "Bingo/Tiles/BingoTileTsunami")]
public class BingoTileTsunami : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void Wet()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

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
