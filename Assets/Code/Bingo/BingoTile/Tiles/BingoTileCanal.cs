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

            BingoSpace targetSpace = Utils.BingoCard.GetSpaceAt(targetPos);

            if (targetSpace != null && targetSpace.Tile is IPermeable permeableTile)
                permeableTile.Wet();
        }

    }
}
