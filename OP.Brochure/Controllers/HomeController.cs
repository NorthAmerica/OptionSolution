using OP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OP.Entities;

namespace OP.Brochure.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceBrochureRepository BrochureRepository;
        private InterfaceGuestBookRepository GuestBookRepository;
        private InterfaceOptionsProductRepository OptionsProductRepository;
        public HomeController(InterfaceBrochureRepository br,
            InterfaceGuestBookRepository gbr,
            InterfaceOptionsProductRepository opr)
        {
            BrochureRepository = br;
            GuestBookRepository = gbr;
            OptionsProductRepository = opr;
        }
        public ActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr =  BrochureRepository.Find(b => b.OptionsProductID == OPID);
                OptionsProduct findop = OptionsProductRepository.Find(op => op.OptionsProductID == OPID);
            }
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