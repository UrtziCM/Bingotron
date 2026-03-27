using UnityEngine;

public enum ItemRarity
{
    Comun,
    Rara,
    Exotica,
    Legendaria
}

public class ShopItem
{
    private IBuyable item;
    private int price;
    private ItemRarity rarity;

    public IBuyable GetItem()
    {
        return item;
    }
    public int GetPrice()
    {
        return price;
    }
    public ItemRarity GetRarity()
    {
        return rarity;
    }
}
