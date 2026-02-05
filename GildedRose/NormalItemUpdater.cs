using GildedRoseKata;

public class NormalItemUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        DecreaseQuality(item);
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
        }
    }
}