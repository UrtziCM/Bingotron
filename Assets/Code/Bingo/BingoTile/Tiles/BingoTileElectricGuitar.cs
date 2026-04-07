using UnityEngine;

[CreateAssetMenu(fileName = "BingoTileElectricGuitar", menuName = "BingoTiles/BingoTileElectricGuitar")]
public class BingoTileElectricGuitar : BingoTile, IMarkable, IMusicable, IChargeable
{
    public void Mark()
    {
        Discharge(0); //aqui hay que pasarle la carga del tablero actual
    }
    public void Discharge(int charge)
    {
        for (int i = 0; i < charge; i++)
        {
            PlayNote();
        }
    }
    public void PlayNote()
    {
        throw new System.NotImplementedException(); //aqui se suman los puntos y las notas
    }
}
