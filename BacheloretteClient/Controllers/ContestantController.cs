using BacheloretteClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace BacheloretteClient.Controllers
{
    [Route("/bachelorettes/{bacheloretteId}/[controller]")]
    public class ContestantsController : Controller
    {

      [HttpGet("/bachelorettes/{bacheloretteId}/contestants/")]
      public IActionResult Index(int BacheloretteId)
        {
            Console.WriteLine("Line-15 Bachelor ID is " + BacheloretteId);
            var allContestants = Contestant.GetAll(BacheloretteId); //GetAll is NOT filtering Contestant records by Bachelor ID. 
            return View(allContestants);
        }
        [HttpGet("/bachelorettes/{bacheloretteId}/contestants/details/{id}")]
        public IActionResult Details(int id, int bacheloretteId)
        {
            Console.WriteLine("Line-22 Bachelor ID is ");
             var thisContestant = Contestant.GetDetails(id, bacheloretteId);
            return View(thisContestant);
        }

        [HttpGet("/bachelorettes/contestants/create")]
        public IActionResult Create()
        {
            Console.WriteLine("Line-30 Bachelor ID is ");
            List<Bachelorette> bachelorettesList = Bachelorette.GetAll();
            ViewBag.BacheloretteId = new SelectList(bachelorettesList, "BacheloretteId", "Name");
            return View();
        }
        
        
        // [HttpPost]  //gets routed to https://localhost:5006/bachelorettes/contestants/create 
        [HttpPost("/bachelorettes/contestants/create")]  //gets routed to https://localhost:5006/bachelorettes/contestants/create    
        public IActionResult Create(Contestant newContestant, int BacheloretteId)
        {
             Console.WriteLine("Bachelor ID is !!!!! line 41 " + newContestant.BacheloretteId);
             newContestant.BacheloretteId = BacheloretteId;
            Contestant.Post(newContestant);
            // return RedirectToAction("Create");
             return RedirectToAction("Index", BacheloretteId);
            // return CreatedAtAction("Index", new {bacheloretteId = bacheloretteId}, newContestant);
        }

    }
}