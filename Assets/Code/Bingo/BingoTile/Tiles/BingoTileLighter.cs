using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileLighter", menuName = "Bingo/Tiles/Lighter")]
public class BingoTileLighter : BingoTile, IMarkable, IFlammable
{
    public void Mark()
    {
        ScoreManager sm = Utils.ScoreManager;

        OnFlame();

        sm.AddScore(value + GetSpace().GetSticker().value);
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
