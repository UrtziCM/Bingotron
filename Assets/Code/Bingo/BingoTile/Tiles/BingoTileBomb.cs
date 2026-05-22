using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "BingoTileBomb", menuName = "Bingo/Tiles/Bomb")]
public class BingoTileBomb : BingoTile, IMarkable, IFlammable
{
    public bool burning { get; set; }

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
            Vector2 targetPos = pos + direction;
            BingoSpace targetSpace = bc.GetSpaceAt(targetPos);

            if (targetSpace == null)
                continue;

            if (!(targetSpace.IsMarked()))
                bc.ForceMark(targetSpace);
        }

    }

    public void OnFlame()
    {
        Mark();
        Utils.BingoCard.ForceMark(space);

        burning = true;
        
        //particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.fireParticle, GetSpace().transform.position);
    }
    public void PostFlame(){}
    public void PreFlame(){}
    public void Spread()
    {
        Utils.Spread(pos);
    }
}
