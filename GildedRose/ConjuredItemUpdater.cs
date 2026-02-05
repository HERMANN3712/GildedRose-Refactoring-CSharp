using GildedRoseKata;

public class ConjuredItemUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        DecreaseQuality(item, 2);
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            DecreaseQuality(item, 2);
        }
    }
}
