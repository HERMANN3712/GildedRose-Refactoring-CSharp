using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public abstract class ItemUpdaterBase : IItemUpdater
    {
        protected const int MaxQuality = 50;
        protected const int MinQuality = 0;

        public abstract void Update(Item item);

        protected void IncreaseQuality(Item item, int value = 1)
        {
            item.Quality = Math.Min(MaxQuality, item.Quality + value);
        }

        protected void DecreaseQuality(Item item, int value = 1)
        {
            item.Quality = Math.Max(MinQuality, item.Quality - value);
        }

        protected void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
