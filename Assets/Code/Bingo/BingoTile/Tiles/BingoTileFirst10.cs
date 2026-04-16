using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFirst10", menuName = "Bingo/Tiles/First10")]
public class BingoTileFirst10 : BingoTile, IMarkable, IRoller
{
    [SerializeField]
    private int turns = 10;
    [SerializeField]
    private int addedMoney = 3;
    [SerializeField]
    private int addedPoints = 10;
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>();
        sm.AddScore(value + GetSpace().GetNumber().value);

        if (turns > 0)
        {
            BingoCard bc = Utils.BingoCard;

            bc.SetPropertyValue(
                BingoCard.MONEY_PROPERTY,
                bc.GetPropertyValue(BingoCard.MONEY_PROPERTY) + addedMoney);

            sm.AddScore(addedPoints);
        }
    }

    public void OnRoll(BingoBall ball)
    {
        turns--;
    }
}
