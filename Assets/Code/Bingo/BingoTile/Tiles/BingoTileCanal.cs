using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCanal", menuName = "Bingo/Tiles/BingoTileCanal")]
public class BingoTileCanal : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Vector2 thisTilePos = GetSpace().GetPosition();

        Vector2[] directions =
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        foreach (Vector2 direction in directions)
        {
            Vector2 pos = thisTilePos + direction;

            if(bc.GetSpaceAt(pos).GetTile() is IPermeable tile)
                tile.Wet();
        }

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
