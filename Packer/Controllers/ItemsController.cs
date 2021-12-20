using Microsoft.AspNetCore.Mvc;
using Packer.Models;
using System.Collections.Generic;

namespace Packer.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/items")]
    public ActionResult Create(string name, int price, string source, bool purchased = false, bool packed = false)
    {
      Item newItem = new Item(name, purchased, packed, price, source);
      newItem.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item foundItem = Item.Find(id);
      return View(foundItem);
    }

    [HttpPost("items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
    [HttpGet("items/unpacked")]
    public ActionResult Unpacked() // same name as the file .cshtml file
    {
      return View(Item.GetUnpacked());  // calls the method in the item file
    }
  }
}


// 1.user enters homepage : make item/new, see list, clear list