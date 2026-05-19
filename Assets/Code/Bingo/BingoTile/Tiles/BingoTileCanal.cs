using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCanal", menuName = "Bingo/Tiles/Canal")]
public class BingoTileCanal : BingoTile, IMarkable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        foreach (Vector2 direction in Utils.TouchingPositions)
        {
            Vector2 targetPos = pos + direction;

            if(Utils.BingoCard.GetSpaceAt(targetPos).Tile is IPermeable tile)
                tile.Wet();
        }

    }
}
