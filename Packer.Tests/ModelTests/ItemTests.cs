using Microsoft.VisualStudio.TestTools.UnitTesting;
using Packer.Models;
using System;

namespace Packer.Tests
{
  [TestClass]
  public class ItemTests
  {

    [TestMethod]
    public void ItemConstructor_CreateInstanceOfItem_Item()
    {
      Item testItem = new Item("ItemName", true, true, 4, "REI");
      Assert.AreEqual(typeof(Item), testItem.GetType());
    }
  }
}