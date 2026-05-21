using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileManaRock", menuName = "Bingo/Tiles/ManaRock")]
public class BingoTileManaRock : BingoTile, IMarkable, IRoller
{
    [SerializeField]
    private int addedMana;
    public void Mark()
    {
    }

    public void OnRoll(BingoBall ball)
    {
        Utils.BingoCard.SetPropertyValue(
            BingoCard.MANA_COUNT_PROPERTY,
            Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + addedMana);
        //particulas
        Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.magicParticle, GetSpace().transform.position);

    }
}
