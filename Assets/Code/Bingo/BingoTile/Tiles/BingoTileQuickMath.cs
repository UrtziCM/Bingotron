using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileQuickMath", menuName = "Bingo/Tiles/QuickMath")]
public class BingoTileQuickMath : BingoTile, IMarkable
{
    [SerializeField]
    private int addedScore = 2;
    [SerializeField]
    private int addedMoney = 3;
    public void Mark()
    {
        if(!(GetSpace().Sticker is BingoStickerNumeric)) return;
        int num = (GetSpace().Sticker as BingoStickerNumeric).Number;

        BingoCard bc = Utils.BingoCard;
        ScoreManager sm = Utils.ScoreManager;

        if (num % 2 == 0)
            sm.AddScore(addedScore);

        if (num % 3 == 0)
        {
            bc.SetPropertyValue(BingoCard.MONEY_PROPERTY, bc.GetPropertyValue(BingoCard.MONEY_PROPERTY) + addedMoney);
            //Particles
            Utils.ParticlesContainer.PlayParticle(Utils.ParticlesContainer.moneyParticle, GetSpace().transform.position);
        }

        if (num % 5 == 0)
        {
            foreach (BingoSpace space in Utils.GetTouchingSpacesFrom(pos))
                if (space.Tile is IPermeable tile)
                    tile.Wet();
        }

        if (num % 7 == 0)
        { 
            foreach (BingoSpace space in Utils.GetTouchingSpacesFrom(pos))
                if(space.IsMarkable() && space.Tile is IFlammable tile)
                    tile.OnFlame();
        }

    }
}
