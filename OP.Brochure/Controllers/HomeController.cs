using OP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OP.Brochure.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceBrochureRepository BrochureRepository;
        private InterfaceGuestBookRepository GuestBookRepository;
        public HomeController(InterfaceBrochureRepository br,
            InterfaceGuestBookRepository gbr)
        {
            BrochureRepository = br;
            GuestBookRepository = gbr;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }
        public ActionResult Example()
        {
            return View();
        }
    }
}