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

            if(bc.GetSpaceAt(targetPos).GetTile() is IPermeable tile)
                tile.Wet();
        }
    }
}
