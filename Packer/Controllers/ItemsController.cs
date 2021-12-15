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
  }
}


// 1.user enters homepage : make item/new, see list, clear list 
// 2. 