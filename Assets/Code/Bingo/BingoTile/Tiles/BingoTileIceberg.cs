using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileIceberg", menuName = "Bingo/Tiles/Iceberg ")]
public class BingoTileIceberg : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }

    public void OnFlame()
    {
        Mark();
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();

        Vector2[] directions =
        {
            Vector2.up,
            Vector2.up + Vector2.left,
            Vector2.up + Vector2.right,
            Vector2.down,
            Vector2.down + Vector2.left,
            Vector2.down + Vector2.right,
            Vector2.left,
            Vector2.right
        };

        foreach (Vector2 direction in directions)
        {
            Vector2 pos = thisTilePos + direction;

            if(bc.GetSpaceAt(pos).GetTile() is IPermeable tile)
                tile.Wet();
        }

    }
}
