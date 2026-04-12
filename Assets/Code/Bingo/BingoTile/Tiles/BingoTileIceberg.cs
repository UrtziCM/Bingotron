using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileIceberg", menuName = "Bingo/Tiles/Iceberg ")]
public class BingoTileIceberg : BingoTile, IMarkable
{
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;
        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void OnFlame()
    {
        Mark();
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;

        foreach (Vector2 direction in Utils.SurroundingPositions)
        {
            Vector2 targetPos = pos + direction;

            if(bc.GetSpaceAt(targetPos).GetTile() is IPermeable tile)
                tile.Wet();
        }
    }
}
