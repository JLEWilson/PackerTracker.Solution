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

      public Item(string name, bool purchased, bool packed, int price, string source)
      {
        Name = name;
        Purchased = purchased;
        Packed = packed;
        Price = price;
        Source = source;
      }

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

