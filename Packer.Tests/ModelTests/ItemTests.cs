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
    public ItemTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=packertracker_test;";
    }

    // [TestMethod]
    // public void ItemConstructor_CreateInstanceOfItem_Item()
    // {
    //   Item testItem = new Item("ItemName", true, true, 4, "REI");
    //   Assert.AreEqual(typeof(Item), testItem.GetType());
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
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
      newItem1.Save();
      Item newItem2 = new Item(itemName2,  true, true, 4, "REI");
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2};

      List<Item> result = Item.GetAll();
      
      Console.WriteLine(newItem1.Id);
      Console.WriteLine(newItem2.Id);

      Console.WriteLine(result[0].Id);
      Console.WriteLine(result[0].Name);
      Console.WriteLine(result[0].Purchased);
      Console.WriteLine(result[0].Packed);
      Console.WriteLine(result[0].Price);
      Console.WriteLine(result[0].Source);

      CollectionAssert.AreEqual(newList, result);
    }
  }
}