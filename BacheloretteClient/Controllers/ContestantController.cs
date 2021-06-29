using BacheloretteClient.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}