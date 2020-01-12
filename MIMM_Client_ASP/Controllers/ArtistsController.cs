using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MIMM_Shared.Models;
namespace MIMM_Client_ASP.Controllers
{

   public class ArtistsController : Controller
   {
        private mimmContext _context;

		public ArtistsController(mimmContext Context)
		{
            this._context=Context;
		}


        public IActionResult Index()
        {
            return View();
        }


        public ActionResult Artists()
        {

            ViewBag.dataSource = _context.Artists.ToList();

            return View();
        }

    }
}