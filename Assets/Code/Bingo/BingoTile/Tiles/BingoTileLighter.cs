using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileLighter", menuName = "Bingo/Tiles/Lighter")]
public class BingoTileLighter : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        BingoCard bc = GetSpace().GetCard();
        ScoreManager sm = ServiceLocator.GetService<ScoreManager>() as ScoreManager;

        OnFlame();

        sm.AddScore(value + bc.GetSpaceAt(pos).GetNumber().value);
    }

    public void OnFlame()
    {
        if(GetSpace().GetCard().IsSpaceMarked(pos))
            Mark();
    }

    public void PostFlame(){}
    
    public void PreFlame(){}

    public void Spread()
    {
        Utils.Spread(this);
    }
}
