using GildedRoseKata;

public class BackstagePassUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        IncreaseQuality(item);

        if (item.SellIn <= 10)
            IncreaseQuality(item);

        if (item.SellIn <= 5)
            IncreaseQuality(item);

        DecreaseSellIn(item);

        if (item.SellIn < 0)
            item.Quality = 0;
    }
}
