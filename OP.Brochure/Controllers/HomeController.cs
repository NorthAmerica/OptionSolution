using OP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OP.Entities;
using OP.Brochure.Models;
using OP.Brochure.Attribute;

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
        /// <summary>
        /// 发送留言
        /// </summary>
        /// <param name="gb"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult SendGuestBook(GuestBook gb)
        {
            try
            {
                if (gb!=null)
                {
                    gb.GuestDate = DateTime.Now.ToLocalTime();
                    GuestBook addGB = GuestBookRepository.Add(gb);
                    if (addGB!=null)
                    {
                        return Json(new
                        {
                            Success = true
                        });
                    }
                }
                return Json(new
                {
                    Success = false
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    Success = false
                });
            }
        }
        /// <summary>
        /// 显示盈亏结构图
        /// </summary>
        /// <returns></returns>
        public FileResult ShowSFPic(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Guid gid = new Guid(id);
                    byte[] image = BrochureRepository.Find(b => b.BrochureID == gid).SFPic;
                    return new FileContentResult(image, "image/jpeg");
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// 显示示例图
        /// </summary>
        /// <returns></returns>
        public FileResult ShowExamplePic(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Guid gid = new Guid(id);
                    byte[] image = BrochureRepository.Find(b => b.BrochureID == gid).ExamplePic;
                    return new FileContentResult(image, "image/jpeg");
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 宣传页首页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr =  BrochureRepository.Find(b => b.OptionsProductID == OPID);
                OptionsProduct findop = OptionsProductRepository.Find(op => op.OptionsProductID == OPID);
                if (findbr!=null&&findop!=null)
                {
                    BrochureViewModel bvm = new BrochureViewModel();
                    bvm.AmountType = findop.AmountType;
                    bvm.BrochureID = findbr.BrochureID;
                    bvm.BuyBegin = findbr.BuyBegin;
                    bvm.BuyTime = findbr.BuyTime;
                    bvm.Contract = findop.Contract;
                    bvm.ContractDescrip = findbr.ContractDescrip;
                    bvm.Deadline = findop.Deadline;
                    bvm.EndDateDescrip = findbr.EndDateDescrip;
                    bvm.ExampleDescrip = findbr.ExampleDescrip;
                    //bvm.ExamplePic = findbr.ExamplePic;
                    bvm.FAQ = findbr.FAQ;
                    bvm.OptionsProductID = OPID;
                    bvm.PayDescrip = findbr.PayDescrip;
                    bvm.Price = findop.Price;
                    bvm.PriceType = findop.PriceType;
                    bvm.ProductName = findop.ProductName;
                    bvm.PurchaseAgreementURL = findbr.PurchaseAgreementURL;
                    bvm.RiskAnnouncementURL = findbr.RiskAnnouncementURL;
                    bvm.SettlementFormula = findbr.SettlementFormula;
                    //bvm.SFPic = findbr.SFPic;
                    bvm.StartDateDescrip = findbr.StartDateDescrip;
                    bvm.TradeDateDescrip = findbr.TradeDateDescrip;
                    return View(bvm);
                }
                
            }
            return View(new BrochureViewModel());
        }
        /// <summary>
        /// 购买须知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Buy(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr = BrochureRepository.Find(b => b.OptionsProductID == OPID);
                OptionsProduct findop = OptionsProductRepository.Find(op => op.OptionsProductID == OPID);
                if (findbr != null && findop != null)
                {
                    BrochureViewModel bvm = new BrochureViewModel();
                    bvm.AmountType = findop.AmountType;
                    bvm.BrochureID = findbr.BrochureID;
                    bvm.BuyBegin = findbr.BuyBegin;
                    bvm.BuyTime = findbr.BuyTime;
                    bvm.Contract = findop.Contract;
                    bvm.ContractDescrip = findbr.ContractDescrip;
                    bvm.Deadline = findop.Deadline;
                    bvm.EndDateDescrip = findbr.EndDateDescrip;
                    bvm.ExampleDescrip = findbr.ExampleDescrip;
                    //bvm.ExamplePic = findbr.ExamplePic;
                    bvm.FAQ = findbr.FAQ;
                    bvm.OptionsProductID = OPID;
                    bvm.PayDescrip = findbr.PayDescrip;
                    bvm.Price = findop.Price;
                    bvm.PriceType = findop.PriceType;
                    bvm.ProductName = findop.ProductName;
                    bvm.PurchaseAgreementURL = findbr.PurchaseAgreementURL;
                    bvm.RiskAnnouncementURL = findbr.RiskAnnouncementURL;
                    bvm.SettlementFormula = findbr.SettlementFormula;
                    //bvm.SFPic = findbr.SFPic;
                    bvm.StartDateDescrip = findbr.StartDateDescrip;
                    bvm.TradeDateDescrip = findbr.TradeDateDescrip;
                    return View(bvm);
                }

            }
            return View(new BrochureViewModel());
        }
        /// <summary>
        /// 补偿示例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Example(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr = BrochureRepository.Find(b => b.OptionsProductID == OPID);
                OptionsProduct findop = OptionsProductRepository.Find(op => op.OptionsProductID == OPID);
                if (findbr != null && findop != null)
                {
                    BrochureViewModel bvm = new BrochureViewModel();
                    bvm.AmountType = findop.AmountType;
                    bvm.BrochureID = findbr.BrochureID;
                    bvm.BuyBegin = findbr.BuyBegin;
                    bvm.BuyTime = findbr.BuyTime;
                    bvm.Contract = findop.Contract;
                    bvm.ContractDescrip = findbr.ContractDescrip;
                    bvm.Deadline = findop.Deadline;
                    bvm.EndDateDescrip = findbr.EndDateDescrip;
                    bvm.ExampleDescrip = findbr.ExampleDescrip;
                    //bvm.ExamplePic = findbr.ExamplePic;
                    bvm.FAQ = findbr.FAQ;
                    bvm.OptionsProductID = OPID;
                    bvm.PayDescrip = findbr.PayDescrip;
                    bvm.Price = findop.Price;
                    bvm.PriceType = findop.PriceType;
                    bvm.ProductName = findop.ProductName;
                    bvm.PurchaseAgreementURL = findbr.PurchaseAgreementURL;
                    bvm.RiskAnnouncementURL = findbr.RiskAnnouncementURL;
                    bvm.SettlementFormula = findbr.SettlementFormula;
                    //bvm.SFPic = findbr.SFPic;
                    bvm.StartDateDescrip = findbr.StartDateDescrip;
                    bvm.TradeDateDescrip = findbr.TradeDateDescrip;
                    return View(bvm);
                }

            }
            return View(new BrochureViewModel());
        }
    }
}