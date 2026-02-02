using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace evidence_zavad_uhrin.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
