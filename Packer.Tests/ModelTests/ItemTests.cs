using Microsoft.VisualStudio.TestTools.UnitTesting;
using Packer.Models;
using System;
using System.Collections.Generic;

namespace Packer.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    [TestMethod]
    public void ItemConstructor_CreateInstanceOfItem_Item()
    {
      Item testItem = new Item("ItemName", true, true, 4, "REI");
      Assert.AreEqual(typeof(Item), testItem.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      List<Item> newList = new List<Item> { };

      List<Item> result = Item.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      string itemName1 = "Backpack";
      string itemName2 = "Flashlight";
      Item newItem1 = new Item(itemName1, true, true, 4, "REI");
      Item newItem2 = new Item(itemName2,  true, true, 4, "REI");
      List<Item> newList = new List<Item> { newItem1, newItem2};

      List<Item> result = Item.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }
  }
}