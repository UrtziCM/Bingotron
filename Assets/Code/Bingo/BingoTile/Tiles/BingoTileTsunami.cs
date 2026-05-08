using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileTsunami", menuName = "Bingo/Tiles/Tsunami")]
public class BingoTileTsunami : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
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
            if (bingoSpace.Tile is IPermeable tile)
            {
                if (bingoSpace.Tile is not BingoTileTsunami)
                    tile.Wet();
            }
        }
    }
}
