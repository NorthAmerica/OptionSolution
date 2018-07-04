using OP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OP.Entities;
using OP.Brochure.Models;
using OP.Brochure.Attribute;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OP.Brochure.Controllers
{
    public class HomeController : AsyncController
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
        public async Task<FileResult> ShowSFPic(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Guid gid = new Guid(id);
                    Entities.Brochure find = await BrochureRepository.FindAsync(b => b.BrochureID == gid);
                    byte[] image = find.SFPic;
                    return new FileContentResult(image, "image/jpeg");
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// 显示示例图
        /// </summary>
        /// <returns></returns>
        public async Task<FileResult> ShowExamplePic(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Guid gid = new Guid(id);
                    Entities.Brochure find = await BrochureRepository.FindAsync(b => b.BrochureID == gid);
                    byte[] image = find.ExamplePic;
                    return new FileContentResult(image, "image/jpeg");
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 宣传页首页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr = await BrochureRepository.FindAsync(b => b.OptionsProductID == OPID);
                OptionsProduct findop = await OptionsProductRepository.FindAsync(op => op.OptionsProductID == OPID);
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
                    bvm.ExamplePic = findbr.ExamplePic?.ToString();
                    bvm.FAQ = findbr.FAQ;
                    bvm.OptionsProductID = OPID;
                    bvm.PayDescrip = findbr.PayDescrip;
                    bvm.Price = findop.Price;
                    bvm.PriceType = findop.PriceType;
                    bvm.ProductName = findop.ProductName;
                    bvm.PurchaseAgreementURL = findbr.PurchaseAgreementURL;
                    bvm.RiskAnnouncementURL = findbr.RiskAnnouncementURL;
                    bvm.SettlementFormula = findbr.SettlementFormula;
                    bvm.SFPic = findbr.SFPic?.ToString();
                    bvm.StartDateDescrip = findbr.StartDateDescrip;
                    bvm.TradeDateDescrip = findbr.TradeDateDescrip;
                    return View(bvm);
                }

            }
            return View(new BrochureViewModel());
        }
        /// <summary>
        /// 二级宣传页面
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SecondIndex()
        {
            List<OptionsProduct> findops = await OptionsProductRepository.FindListAsync(o => o.Status == 1,null,false);
            List<BrochureViewModel> Lbvm = new List<BrochureViewModel>();
            if (findops!=null&&findops.Count!=0)
            {
                foreach (var findop in findops.OrderBy(f=>f.OrderID))
                {
                    Entities.Brochure findbr = await BrochureRepository.FindAsync(b => b.OptionsProductID == findop.OptionsProductID);
                    BrochureViewModel bvm = new BrochureViewModel();
                    bvm.OptionsProductID = findop.OptionsProductID;
                    bvm.AmountType = findop.AmountType;
                    bvm.BrochureID = findbr.BrochureID;
                    bvm.BuyBegin = findbr.BuyBegin;
                    bvm.BuyTime = findbr.BuyTime;
                    bvm.Contract = findop.Contract;
                    bvm.ContractDescrip = findbr.ContractDescrip;
                    bvm.Deadline = findop.Deadline;
                    bvm.EndDateDescrip = findbr.EndDateDescrip;
                    bvm.ExampleDescrip = findbr.ExampleDescrip;
                    bvm.FAQ = findbr.FAQ;
                    bvm.PayDescrip = Regex.Replace(findbr.PayDescrip, @"<[^>]+>", string.Empty);
                    bvm.Price = findop.Price;
                    bvm.PriceType = findop.PriceType;
                    bvm.ProductName = findop.ProductName;
                    bvm.PurchaseAgreementURL = findbr.PurchaseAgreementURL;
                    bvm.RiskAnnouncementURL = findbr.RiskAnnouncementURL;
                    
                    bvm.SettlementFormula = Regex.Replace(findbr.SettlementFormula, @"<[^>]+>", string.Empty);
                    bvm.StartDateDescrip = findbr.StartDateDescrip;
                    bvm.TradeDateDescrip = findbr.TradeDateDescrip;
                    Lbvm.Add(bvm);
                }
                
            }
            return View(Lbvm);
        }
        /// <summary>
        /// 购买须知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Buy(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr = await BrochureRepository.FindAsync(b => b.OptionsProductID == OPID);
                OptionsProduct findop = await OptionsProductRepository.FindAsync(op => op.OptionsProductID == OPID);
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
        public async Task<ActionResult> Example(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OPID = new Guid(id);
                Entities.Brochure findbr = await BrochureRepository.FindAsync(b => b.OptionsProductID == OPID);
                OptionsProduct findop = await OptionsProductRepository.FindAsync(op => op.OptionsProductID == OPID);
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