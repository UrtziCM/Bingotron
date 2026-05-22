using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileRest", menuName = "Bingo/Tiles/Rest")]
public class BingoTileRest : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();

        bc.SetPropertyValue(BingoCard.MANA_COUNT_PROPERTY, bc.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + 100);
        //particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.magicParticle, GetSpace().transform.position);
    }
}
