using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileFisher", menuName = "Bingo/Tiles/Fisher")]
public class BingoTileFisher : BingoTile, IMarkable, IPermeable
{
    public void Mark()
    {
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        sm.AddScore(value + GetSpace().GetNumber().value);
    }

    public void Wet()
    {
        value++;
    }
}
