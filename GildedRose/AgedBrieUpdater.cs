using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata
{
    public class AgedBrieUpdater : ItemUpdaterBase
    {
        public override void Update(Item item)
        {
            IncreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
    }
}
