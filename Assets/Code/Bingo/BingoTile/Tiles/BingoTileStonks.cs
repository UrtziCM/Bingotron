using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileStonks", menuName = "Bingo/Tiles/BingoTileStonks")]
public class BingoTileStonks : BingoTile, IMarkable
{
    public void Mark()
    {
        BingoCard bc = ServiceLocator.GetService<BingoCard>() as BingoCard;
        Vector2 thisTilePos = GetSpace().GetPosition();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        this.value = bc.GetValueFromProperty("money");

        sm.AddScore(value + bc.GetSpaceAt(thisTilePos).GetNumber().value);
    }
}
