using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTsunami", menuName = "Bingo/Tiles/Tsunami")]
public class BingoTileTsunami : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + GetSpace().GetNumber().value);
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
            if (bingoSpace.GetTile() is IPermeable tile && !(bingoSpace.GetTile() is BingoTileTsunami))
            {
                tile.Wet();
            }
        }
    }
}
