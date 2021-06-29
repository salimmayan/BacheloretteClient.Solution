using BacheloretteClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace BacheloretteClient.Controllers
{
  [Route("/bachelorettes/{bacheloretteId}/[controller]")]
  public class ContestantsController : Controller
  {
    public IActionResult Index(int bacheloretteId)
    {
      var allContestants = Contestant.GetAll(bacheloretteId);
      return View(allContestants);
    }
    [HttpGet("/bachelorettes/{bacheloretteId}/contestants/details/{id}")]
    public IActionResult Details(int id, int bacheloretteId)
    {
      var thisContestant = Contestant.GetDetails(id, bacheloretteId);
      return View(thisContestant);
    }

    [HttpGet("/bachelorettes/{bacheloretteId}/contestants/create")]
    public IActionResult Create()
    {     
      List<Bachelorette> bachelorettesList  =  Bachelorette.GetAll();
      ViewBag.BacheloretteId = new SelectList(bachelorettesList, "BacheloretteId", "Name");
      return View();
    }

    [HttpPost]
    public IActionResult Create(Contestant newContestant, int bacheloretteId)
    {
      newContestant.BacheloretteId = bacheloretteId;
      Contestant.Post(newContestant);
      return RedirectToAction("Index");
    }

    // public IActionResult Post(Contestant contestant, int bacheloretteId)
    //     {
    //        string jsonContestant = JsonConvert.SerializeObject(contestant);
    //         var thisContestant = Contestant.GetDetails(id, bacheloretteId);
    //         List<Bachelorette> bachelorettesList  =  Bachelorette.GetAll();
    //         ViewBag.BacheloretteId = new SelectList(bachelorettesList, "BacheloretteId", "Name");
    //         return View(thisContestant);
    //     }
  }
}