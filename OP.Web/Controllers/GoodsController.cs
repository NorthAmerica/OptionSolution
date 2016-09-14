using OP.Entities.Models;
using OP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using OP.Web.Attribute;

namespace OP.Web.Controllers
{
    [Authorization]
    public class GoodsController : AsyncController
    {
        private InterfaceGoodsPurchaseRepository GoodsPurchaseRepository;
        private InterfaceGoodsMarketingRepository GoodsMarketingRepository;
        private InterfaceEventLogRepository LogRepository;
        private InterfaceGoodsFutureRepository GoodsFutureRepository;
        public GoodsController(InterfaceGoodsPurchaseRepository gpr, 
                               InterfaceGoodsMarketingRepository gmr,
                               InterfaceEventLogRepository elr,
                               InterfaceGoodsFutureRepository gfr)
        {
            GoodsPurchaseRepository = gpr;
            GoodsMarketingRepository = gmr;
            LogRepository = elr;
            GoodsFutureRepository = gfr;
        }

        /// <summary>
        /// 现货采购合同列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GoodsPurchaseList()
        {
            return View();
        }
        /// <summary>
        /// 现货采购合同列表数据源
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GoodsPurchaseList_Read(int? page, int? rows)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            List<GoodsPurchase> lgp = await GoodsPurchaseRepository.FindAllAsync();
            return Json(new
            {
                total = lgp.Count(),
                rows = lgp.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 新增现货采购合同
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddGoodsPurchase(GoodsPurchase purchase)
        {
            try
            {
                if (purchase!=null)
                {
                    purchase.TotalPrice = purchase.UnitPrice * purchase.ContractNum;
                    purchase.AwaitPickdingNum = purchase.ContractNum - purchase.AlreadyPickingNum;
                    purchase.TonCost = purchase.UnitPrice + purchase.LogisticsCost;
                    purchase.AllCost = purchase.TonCost * purchase.ContractNum;
                    purchase.GoodsPurchaseID = new GoodsPurchase().GoodsPurchaseID;
                    purchase.Noter = Session["LoginedUser"].ToString();
                    purchase.RecordTime = DateTime.Now;
                    if (GoodsPurchaseRepository.Add(purchase)!=null)
                    {
                        return Json(new { Success = true });
                    }
                }
                return Json(new { Success = false,
                                  Message="参数有误。"});
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增现货采购合同失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        /// <summary>
        /// 现货采购合同明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetGoodsPurchaseDetails(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    GoodsPurchase findgp = await GoodsPurchaseRepository.FindAsync(p => p.GoodsPurchaseID == gid);
                    if (findgp!=null)
                    {
                        return Json(new {
                            Success=true,
                            AllCost=findgp.AllCost,
                            AlreadyPickingNum = findgp.AlreadyPickingNum,
                            AwaitPickdingNum=findgp.AwaitPickdingNum,
                            ContractNo=findgp.ContractNo,
                            ContractNum = findgp.ContractNum,
                            ContractObject =findgp.ContractObject,
                            ContractType=findgp.ContractType,
                            CustomerName = findgp.CustomerName,
                            DeliveryTime = findgp.DeliveryTime.ToString("yyyy-MM-dd"),
                            GoodsPurchaseID =findgp.GoodsPurchaseID,
                            InvoiceStatus=findgp.InvoiceStatus,
                            LogisticsCost=findgp.LogisticsCost,
                            PaymentAmount=findgp.PaymentAmount,
                            PaymentTime=findgp.PaymentTime.ToString("yyyy-MM-dd"),
                            RealityPickdingNum=findgp.RealityPickdingNum,
                            Remark=findgp.Remark,
                            SigningTime=findgp.SigningTime.ToString("yyyy-MM-dd"),
                            TonCost=findgp.TonCost,
                            TotalPrice=findgp.TotalPrice,
                            UnitPrice=findgp.UnitPrice
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "获取现货采购合同明细失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 更新现货采购合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateGoodsPurchase(GoodsPurchase model)
        {
            try
            {
                if (model!=null)
                {
                    model.TotalPrice = model.UnitPrice * model.ContractNum;
                    model.AwaitPickdingNum = model.ContractNum - model.AlreadyPickingNum;
                    model.TonCost = model.UnitPrice + model.LogisticsCost;
                    model.AllCost = model.TonCost * model.ContractNum;
                    model.Noter = Session["LoginedUser"].ToString();
                    model.RecordTime = DateTime.Now;
                    if (GoodsPurchaseRepository.Update(model))
                    {
                        return Json(new { Success = true });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新现货采购合同" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message=ex.Message
                });
            }
        }
        /// <summary>
        /// 删除现货采购合同
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGoodsPurchase(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    GoodsPurchase findgp = await GoodsPurchaseRepository.FindAsync(p => p.GoodsPurchaseID == gid);
                    if (findgp!= null)
                    {
                        if (GoodsPurchaseRepository.Delete(findgp))
                        {
                            return Json(new { Success = true });
                        }
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除现货采购合同失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        /// <summary>
        /// 新增现货销售合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddGoodsMarketing(GoodsMarketing model)
        {
            try
            {
                if (model!=null)
                {
                    model.TotalPrice = model.UnitPrice + model.ContractNum;
                    model.AwaitDeliveryNum = model.ContractNum + model.AlreadyDeliveryNum;
                    model.RealityPayment = model.RealityDeliveryNum * model.UnitPrice;
                    model.AwaitPayment = model.RealityDeliveryNum * model.UnitPrice - model.AlreadyPayment;
                    model.Noter = Session["LoginedUser"].ToString();
                    model.RecordTime = DateTime.Now;
                    if (GoodsMarketingRepository.Add(model) != null)
                    {
                        return Json(new { Success = true });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增现货销售合同失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        /// <summary>
        /// 现货销售合同页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GoodsMarketingList()
        {
            return View();
        }
        /// <summary>
        /// 现货销售合同列表数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public async Task<ActionResult> GoodsMarketingList_Read(int? page, int? rows,string GoodsPurchaseID)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            List<GoodsMarketing> lgm = await GoodsMarketingRepository.FindAllAsync();
            if (!string.IsNullOrEmpty(GoodsPurchaseID))
            {
                Guid gid = new Guid(GoodsPurchaseID);
                lgm=lgm.Where(p => p.GoodsPurchaseID == gid).ToList();
            }
            return Json(new
            {
                total = lgm.Count(),
                rows = lgm.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 绑定现货销售合同明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetGoodsMarketingDetails(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    GoodsMarketing findgp = await GoodsMarketingRepository.FindAsync(p => p.GoodsMarketingID == gid);
                    if (findgp != null)
                    {
                        return Json(new
                        {
                            Success = true,
                            CustomerName = findgp.CustomerName,
                            ContractNo = findgp.ContractNo,
                            SigningTime = findgp.SigningTime,
                            PickingType = findgp.PickingType,
                            ContractObject = findgp.ContractObject,
                            UnitPrice = findgp.UnitPrice,
                            ContractNum = findgp.ContractNum,
                            DeliveryTime = findgp.DeliveryTime.ToString("yyyy-MM-dd"),
                            AlreadyDeliveryNum = findgp.AlreadyDeliveryNum,
                            RealityDeliveryNum = findgp.RealityDeliveryNum,
                            LogisticsCost = findgp.LogisticsCost,
                            InvoiceStatus = findgp.InvoiceStatus,
                            AlreadyPayment = findgp.AlreadyPayment,
                            Remark = findgp.Remark
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "绑定现货销售合同明细失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 更新现货销售合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateGoodsMarketing(GoodsMarketing model)
        {
            try
            {
                if (model != null)
                {
                    model.TotalPrice = model.UnitPrice + model.ContractNum;
                    model.AwaitDeliveryNum = model.ContractNum + model.AlreadyDeliveryNum;
                    model.RealityPayment = model.RealityDeliveryNum * model.UnitPrice;
                    model.AwaitPayment = model.RealityDeliveryNum * model.UnitPrice - model.AlreadyPayment;
                    model.Noter = Session["LoginedUser"].ToString();
                    model.RecordTime = DateTime.Now;
                    if (GoodsMarketingRepository.Update(model))
                    {
                        return Json(new { Success = true });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新现货销售合同失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        /// <summary>
        /// 删除现货銷售合同
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGoodsMarketing(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    GoodsMarketing findgp = await GoodsMarketingRepository.FindAsync(p => p.GoodsMarketingID == gid);
                    if (findgp != null)
                    {
                        if (GoodsMarketingRepository.Delete(findgp))
                        {
                            return Json(new { Success = true });
                        }
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除现货銷售合同失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public ActionResult GoodsFutureList()
        {
            return View();
        }
        /// <summary>
        /// 现货盘面对冲列表数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public async Task<ActionResult> GoodsFutureList_Read(int? page, int? rows,string GoodsPurchaseID)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            List<GoodsFuture> lgm = await GoodsFutureRepository.FindAllAsync();
            if (!string.IsNullOrEmpty(GoodsPurchaseID))
            {
                Guid gid = new Guid(GoodsPurchaseID);
                lgm=lgm.Where(f => f.GoodsPurchaseID == gid).ToList();
            }
            return Json(new
            {
                total = lgm.Count(),
                rows = lgm.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 新增盘面对冲
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> AddGoodsFuture(GoodsFuture model)
        {
            try
            {
                if (model != null)
                {
                    GoodsPurchase findgp = await GoodsPurchaseRepository.FindAsync(p => p.GoodsPurchaseID == model.GoodsPurchaseID);
                    if (findgp!=null)
                    {
                        model.ContractNo = findgp.ContractNo;
                    }
                    model.Noter = Session["LoginedUser"].ToString();
                    model.RecordTime = DateTime.Now;
                    if (GoodsFutureRepository.Add(model) != null)
                    {
                        return Json(new { Success = true });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增盘面对冲失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        /// <summary>
        /// 删除盘面对冲记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGoodsFuture(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    GoodsFuture findgp = await GoodsFutureRepository.FindAsync(p => p.GoodsFuturesID == gid);
                    if (findgp != null)
                    {
                        if (GoodsFutureRepository.Delete(findgp))
                        {
                            return Json(new { Success = true });
                        }
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除盘面对冲记录失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}