using UnityEngine;

[CreateAssetMenu(fileName = "BingoStickerGold", menuName = "Bingo/Stickers/Gold")]
public class BingoStickerGold : BingoStickerNumeric
{
    [SerializeField]
    protected int addedMoney;

    public BingoStickerGold(int number) : base(number)
    {
    }

    public override bool IsMarkable(BingoBall ball)
    {
        if (GetSpace().IsMarked()) return false;

        if (ball.number == number)
        {
            Utils.BingoCard.SetPropertyValue(
                BingoCard.MONEY_PROPERTY,
                Utils.BingoCard.GetPropertyValue(BingoCard.MONEY_PROPERTY) + addedMoney);
            //Particles
            Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.moneyParticle, GetSpace().transform.position);
            return true;
        }
        return false;
    }
}
