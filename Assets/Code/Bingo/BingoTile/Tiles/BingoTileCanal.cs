using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileCanal", menuName = "Bingo/Tiles/Canal")]
public class BingoTileCanal : BingoTile, IMarkable
{
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        Vector2[] directions =
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        foreach (Vector2 direction in directions)
        {
            Vector2 targetPos = pos + direction;

            if(GetSpace().GetTile() is IPermeable tile)
                tile.Wet();
        }

        sm.AddScore(value + GetSpace().GetNumber().value);
    }
}
