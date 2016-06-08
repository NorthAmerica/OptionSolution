using Newtonsoft.Json;
using Op.Web.Attribute;
using OP.Entities;
using OP.Repository;
using OP.Web.Models;
using OP.Web.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OP.Web.Controllers
{
    [Authorization]
    public class ReportController : Controller
    {
        private InterfaceOptionTradeRepository OptionTradeRepository;
        public ReportController(InterfaceOptionTradeRepository otr)
        {
            OptionTradeRepository = otr;
        }
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TradeReport()
        {
            return View();
        }
        /// <summary>
        /// 查询成交量报表
        /// </summary>
        /// <param name="BeginDate1"></param>
        /// <param name="BeginDate2"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTradeSum(string BeginDate1, string BeginDate2)
        {
            try
            {
                var groupsum = new Object();
                if (string.IsNullOrEmpty(BeginDate1) || string.IsNullOrEmpty(BeginDate2))
                {
                    groupsum = OptionTradeRepository.FindAll().GroupBy(o => new { o.OptionsProductID }).
                        Select(o => (new OptionTradeSumModel
                        {
                            ProductName = o.Select(item => item.ProductName).First(),
                            TradeNumSum = Convert.ToDecimal(o.Sum(item => item.TradeNum))
                        })).ToList();
                }
                else
                {
                    DateTime? bd1 = Convert.ToDateTime(BeginDate1);
                    DateTime? bd2 = Convert.ToDateTime(BeginDate2);
                    groupsum = OptionTradeRepository.FindAll().Where(o => o.BeginDate >= bd1 && o.BeginDate <= bd2).GroupBy(o => new { o.OptionsProductID})
                        .Select(o => (new OptionTradeSumModel
                        {
                            ProductName = o.Select(item => item.ProductName).First(),
                            TradeNumSum = Convert.ToDecimal(o.Sum(item => item.TradeNum))
                        })).ToList();
                }
                return Json(groupsum, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}