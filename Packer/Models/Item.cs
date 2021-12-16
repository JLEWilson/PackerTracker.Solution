using System;
using System.Collections.Generic;

namespace Packer.Models
{
    public class Item
    {
      public string Name { get; set; }
      public bool Purchased { get; set; }
      public bool Packed { get; set; }
      public int Price { get; set; }
      public string Source { get; set; }
      public int Id { get; }
      private static List<Item> _itemList = new List<Item> { };
      public Item(string name, bool purchased, bool packed, int price, string source)
      {
        Name = name;
        Purchased = purchased;
        Packed = packed;
        Price = price;
        Source = source;
        _itemList.Add(this);
        Id = _itemList.Count;
      }

      public static List<Item> GetAll()
      {
        return _itemList;
      }

      public static void ClearAll()
      {
        _itemList.Clear();
      }

      public static Item Find(int searchId)
      {
        return _itemList[searchId-1];
      }

      public static List<Item> GetUnpacked()
      {
        List<Item> unpackedItems = _itemList.FindAll(item => !item.Packed);
        return unpackedItems;
      }
    //   public static void RemoveBreadOfTypeFromOrder(string typeOfBread)
    // {
    //   Bread.Order.RemoveAll(item => item.ItemName == typeOfBread);
    // }
    }
}

/*
one day
each item: (properties)
  - item name - get and set
  - item purchased (bool) -
  - item packed (bool)
  - item price
  - item source/where to buy


*/

