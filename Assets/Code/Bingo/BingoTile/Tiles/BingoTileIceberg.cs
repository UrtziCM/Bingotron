using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileIceberg", menuName = "Bingo/Tiles/Iceberg ")]
public class BingoTileIceberg : BingoTile, IMarkable
{
    public void Mark()
    {
    }

    public void OnFlame()
    {
        Mark();
        BingoCard bc = Utils.BingoCard;

        foreach (Vector2 direction in Utils.SurroundingPositions)
        {
            Vector2 targetPos = pos + direction;

            BingoSpace targetSpace = Utils.BingoCard.GetSpaceAt(targetPos);

            if (targetSpace != null && targetSpace.Tile is IPermeable tile)
                tile.Wet();
        }
    }
}
