using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileBomb", menuName = "Bingo/Tiles/Bomb")]
public class BingoTileBomb : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = Utils.BingoCard;
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();


        Vector2[] directions =
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        foreach (Vector2 direction in directions)
        {
            Vector2 tagetPos = pos + direction;

            if (bc.IsMarkable(tagetPos))
                bc.MarkSpace(tagetPos);
        }

        sm.AddScore(value + GetSpace().GetSticker().value);
    }

    public void OnFlame()
    {
        Mark();
    }
    public void PostFlame(){}
    public void PreFlame(){}
    public void Spread()
    {
        Utils.Spread(this);
    }
}
