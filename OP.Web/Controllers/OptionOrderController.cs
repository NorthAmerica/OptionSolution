using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OP.Web.Controllers
{
    /// <summary>
    /// 期权订单
    /// </summary>
    public class OptionOrderController : AsyncController
    {
        // GET: OptionOrder
        public ActionResult Index()
        {
            return View();
        }
    }
}