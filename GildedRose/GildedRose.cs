using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
}

public class GildedRose
{
    static bool updateQuality = false;
    private List<Item> Items = new();

    public GildedRose(IList<Item> Items)
    {
        this.Items.AddRange(Items);
    }

    public GildedRose()
    {
        
    }

    public void AddItems(IList<Item> Items)
    {
        if (Items == null || Items.Count == 0)
        {
            return;
        }

        if (updateQuality) return;
        this.Items.AddRange(Items);
    }

    public void AddItem(Item Item)
    {
        if (Item == null) return;
        
        if (updateQuality) return;
        this.Items.Add(Item);
    }

    public void ExecuteDemo(string fileJson)
    {
        using (StreamReader r = new StreamReader("Resources//demo.json"))
        {
            string json = r.ReadToEnd();
            IList<Item> items = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
            this.AddItems(items);
            Console.WriteLine("OMGHAI!");
        }
    }

    public void UpdateQuality()
    {
        if (Items == null || Items.Count == 0)
        {
            return;
        }

        if(updateQuality) return;

        foreach (Item item in Items)
        {

            item.Quality = item.Quality < 50 ? item.Quality++ : item.Quality;
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (item.SellIn < 11) { item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality; }
                    ;
                    if (item.SellIn < 6) { item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality; }
                    ;
                    item.SellIn--;
                    if (item.SellIn < 0) item.Quality = 0;
                    break;
                case "Aged Brie":
                    item.SellIn--;

                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality < 50 ? item.Quality++ : item.Quality;
                    }
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    //item.SellIn--;                    
                    break;
                default:
                    item.SellIn--;
                    if (item.SellIn < 0) item.Quality = item.Quality > 0 ? item.Quality-- : item.Quality;
                    break;
            }
        }
        ;


        //for (var i = 0; i < Items.Count; i++)
        //{
        //    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //    {
        //        if (Items[i].Quality > 0)
        //        {
        //            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //            {
        //                Items[i].Quality = Items[i].Quality - 1;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (Items[i].Quality < 50)
        //        {
        //            Items[i].Quality = Items[i].Quality + 1;

        //            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //            {
        //                if (Items[i].SellIn < 11)
        //                {
        //                    if (Items[i].Quality < 50)
        //                    {
        //                        Items[i].Quality = Items[i].Quality + 1;
        //                    }
        //                }

        //                if (Items[i].SellIn < 6)
        //                {
        //                    if (Items[i].Quality < 50)
        //                    {
        //                        Items[i].Quality = Items[i].Quality + 1;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //    {
        //        Items[i].SellIn = Items[i].SellIn - 1;
        //    }

        //    if (Items[i].SellIn < 0)
        //    {
        //        if (Items[i].Name != "Aged Brie")
        //        {
        //            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //            {
        //                if (Items[i].Quality > 0)
        //                {
        //                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                    {
        //                        Items[i].Quality = Items[i].Quality - 1;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //            }
        //        }
        //        else
        //        {
        //            if (Items[i].Quality < 50)
        //            {
        //                Items[i].Quality = Items[i].Quality + 1;
        //            }
        //        }
        //    }
        //}
    }

    internal void DisplayUpdateConsole(int days)
    {
        if (Items == null || Items.Count == 0)
        {
            return;
        }

        if (updateQuality) return;
               
        if (days < 2 ) throw new NotImplementedException();
        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach(Item item in Items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }
            Console.WriteLine("");
            this.UpdateQuality();
        }
        updateQuality = true;
    }
}