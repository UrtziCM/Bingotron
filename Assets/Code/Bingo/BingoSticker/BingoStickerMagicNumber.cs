using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerMagicNumber", menuName = "Bingo/Stickers/MagicNumber")]
public class BingoStickerMagicNumber : BingoStickerNumeric
{
    [SerializeField]
    protected int addedMana = 10;

    public BingoStickerMagicNumber(int number) : base(number)
    {
    } 

    public override bool IsMarkable(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return false;

        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MANA_COUNT_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MANA_COUNT_PROPERTY) + addedMana);
            //particulas
            Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.magicParticle, GetSpace().transform.position);
            return true;
        }

        return false;
    }
}
