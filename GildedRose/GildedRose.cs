using GildedRoseKata;
using System.Collections.Generic;

public class GildedRose
{
    public IList<Item> Items { get; }

    public GildedRose(IList<Item> items)
    {
        Items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var updater = ItemUpdaterFactory.Create(item);
            updater.Update(item);
        }
    }
}
