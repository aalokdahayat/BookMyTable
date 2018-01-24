using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrderingWebService.Controllers
{
    public class BookMyTableController : Controller
    {
        // GET: BookMyTable
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DishListingPage()
        {
            return View();
        }
    }
}