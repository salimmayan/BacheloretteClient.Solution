using BacheloretteClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacheloretteClient.Controllers
{
    [Route("/bachelorettes/{bacheloretteId}/[controller]")]
    public class ContestantsController : Controller
    {
        public IActionResult Index(int id)
        {
            var allContestants = Contestant.GetAll(id);
            return View(allContestants);
        }

    }
}