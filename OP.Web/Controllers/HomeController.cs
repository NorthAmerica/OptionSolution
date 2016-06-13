using Newtonsoft.Json;
using Op.Web.Attribute;
using OP.Entities;
using OP.Repository;
using OP.Web.Attribute;
using OP.Web.Component;
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
    //[CSRFValidateAntiForgeryToken]
    public class HomeController : Controller
    {
        private InterfaceUserRepository UserRepository;
        private InterfaceMenuRepository MenuRepository;
        private InterfaceRoleMenuRepository RoleMenuRepository;
        private InterfacePartnerRepository PartnerRepository;
        private InterfaceNumberTypeRepository NumberTypeRepository;
        private InterfaceOptionTypeRepository OptionTypeRepository;
        private InterfaceOptionsProductRepository OptionsProductRepository;
        private InterfaceFallRoleRepository FallRoleRepository;
        private InterfaceRiseRoleRepository RiseRoleRepository;
        private InterfacePartTypeRepository PartTypeRepository;
        private InterfaceUserRoleRepository UserRoleRepository;
        private InterfaceFuturesTradeVolumeRepository FuturesTradeVolumeRepository;
        private InterfaceFuturesFundRepository FuturesFundRepository;
        private InterfaceOptionTradeRepository OptionTradeRepository;
        //private InterfaceOptionTradeSumRepository OptionTradeSumRepository;
        private InterfaceFundStatusRepository FundStatusRepository;
        private InterfaceManageStatusRepository ManageStatusRepository;
        private InterfaceEventLogRepository LogRepository;
        private InterfaceCallPriceTypeRepository CallPriceTypeRepository;
        private InterfaceONOFFSetRepository ONOFFSetRepository;
        private InterfaceONTimeRepository ONTimeRepository;

        public HomeController(InterfaceMenuRepository menu,
            InterfaceRoleMenuRepository rolemenu,
            InterfaceUserRepository userrep,
            InterfacePartnerRepository partnerrep,
            InterfaceNumberTypeRepository numtyperep,
            InterfaceOptionTypeRepository optiontyperep,
            InterfaceOptionsProductRepository opproductrep,
            InterfaceFallRoleRepository fallrolerep,
            InterfaceRiseRoleRepository riserolerep,
            InterfacePartTypeRepository parttyperep,
            InterfaceUserRoleRepository userrolerep,
            InterfaceFuturesTradeVolumeRepository ftvrep,
            InterfaceFuturesFundRepository fundrep,
            InterfaceOptionTradeRepository traderep,
            InterfaceOptionTradeSumRepository tradesumrep,
            InterfaceFundStatusRepository fundstatusrep,
            InterfaceManageStatusRepository managestatusrep,
            InterfaceEventLogRepository eventlog,
            InterfaceCallPriceTypeRepository callpricetyperep,
            InterfaceONOFFSetRepository onoffsetrep,
            InterfaceONTimeRepository ontimerep)
        {
            MenuRepository = menu;
            RoleMenuRepository = rolemenu;
            UserRepository = userrep;
            PartnerRepository = partnerrep;
            NumberTypeRepository = numtyperep;
            OptionTypeRepository = optiontyperep;
            OptionsProductRepository = opproductrep;
            FallRoleRepository = fallrolerep;
            RiseRoleRepository = riserolerep;
            PartTypeRepository = parttyperep;
            UserRoleRepository = userrolerep;
            FuturesTradeVolumeRepository = ftvrep;
            FuturesFundRepository = fundrep;
            OptionTradeRepository = traderep;
            //OptionTradeSumRepository = tradesumrep;
            FundStatusRepository = fundstatusrep;
            ManageStatusRepository = managestatusrep;
            LogRepository = eventlog;
            CallPriceTypeRepository = callpricetyperep;
            ONOFFSetRepository = onoffsetrep;
            ONTimeRepository = ontimerep;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.ToString().EndsWith("Config"))
                {
                    int UserID = Convert.ToInt32(Session["UserID"]);
                    User finduser = UserRepository.Find(u => u.UserID == UserID);
                    Session["LoginedUser"] = finduser.UserName;
                    IEnumerable<UserRole> iur = UserRoleRepository.FindList(r => r.UserID == finduser.UserID, string.Empty, false).AsEnumerable<UserRole>();
                    List<int> lroleid = new List<int>();
                    List<int> lmenuid = new List<int>();
                    foreach (var ur in iur)
                    {
                        lroleid.Add(ur.RoleID);
                        IEnumerable<RoleMenu> irm = RoleMenuRepository.FindList(m => m.RoleID == ur.RoleID, string.Empty, false).AsEnumerable<RoleMenu>();
                        foreach (var rm in irm)
                        {
                            if (!lmenuid.Contains(rm.MenuID))
                            {
                                lmenuid.Add(rm.MenuID);
                            }
                        }
                    }
                    Session["IsAdmin"] = finduser.IsAdmin;
                    Session["Roles"] = lroleid;
                    Session["Menus"] = lmenuid;

                }
            }

            //Session.Clear();

            return View();
        }
        #region 登陆系统
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }
        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult LoginCheck(User user)
        {
            if (user != null)
            {
                string pwd = EncryptUtils.Base64Encrypt(user.UserPassword);
                User finduser = UserRepository.Find(u => u.UserName == user.UserName && u.UserPassword == pwd && u.Enable == true);
                if (finduser != null)
                {
                    Session["LoginedUser"] = finduser.UserName;
                    Session["UserID"] = finduser.UserID;
                    IEnumerable<UserRole> iur = UserRoleRepository.FindList(r => r.UserID == finduser.UserID, string.Empty, false).AsEnumerable<UserRole>();
                    List<int> lroleid = new List<int>();
                    List<int> lmenuid = new List<int>();
                    foreach (var ur in iur)
                    {
                        lroleid.Add(ur.RoleID);
                        IEnumerable<RoleMenu> irm = RoleMenuRepository.FindList(m => m.RoleID == ur.RoleID, string.Empty, false).AsEnumerable<RoleMenu>();
                        foreach (var rm in irm)
                        {
                            if (!lmenuid.Contains(rm.MenuID))
                            {
                                lmenuid.Add(rm.MenuID);
                            }
                        }
                    }
                    Session["IsAdmin"] = finduser.IsAdmin;
                    Session["Roles"] = lroleid;
                    Session["Menus"] = lmenuid;
                    LogRepository.Add(new EventLog() { Name = user.UserName, Date = DateTime.Now.ToLocalTime(), Event = "登陆验证成功" });
                    return Json(
                        new
                        {
                            Success = true
                        }, JsonRequestBehavior.DenyGet
                        );
                }
                else
                {
                    LogRepository.Add(new EventLog() { Name = user.UserName, Date = DateTime.Now.ToLocalTime(), Event = "登录名或密码错误" });
                    return Json(
                        new
                        {
                            Success = false,
                            Msg = "登录名或密码错误，请重新尝试。"
                        });
                }
            }

            return Json(
                new
                {
                    Success = false,
                    Msg = "数据传输有误，请重试或联系管理员。"
                });
        }
        #endregion
        /// <summary>
        /// 菜单创建
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult HomeMenu()
        {
            IEnumerable<Menu> allmenu = MenuRepository.FindAll().OrderBy(m => m.OrderNum).Where(m => m.FMenuID == 0);
            List<MenuTreeModel> lmtm = new List<MenuTreeModel>();
            if (allmenu != null && allmenu.Count() != 0)
            {
                foreach (var item in allmenu)
                {
                    List<int> imenu = (List<int>)Session["Menus"];
                    if (imenu.Contains(item.MenuID))
                    {
                        MenuTreeModel mtm = new MenuTreeModel();
                        mtm.MenuID = item.MenuID.ToString();
                        mtm.MenuName = item.MenuName;
                        mtm.MenuURL = item.MenuURL;
                        if (MenuRepository.Exist(m => m.FMenuID == item.MenuID))
                        {
                            IEnumerable<Menu> childs = MenuRepository.FindAll().OrderBy(m => m.OrderNum).Where(m => m.FMenuID == item.MenuID);
                            List<MenuTreeModel> ListChild = new List<MenuTreeModel>();
                            foreach (var childitem in childs)
                            {
                                if (imenu.Contains(childitem.MenuID))
                                {
                                    MenuTreeModel childmodel = new MenuTreeModel();
                                    childmodel.MenuID = childitem.MenuID.ToString();
                                    childmodel.MenuName = childitem.MenuName;
                                    childmodel.MenuURL = childitem.MenuURL;
                                    ListChild.Add(childmodel);
                                }
                            }
                            mtm.children = ListChild;
                        }

                        lmtm.Add(mtm);
                    }
                }
            }
            return PartialView(lmtm);
        }
        [ChildActionOnly]
        public PartialViewResult Head()
        {
            return PartialView();
        }
        #region 合作者配置
        /// <summary>
        /// 合作者配置
        /// </summary>
        /// <returns></returns>
        public ActionResult PartnerConfig()
        {
            return View();
        }
        /// <summary>
        /// 合作者数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult PartnerConfig_Read()
        {
            return Json(PartnerRepository.FindAll());
        }
        /// <summary>
        /// 新增合作者
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddPartner(Partner partner)
        {
            if (partner != null)
            {
                if (PartnerRepository.Add(partner) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "合作者添加成功" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "合作者添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到Partner信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPartnerDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int partnerid = Convert.ToInt32(ID);
                Partner findpartner = PartnerRepository.Find(u => u.PartnerID == partnerid);

                if (findpartner != null)
                {
                    return Json(new
                    {
                        Success = true,
                        PartnerName = findpartner.PartnerName,
                        PartnerDescribe = findpartner.PartnerDescribe
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新Partner
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdatePartner(Partner partner)
        {
            if (partner != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (PartnerRepository.Update(partner))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "合作者更新成功" });
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
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeletePartner(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int partnerid = Convert.ToInt32(ID);
                Partner findpartner = PartnerRepository.Find(u => u.PartnerID == partnerid);
                if (PartnerRepository.Delete(findpartner))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "合作者删除成功" });
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
        #endregion
        #region 数字配置
        /// <summary>
        /// 数字类型配置
        /// </summary>
        /// <returns></returns>
        public ActionResult NumberTypeConfig()
        {
            return View();
        }
        /// <summary>
        /// 数字类型数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult NumberTypeConfig_Read()
        {
            return Json(NumberTypeRepository.FindAll());
        }
        /// <summary>
        /// 新增数字类型
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddNumberType(NumberType numtype)
        {
            if (numtype != null)
            {
                if (NumberTypeRepository.Add(numtype) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增数字类型成功" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "数字类型添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到数字类型明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetNumberTypeDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                NumberType findtype = NumberTypeRepository.Find(u => u.NumberTypeID == typeid);

                if (findtype != null)
                {
                    return Json(new
                    {
                        Success = true,
                        NumberTypeName = findtype.NumberTypeName,
                        NumberTypeDescribe = findtype.NumberTypeDescribe
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新数字类型
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateNumberType(NumberType numtype)
        {
            if (numtype != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (NumberTypeRepository.Update(numtype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新数字类型成功" });
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
        /// <summary>
        /// 删除数字类型
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteNumberType(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                NumberType findtype = NumberTypeRepository.Find(u => u.NumberTypeID == typeid);
                if (NumberTypeRepository.Delete(findtype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除数字类型成功" });
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
        #endregion
        #region 期权类型配置
        public ActionResult OptionTypeConfig()
        {
            return View();
        }
        public ActionResult OptionTypeConfig_Read()
        {
            return Json(OptionTypeRepository.FindAll());
        }
        /// <summary>
        /// 新增期权类型
        /// </summary>
        /// <param name="optype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddOptionType(OptionType optype)
        {
            if (optype != null)
            {
                if (OptionTypeRepository.Add(optype) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增期权类型成功" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "期权类型添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到OptionType详情
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOptionTypeDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                OptionType findtype = OptionTypeRepository.Find(u => u.OptionTypeID == typeid);

                if (findtype != null)
                {
                    return Json(new
                    {
                        Success = true,
                        OptionTypeName = findtype.OptionTypeName,
                        OptionTypeDescribe = findtype.OptionTypeDescribe
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新OptionType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateOptionType(OptionType type)
        {
            if (type != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (OptionTypeRepository.Update(type))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新期权类型成功" });
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
        /// <summary>
        /// 删除OptionType
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteOptionType(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                OptionType findtype = OptionTypeRepository.Find(u => u.OptionTypeID == typeid);
                if (OptionTypeRepository.Delete(findtype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除期权类型成功" });
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
        #endregion
        #region 期权产品配置
        public ActionResult OptionsProductConfig()
        {
            return View();
        }
        /// <summary>
        /// 期权产品数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        //[CSRFValidateAntiForgeryToken]
        public ActionResult OptionsProductConfig_Read(int? page, int? rows, string PartnerName, string ProductName, string OptionType, string BeginDate)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            IEnumerable<OptionsProduct> iop = OptionsProductRepository.FindAll();
            if (!string.IsNullOrEmpty(PartnerName))
            {
                iop = iop.Where(o => !string.IsNullOrEmpty(o.PartnerName) && o.PartnerName.Contains(PartnerName));
            }
            if (!string.IsNullOrEmpty(ProductName))
            {
                iop = iop.Where(o => !string.IsNullOrEmpty(o.ProductName) && o.ProductName.Contains(ProductName));
            }
            if (!string.IsNullOrEmpty(OptionType))
            {
                iop = iop.Where(o => !string.IsNullOrEmpty(OptionType) && o.OptionType.Contains(OptionType));
            }
            if (!string.IsNullOrEmpty(BeginDate))
            {
                iop = iop.Where(o => Convert.ToDateTime(o.BeginDate).ToString("yyyy-MM-dd") == BeginDate);
            }
            var riop = iop.OrderByDescending(p=>p.AddDate).Select(
                p => new
                {
                    AddDate = Convert.ToDateTime(p.AddDate).ToString("yyyy-MM-dd"),
                    p.AmountType,
                    BeginDate = Convert.ToDateTime(p.BeginDate).ToString("yyyy-MM-dd"),
                    p.CallPriceType,
                    p.Charge,
                    p.ChargeType,
                    p.Contract,
                    p.ContractChs,
                    p.Deadline,
                    EndDate = Convert.ToDateTime(p.EndDate).ToString("yyyy-MM-dd"),
                    p.Formula,
                    p.IsUpLoad,
                    p.MaxNum,
                    p.OptionsProductID,
                    p.OptionType,
                    p.PartnerName,
                    p.Price,
                    p.PriceType,
                    p.ProductDesc,
                    p.ProductDescription,
                    p.ProductDtlDesc,
                    p.ProductName,
                    p.ProductUrl,
                    p.Status,
                    p.Unit
                }).ToList();
            return Json(new
            {
                total = riop.Count(),
                rows = riop.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 上传Excel期权产品
        /// </summary>
        /// <returns></returns>
        [CSRFValidateAntiForgeryToken]
        public ActionResult UploadOptionsProduct(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    string fileExtenSion = Path.GetExtension(uploadedFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/FileUpLoad/"), System.IO.Path.GetFileName(uploadedFile.FileName));
                    uploadedFile.SaveAs(path);//将文件保存到本地
                    DataSet ds = ExcelReader.ReadOptionsProductExcel(fileExtenSion, path);
                    if (ds == null || ds.Tables["OptionsProduct"].Rows.Count == 0)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据数量为空，请重新检查文件。"
                        });
                    }
                    if (ds.Tables["OptionsProduct"].Columns.Count < 2)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据列数量有误，请重新检查数据是否合格。"
                        });
                    }
                    int count = 0;
                    foreach (DataRow item in ds.Tables["OptionsProduct"].Rows)
                    {
                        if (string.IsNullOrEmpty(item[0].ToString()))
                        {
                            continue;
                        }
                        if (item[16].ToString() != "固定值" && item[16].ToString() != "单位值")
                        {
                            throw new Exception("产品表16列应该为固定值或者单位值");
                        }
                        if (item[17].ToString() != "保证金" && item[17].ToString() != "保费")
                        {
                            throw new Exception("产品表17列应该为保证金或者保费");
                        }
                        //FuturesTradeVolume TradeVolume = new FuturesTradeVolume();
                        OptionsProduct op = new OptionsProduct();
                        op.PartnerName = item[1].ToString();
                        op.ProductName = item[2].ToString();
                        op.ProductDescription = item[3].ToString();
                        op.ProductDesc = item[4].ToString();
                        op.ProductDtlDesc = item[5].ToString();
                        op.Formula = item[6].ToString();
                        op.ProductUrl = item[7].ToString();
                        op.Contract = item[8].ToString();
                        op.ContractChs = item[9].ToString();
                        op.OptionType = item[10].ToString();
                        op.Deadline = string.IsNullOrEmpty(item[11].ToString()) ? 0 : Convert.ToInt32(item[11].ToString());
                        op.Unit = item[12].ToString();
                        op.Charge = string.IsNullOrEmpty(item[13].ToString()) ? 0 : Convert.ToDecimal(item[13].ToString());
                        op.ChargeType = item[14].ToString();
                        op.Price = string.IsNullOrEmpty(item[15].ToString()) ? 0 : Convert.ToDecimal(item[15].ToString());
                        op.PriceType = item[16].ToString();
                        op.AmountType = item[17].ToString();
                        op.MaxNum = string.IsNullOrEmpty(item[18].ToString()) ? 0 : Convert.ToInt32(item[18].ToString());
                        op.CallPriceType = item[19].ToString();
                        op.Status = 0;
                        op.IsUpLoad = false;
                        op.AddDate = DateTime.Now.ToLocalTime();
                        string ID = item[0].ToString();
                        OptionsProduct NewProduct = OptionsProductRepository.Add(op);
                        foreach (DataRow fall in ds.Tables["FallRole"].Rows)
                        {
                            if (fall[0].ToString() == ID)
                            {
                                FallRole fr = new FallRole();
                                fr.FallRoleName = fall[1].ToString();
                                fr.Up = string.IsNullOrEmpty(fall[2].ToString()) ? 0 : Convert.ToDecimal(fall[2].ToString());
                                fr.Down = string.IsNullOrEmpty(fall[3].ToString()) ? 0 : Convert.ToDecimal(fall[3].ToString());
                                fr.PartType = fall[4].ToString();
                                fr.CompensateNum = string.IsNullOrEmpty(fall[5].ToString()) ? 0 : Convert.ToDecimal(fall[5].ToString());
                                fr.TopCompensateNum = string.IsNullOrEmpty(fall[6].ToString()) ? 0 : Convert.ToDecimal(fall[6].ToString());
                                fr.CreateDate = DateTime.Now.ToLocalTime().ToString();
                                fr.UpDownType = "固定值";
                                fr.CompensateType = "百分比";
                                fr.TopCompensateType = "单位值";
                                fr.OptionsProductID = NewProduct.OptionsProductID;
                                FallRoleRepository.Add(fr);
                                count++;
                            }
                        }
                        foreach (DataRow rise in ds.Tables["RiseRole"].Rows)
                        {
                            if (rise[0].ToString() == ID)
                            {
                                RiseRole rr = new RiseRole();
                                rr.RiseRoleName = rise[1].ToString();
                                rr.Up = string.IsNullOrEmpty(rise[2].ToString()) ? 0 : Convert.ToDecimal(rise[2].ToString());
                                rr.Down = string.IsNullOrEmpty(rise[3].ToString()) ? 0 : Convert.ToDecimal(rise[3].ToString());
                                rr.PartType = rise[4].ToString();
                                rr.DividendNum = string.IsNullOrEmpty(rise[5].ToString()) ? 0 : Convert.ToDecimal(rise[5].ToString());
                                rr.TopDividendNum = string.IsNullOrEmpty(rise[6].ToString()) ? 0 : Convert.ToDecimal(rise[6].ToString());
                                rr.CreateDate = DateTime.Now.ToLocalTime().ToString();
                                rr.UpDownType = "固定值";
                                rr.DividendType = "百分比";
                                rr.TopDividendType = "单位值";
                                rr.OptionsProductID = NewProduct.OptionsProductID;
                                RiseRoleRepository.Add(rr);
                                count++;
                            }
                        }
                        count++;
                    }
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "上传期权产品数据" + count.ToString() + "条数据。" });
                    return Json(new
                    {
                        statusCode = 200,
                        status = "已经上传" + count.ToString() + "条数据。"
                    });
                }
                else
                {
                    return Json(new
                    {
                        statusCode = 400,
                        status = "文件传输有误，请重新上传。"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    statusCode = 400,
                    status = "文件上传发生异常," + ex.Message
                });
            }

        }
        /// <summary>
        /// 得到合作伙伴信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPartner()
        {
            return Json(PartnerRepository.FindAll());
        }
        /// <summary>
        /// 得到处理状态
        /// </summary>
        /// <returns></returns>
        public ActionResult GetManageStatus()
        {
            return Json(ManageStatusRepository.FindAll());
        }
        /// <summary>
        /// 得到期权类型信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOptionType()
        {
            return Json(OptionTypeRepository.FindAll());
        }
        /// <summary>
        /// 新增期权产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddOptionsProduct(OptionsProduct product)
        {
            if (product != null)
            {
                product.AddDate = DateTime.Now.ToLocalTime();
                product.Status = 0;
                product.IsUpLoad = false;
                if (OptionsProductRepository.Add(product) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增期权产品成功" });
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
        /// <summary>
        /// 得到期权产品详细信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOptionsProductDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                Guid gid = new Guid(ID);
                OptionsProduct op = OptionsProductRepository.Find(p => p.OptionsProductID == gid);
                if (op != null)
                {
                    return Json(new
                    {
                        Success = true,
                        AddDate = op.AddDate,
                        AmountType = op.AmountType,
                        BeginDate = op.BeginDate,
                        CallPriceType = op.CallPriceType,
                        Charge = op.Charge,
                        ChargeType = op.ChargeType,
                        Deadline = op.Deadline,
                        EndDate = op.EndDate,
                        Formula = op.Formula,
                        MaxNum = op.MaxNum,
                        OptionType = op.OptionType,
                        OptionsProductID = op.OptionsProductID,
                        PartnerName = op.PartnerName,
                        Price = op.Price,
                        PriceType = op.PriceType,
                        ProductDesc = op.ProductDesc,
                        ProductDtlDesc = op.ProductDtlDesc,
                        ProductName = op.ProductName,
                        ProductUrl = op.ProductUrl,
                        Status = op.Status,
                        Unit = op.Unit,
                        Contract = op.Contract,
                        ContractChs = op.ContractChs
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 拷贝期权产品
        /// 废弃
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult CopyOptionsProduct(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                OptionsProduct NewProduct = new OptionsProduct();
                //int id = Convert.ToInt32(ID);
                Guid gid = new Guid(ID);
                OptionsProduct old = OptionsProductRepository.Find(p => p.OptionsProductID == gid);
                if (old != null)
                {
                    NewProduct.AddDate = DateTime.Now.ToLocalTime();
                    //NewProduct.BeginDate = old.BeginDate;
                    NewProduct.Charge = old.Charge;
                    NewProduct.ChargeType = old.ChargeType;
                    NewProduct.Deadline = old.Deadline;
                    NewProduct.EndDate = old.EndDate;
                    //NewProduct.Margin = old.Margin;
                    //NewProduct.MarginType = old.MarginType;
                    NewProduct.MaxNum = old.MaxNum;
                    NewProduct.OptionType = old.OptionType;
                    NewProduct.CallPriceType = old.CallPriceType;
                    NewProduct.PartnerName = old.PartnerName;
                    NewProduct.Price = old.Price;
                    NewProduct.PriceType = old.PriceType;
                    NewProduct.AmountType = old.AmountType;
                    NewProduct.ProductName = old.ProductName;
                    NewProduct.Status = 0;
                    NewProduct.Unit = old.Unit;
                    NewProduct.ProductDesc = old.ProductDesc;
                    NewProduct.ProductDtlDesc = old.ProductDtlDesc;
                    NewProduct.Formula = old.Formula;
                    NewProduct.ProductUrl = old.ProductUrl;
                    NewProduct.Contract = old.Contract;
                    NewProduct.ContractChs = old.ContractChs;
                    Guid newid = OptionsProductRepository.Add(NewProduct).OptionsProductID;
                    List<FallRole> lfr = FallRoleRepository.FindList(f => f.OptionsProductID == old.OptionsProductID, string.Empty, false).ToList();
                    if (lfr != null && lfr.Count() != 0)
                    {
                        foreach (var fall in lfr)
                        {
                            FallRole NewFall = new FallRole();
                            NewFall.CompensateNum = fall.CompensateNum;
                            NewFall.CompensateType = fall.CompensateType;
                            NewFall.CreateDate = DateTime.Now.ToString();
                            NewFall.Down = fall.Down;
                            NewFall.FallRoleName = fall.FallRoleName;
                            NewFall.OptionsProductID = newid;
                            NewFall.PartType = fall.PartType;
                            NewFall.TopCompensateNum = fall.TopCompensateNum;
                            NewFall.TopCompensateType = fall.TopCompensateType;
                            NewFall.Up = fall.Up;
                            NewFall.UpDownType = fall.UpDownType;
                            FallRoleRepository.Add(NewFall);
                        }
                    }
                    List<RiseRole> lrr = RiseRoleRepository.FindList(r => r.OptionsProductID == old.OptionsProductID, string.Empty, false).ToList();
                    if (lrr != null && lrr.Count() != 0)
                    {
                        foreach (var rise in lrr)
                        {
                            RiseRole NewRise = new RiseRole();
                            NewRise.CreateDate = DateTime.Now.ToString();
                            NewRise.DividendNum = rise.DividendNum;
                            NewRise.DividendType = rise.DividendType;
                            NewRise.Down = rise.Down;
                            NewRise.OptionsProductID = newid;
                            NewRise.PartType = rise.PartType;
                            NewRise.RiseRoleName = rise.RiseRoleName;
                            NewRise.TopDividendNum = rise.TopDividendNum;
                            NewRise.TopDividendType = rise.TopDividendType;
                            NewRise.Up = rise.Up;
                            NewRise.UpDownType = rise.UpDownType;
                            RiseRoleRepository.Add(NewRise);
                        }
                    }
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "拷贝期权产品成功" });
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
        /// <summary>
        /// 上传产品到第三方系统
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UpOptionsProduct(string PartnerName, string[] id)
        {
            try
            {
                if (string.IsNullOrEmpty(PartnerName) || id.Length == 0)
                {
                    throw new Exception("合作方名称或者选择产品为空");
                }
                OPM sendList = GetAllProducts(PartnerName,id);
                string jsonstring = DESEncrypt.DesEncrypt(JsonConvert.SerializeObject(sendList));
                //byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonstring);
                //ByteArrayContent bac = new ByteArrayContent(postData);

                string responsestring = await UpKwinerProduct.UpAction(jsonstring);
                ReturnModel rm = JsonConvert.DeserializeObject<ReturnModel>(DESEncrypt.DesDecrypt(responsestring));
                if (rm.Result == "1")
                {
                    LogRepository.Add(new EventLog { Name = "上传产品到第三方系统", Date = DateTime.Now, Event = "上传成功" });
                    foreach (var product in sendList.products)
                    {
                        OptionsProduct findop = await OptionsProductRepository.FindAsync(op => op.OptionsProductID == product.optionsProductID);
                        findop.IsUpLoad = true;
                        OptionsProductRepository.Update(findop);
                    }
                    return Json(new { Success = true });
                }
                else
                {
                    LogRepository.Add(new EventLog { Name = "上传产品到第三方系统", Date = DateTime.Now, Event = "上传失败，第三方返回" + rm.Message });
                    return Json(new { Success = false, Message = "第三方返回"+rm.Message });
                }

            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog { Name = "上传产品到第三方系统", Date = DateTime.Now, Event = "上传失败，" + ex.Message });
                return Json(new { Success = false, Message = ex.Message });
            }

        }
        /// <summary>
        /// 《！废弃！》返回JSon数据
        /// </summary>
        /// <param name="JSON"></param>
        /// <param name="URL"></param>
        /// <returns></returns>
        //public string GetResponseDataByWebClient(string JSON, string URL)
        //{
        //    //模拟浏览器登录
        //    System.Net.WebClient wCient = new System.Net.WebClient();
        //    //wCient.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
        //    //wCient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        //    wCient.Headers.Add("Content-Type", "text/html; charset=UTF-8");
        //    //wCient.Headers.Add("Host", Host);
        //    //wCient.Headers.Add("Origin", "http://odds.zgzcw.com");
        //    //wCient.Headers.Add("Referer", "http://odds.zgzcw.com/");
        //    //wCient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36");
        //    //wCient.Headers.Add("X-Requested-With", "XMLHttpRequest");
        //    //string responsestring = wCient.UploadString(URL, "POST", JSON);
        //    byte[] postData = System.Text.Encoding.UTF8.GetBytes(JSON);
        //    byte[] responseData = wCient.UploadData(URL, "POST", postData);
        //    string returnStr = System.Text.Encoding.UTF8.GetString(responseData);//返回接受的数据
        //    return returnStr;
        //}
        /// <summary>
        /// 《！废弃！》返回JSon数据
        /// </summary>
        /// <param name="JSONData">要处理的JSON数据</param>
        /// <param name="Url">要提交的URL</param>
        /// <returns>返回的JSON处理字符串</returns>
        //public string GetResponseDataByWebRequest(string JSONData, string Url)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(JSONData);
        //    System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        //    request.Method = "POST";
        //    request.ContentLength = bytes.Length;
        //    request.ContentType = "text/xml";
        //    Stream reqstream = request.GetRequestStream();
        //    reqstream.Write(bytes, 0, bytes.Length);

        //    //声明一个HttpWebRequest请求
        //    request.Timeout = 90000;
        //    //设置连接超时时间
        //    request.Headers.Set("Pragma", "no-cache");
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream streamReceive = response.GetResponseStream();
        //    Encoding encoding = Encoding.UTF8;

        //    StreamReader streamReader = new StreamReader(streamReceive, encoding);
        //    string strResult = streamReader.ReadToEnd();
        //    streamReceive.Dispose();
        //    streamReader.Dispose();

        //    return strResult;
        //}
        /// <summary>
        /// 得到正在发行的产品
        /// </summary>
        /// <returns></returns>
        private OPM GetAllProducts(string PartnerName, string[] id)
        {
            OPM SendOPM = new OPM();
            List<OptionsProductModel> lopm = new List<OptionsProductModel>();
            List<OptionsProduct> iop = new List<OptionsProduct>();
            foreach (var item in id)
            {
                Guid gid = new Guid(item);
                OptionsProduct findop = OptionsProductRepository.Find(p => p.Status != 0 && p.PartnerName == PartnerName && p.OptionsProductID == gid);
                if (findop != null)
                {
                    iop.Add(findop);
                }
            }
            //IEnumerable<OptionsProduct> iop = OptionsProductRepository.FindAll().Where(p => p.Status!= 0&&p.PartnerName== PartnerName);
            if (iop != null && iop.Count() != 0)
            {
                foreach (var item in iop)
                {
                    OptionsProductModel opm = new OptionsProductModel();
                    opm.addDate = Convert.ToDateTime(item.AddDate).ToString("yyyy-MM-dd HH:mm:ss");
                    opm.beginDate = Convert.ToDateTime(item.BeginDate).ToString("yyyy-MM-dd HH:mm:ss");
                    opm.charge = item.Charge;
                    opm.chargeType = item.ChargeType;
                    opm.deadline = item.Deadline;
                    opm.endDate = string.Empty;
                    opm.callPriceType = item.CallPriceType;
                    opm.contract = item.Contract;
                    opm.contractChs = item.ContractChs;
                    //opm.Margin = item.Margin;
                    //opm.MarginType = item.MarginType;
                    opm.maxNum = item.MaxNum;
                    opm.optionsProductID = item.OptionsProductID;
                    opm.optionType = item.OptionType;
                    opm.partnerName = item.PartnerName;
                    opm.price = item.Price;
                    opm.priceType = item.PriceType;
                    opm.amountType = item.AmountType;
                    opm.productName = item.ProductName;
                    opm.status = item.Status;
                    opm.unit = item.Unit;
                    opm.productDesc = item.ProductDesc;
                    opm.formula = item.Formula;
                    opm.productDtlDesc = item.ProductDtlDesc;
                    opm.productUrl = item.ProductUrl;
                    List<FallRoleModel> lfrm = new List<FallRoleModel>();
                    List<FallRole> lfr = FallRoleRepository.FindList(f => f.OptionsProductID == item.OptionsProductID, string.Empty, false).ToList();
                    if (lfr != null && lfr.Count() != 0)
                    {
                        foreach (var fall in lfr)
                        {
                            FallRoleModel frm = new FallRoleModel();
                            frm.compensateNum = fall.CompensateNum;
                            frm.compensateType = fall.CompensateType;
                            frm.createDate = Convert.ToDateTime(fall.CreateDate).ToString("yyyy-MM-dd HH:mm:ss");
                            frm.down = fall.Down;
                            frm.fallRoleID = fall.FallRoleID;
                            frm.fallRoleName = fall.FallRoleName;
                            frm.optionsProductID = fall.OptionsProductID;
                            frm.partType = fall.PartType;
                            frm.topCompensateNum = fall.TopCompensateNum;
                            frm.topCompensateType = fall.TopCompensateType;
                            frm.up = fall.Up;
                            frm.upDownType = fall.UpDownType;
                            lfrm.Add(frm);
                        }
                    }
                    opm.fallRole = lfrm;
                    List<RiseRoleModel> lrrm = new List<RiseRoleModel>();
                    List<RiseRole> lrr = RiseRoleRepository.FindList(r => r.OptionsProductID == item.OptionsProductID, string.Empty, false).ToList();
                    if (lrr != null && lrr.Count() != 0)
                    {
                        foreach (var rise in lrr)
                        {
                            RiseRoleModel rrm = new RiseRoleModel();
                            rrm.createDate = Convert.ToDateTime(rise.CreateDate).ToString("yyyy-MM-dd HH:mm:ss");
                            rrm.dividendNum = rise.DividendNum;
                            rrm.dividendType = rise.DividendType;
                            rrm.down = rise.Down;
                            rrm.optionsProductID = rise.OptionsProductID;
                            rrm.partType = rise.PartType;
                            rrm.riseRoleID = rise.RiseRoleID;
                            rrm.riseRoleName = rise.RiseRoleName;
                            rrm.topDividendNum = rise.TopDividendNum;
                            rrm.topDividendType = rise.TopDividendType;
                            rrm.up = rise.Up;
                            rrm.upDownType = rise.UpDownType;
                            lrrm.Add(rrm);
                        }
                    }
                    opm.riseRole = lrrm;
                    lopm.Add(opm);
                }
                SendOPM.products = lopm;
            }

            return SendOPM;
        }
        /// <summary>
        /// 获取下跌规则
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult FallRoleGrid_Read(string id)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();

            if (!string.IsNullOrEmpty(id))
            {
                //int intid = Convert.ToInt32(id);
                Guid gid = new Guid(id);
                IEnumerable<FallRole> ifr = FallRoleRepository.FindList(f => f.OptionsProductID == gid, string.Empty, false).AsEnumerable<FallRole>();
                if (ifr != null && ifr.Count() != 0)
                {
                    return Json(ifr);
                }
            }
            return Json(new { });
        }
        /// <summary>
        /// 新增下跌规则
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddFallRole(FallRole fallrole)
        {
            if (fallrole != null)
            {
                fallrole.CreateDate = DateTime.Now.ToLocalTime().ToString();
                if (FallRoleRepository.Add(fallrole) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增下跌规则成功" });
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
        /// <summary>
        /// 获取上涨规则
        /// </summary>
        /// <returns></returns>
        public ActionResult RiseRoleGrid_Read(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                //int intid = Convert.ToInt32(id);
                Guid gid = new Guid(id);
                IEnumerable<RiseRole> irr = RiseRoleRepository.FindList(f => f.OptionsProductID == gid, string.Empty, false).AsEnumerable<RiseRole>();
                if (irr != null && irr.Count() != 0)
                {
                    return Json(irr);
                }
            }
            return Json(new { });
        }
        /// <summary>
        /// 新增上涨规则
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddRiseRole(RiseRole riserole)
        {
            if (riserole != null)
            {
                riserole.CreateDate = DateTime.Now.ToLocalTime().ToString();
                if (RiseRoleRepository.Add(riserole) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增上涨规则成功" });
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
        /// <summary>
        /// 启动期权产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult BeginOptionsProduct(string[] id)
        {
            if (id.Length != 0)
            {
                foreach (var itemid in id)
                {
                    //int intid = Convert.ToInt32(id);
                    Guid gid = new Guid(itemid);
                    if (OptionsProductRepository.Exist(o => o.OptionsProductID == gid))
                    {
                        OptionsProduct op = OptionsProductRepository.Find(o => o.OptionsProductID == gid);
                        op.Status = 1;
                        op.BeginDate = DateTime.Now.ToLocalTime();
                        if (OptionsProductRepository.Update(op))
                        {
                            LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "启动期权产品成功" });
                        }
                        else
                        {
                            return Json(new
                            {
                                Success = false
                            });
                        }
                    }
                }
                return Json(new
                {
                    Success = true
                });

            }
            return Json(new
            {
                Success = false
            });
        }
        /// <summary>
        /// 停用期权产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult EndOptionsProduct(string[] id)
        {
            if (id.Length != 0)
            {
                foreach (var itemid in id)
                {
                    //int intid = Convert.ToInt32(id);
                    Guid gid = new Guid(itemid);
                    if (OptionsProductRepository.Exist(o => o.OptionsProductID == gid))
                    {
                        OptionsProduct op = OptionsProductRepository.Find(o => o.OptionsProductID == gid);
                        op.Status = 2;
                        op.EndDate = DateTime.Now.ToLocalTime();
                        if (OptionsProductRepository.Update(op))
                        {
                            LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "停用期权产品成功" });
                        }
                        else
                        {
                            return Json(new
                            {
                                Success = true
                            });
                        }
                    }
                }
                return Json(new
                {
                    Success = true
                });
            }
            return Json(new
            {
                Success = false
            });
        }
        /// <summary>
        /// 得到所有数字类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNumberType()
        {
            return Json(NumberTypeRepository.FindAll());
        }
        /// <summary>
        /// 得到所有部分类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPartType()
        {
            return Json(PartTypeRepository.FindAll());
        }
        /// <summary>
        /// 得到所有结算价类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCallPriceType()
        {
            return Json(CallPriceTypeRepository.FindAll());
        }
        #endregion
        #region 部分类型配置
        /// <summary>
        /// 部分类型配置
        /// </summary>
        /// <returns></returns>
        public ActionResult PartTypeConfig()
        {
            return View();
        }
        /// <summary>
        /// 部分类型数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult PartTypeConfig_Read()
        {
            return Json(PartTypeRepository.FindAll());
        }
        /// <summary>
        /// 新增部分类型
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddPartType(PartType parttype)
        {
            if (parttype != null)
            {
                if (PartTypeRepository.Add(parttype) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增部分类型成功" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "部分类型添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到部分类型明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPartTypeDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                PartType findtype = PartTypeRepository.Find(u => u.PartTypeID == typeid);

                if (findtype != null)
                {
                    return Json(new
                    {
                        Success = true,
                        PartTypeName = findtype.PartTypeName,
                        PartTypeDescribe = findtype.PartTypeDescribe
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新部分类型
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdatePartType(PartType parttype)
        {
            if (parttype != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (PartTypeRepository.Update(parttype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新部分类型成功" });
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
        /// <summary>
        /// 删除部分类型
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeletePartType(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                PartType findtype = PartTypeRepository.Find(u => u.PartTypeID == typeid);
                if (PartTypeRepository.Delete(findtype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除部分类型成功" });
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
        #endregion
        #region 处理状态配置
        public ActionResult ManageStatusConfig()
        {
            return View();
        }
        /// <summary>
        /// 处理状态数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageStatusConfig_Read()
        {
            return Json(ManageStatusRepository.FindAll());
        }
        /// <summary>
        /// 新增处理状态
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddManageStatus(ManageStatus ms)
        {
            if (ms != null)
            {
                if (ManageStatusRepository.Add(ms) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增处理状态成功" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "处理状态添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到处理状态明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetManageStatusDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                ManageStatus findtype = ManageStatusRepository.Find(u => u.ManageStatusID == typeid);

                if (findtype != null)
                {
                    return Json(new
                    {
                        Success = true,
                        ManageStatusName = findtype.ManageStatusName,
                        ManageStatusNum = findtype.ManageStatusNum
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新处理状态
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateManageStatus(ManageStatus parttype)
        {
            if (parttype != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (ManageStatusRepository.Update(parttype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新处理状态成功" });
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
        /// <summary>
        /// 删除处理状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteManageStatus(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                ManageStatus findtype = ManageStatusRepository.Find(u => u.ManageStatusID == typeid);
                if (ManageStatusRepository.Delete(findtype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除处理状态成功" });
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
        #endregion
        #region 资金状态配置
        public ActionResult FundStatusConfig()
        {
            return View();
        }
        /// <summary>
        /// 资金状态数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult FundStatusConfig_Read()
        {
            return Json(FundStatusRepository.FindAll());
        }
        /// <summary>
        /// 新增资金状态
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddFundStatus(FundStatus ms)
        {
            if (ms != null)
            {
                if (FundStatusRepository.Add(ms) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增资金状态成功" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "资金状态添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到资金状态明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFundStatusDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                FundStatus findtype = FundStatusRepository.Find(u => u.FundStatusID == typeid);

                if (findtype != null)
                {
                    return Json(new
                    {
                        Success = true,
                        FundStatusName = findtype.FundStatusName,
                        FundStatusNum = findtype.FundStatusNum
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新资金状态
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateFundStatus(FundStatus parttype)
        {
            if (parttype != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (FundStatusRepository.Update(parttype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新资金状态成功" });
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
        /// <summary>
        /// 删除资金状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteFundStatus(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    int typeid = Convert.ToInt32(ID);
                    FundStatus findtype = FundStatusRepository.Find(u => u.FundStatusID == typeid);
                    if (FundStatusRepository.Delete(findtype))
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除资金状态成功" });
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
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            
        }
        #endregion
        #region 期货成交情况
        public ActionResult FuturesTradeList()
        {
            return View();
        }
        /// <summary>
        /// FuturesTradeGrid数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult FuturesTradeGrid_Read(int? page, int? rows, string ZH, string JYR)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            IEnumerable<FuturesTradeVolume> iftv = FuturesTradeVolumeRepository.FindAll();
            if (!string.IsNullOrEmpty(ZH))
            {
                iftv = iftv.Where(f => f.ZH.Contains(ZH));
            }
            if (!string.IsNullOrEmpty(JYR))
            {
                string jyr = Convert.ToDateTime(JYR).ToString("yyyyMMdd");
                iftv = iftv.Where(f => f.JYR.Contains(jyr));
            }
            return Json(new
            {
                total = iftv.Count(),
                rows = iftv.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 上传期货成交数据
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateFuturesTradeData(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    string fileExtenSion = Path.GetExtension(uploadedFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/FileUpLoad/"), System.IO.Path.GetFileName(uploadedFile.FileName));
                    uploadedFile.SaveAs(path);//将文件保存到本地
                    DataTable dt = ExcelReader.ReadExcel(fileExtenSion, path);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据数量为空，请重新检查文件。"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    if (dt.Columns.Count < 2)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据列数量有误，请重新检查数据是否合格。"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    int count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        FuturesTradeVolume TradeVolume = new FuturesTradeVolume();
                        TradeVolume.ZH = item[0].ToString();
                        TradeVolume.JYR = item[1].ToString();
                        TradeVolume.WTH = item[2].ToString();
                        TradeVolume.CJH = item[3].ToString();
                        TradeVolume.QQH = item[4].ToString();
                        TradeVolume.JYS = item[5].ToString();
                        TradeVolume.HY = item[6].ToString();
                        TradeVolume.MM = item[7].ToString();
                        TradeVolume.KP = item[8].ToString();
                        TradeVolume.TB = item[9].ToString();
                        TradeVolume.CJJ = Convert.ToDecimal(item[10]);
                        TradeVolume.CJL = Convert.ToDecimal(item[11]);
                        TradeVolume.CJJE = Convert.ToDecimal(item[12]);
                        TradeVolume.SJRQ = item[13].ToString();
                        TradeVolume.CJSJ = Convert.ToDateTime(item[14]).ToString("HH:mm:ss");
                        TradeVolume.ZZH = item[15].ToString();
                        TradeVolume.XTH = item[16].ToString();
                        TradeVolume.SXF = Convert.ToDecimal(item[17]);
                        TradeVolume.PCFDYK = Convert.ToDecimal(item[18]);
                        TradeVolume.PCYK = Convert.ToDecimal(item[19]);
                        TradeVolume.JCSXF = Convert.ToDecimal(item[20]);
                        FuturesTradeVolumeRepository.Add(TradeVolume);
                        count++;
                    }
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "上传期货成交数据" + count.ToString() + "条数据。" });
                    return Json(new
                    {
                        statusCode = 200,
                        status = "已经上传" + count.ToString() + "条数据。"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        statusCode = 400,
                        status = "文件传输有误，请重新上传。"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    statusCode = 400,
                    status = "文件上传发生异常," + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region 期货账户资金
        public ActionResult FuturesFundList()
        {
            return View();
        }
        public ActionResult FuturesFundGrid_Read(int? page, int? rows, string ZH, string KSRQ, string JSRQ)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            IEnumerable<FuturesFund> iff = FuturesFundRepository.FindAll();
            if (!string.IsNullOrEmpty(ZH))
            {
                iff = iff.Where(f => f.ZH.Contains(ZH));
            }
            if (!string.IsNullOrEmpty(KSRQ))
            {
                iff = iff.Where(f => f.KSRQ.Contains(KSRQ));
            }
            if (!string.IsNullOrEmpty(JSRQ))
            {
                iff = iff.Where(f => f.JSRQ.Contains(JSRQ));
            }
            return Json(new
            {
                total = iff.Count(),
                rows = iff.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 上传期货资金表
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateFuturesFundData(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    string fileExtenSion = Path.GetExtension(uploadedFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/FileUpLoad/"), System.IO.Path.GetFileName(uploadedFile.FileName));
                    uploadedFile.SaveAs(path);//将文件保存到本地
                    DataTable dt = ExcelReader.ReadExcel(fileExtenSion, path);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据数量为空，请重新检查文件。"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    if (dt.Columns.Count < 2)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据列数量有误，请重新检查数据是否合格。"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    int count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        FuturesFund fund = new FuturesFund();
                        fund.ZH = item[0].ToString();
                        fund.KSRQ = item[1].ToString();
                        fund.JSRQ = item[2].ToString();
                        fund.QCQY = Convert.ToDecimal(item[3]);
                        fund.QMQY = Convert.ToDecimal(item[4]);
                        fund.KYZJ = Convert.ToDecimal(item[5]);
                        fund.BZJ = Convert.ToDecimal(item[6]);
                        fund.JCSXF = Convert.ToDecimal(item[7]);
                        fund.FJSXF = Convert.ToDecimal(item[8]);
                        fund.ZSXF = Convert.ToDecimal(item[9]);
                        fund.CCFDYK = Convert.ToDecimal(item[10]);
                        fund.CCDSYK = Convert.ToDecimal(item[11]);
                        fund.PCFDYK = Convert.ToDecimal(item[12]);
                        fund.PCDSYK = Convert.ToDecimal(item[13]);
                        fund.RJ = Convert.ToDecimal(item[14]);
                        fund.CJ = Convert.ToDecimal(item[15]);
                        fund.FXD = Convert.ToDecimal(item[16]);

                        FuturesFundRepository.Add(fund);
                        count++;
                    }
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "上传期货资金数据" + count.ToString() + "条数据。" });
                    return Json(new
                    {
                        statusCode = 200,
                        status = "已经上传" + count.ToString() + "条数据。"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        statusCode = 400,
                        status = "文件传输有误，请重新上传。"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    statusCode = 400,
                    status = "文件上传发生异常," + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region 期权成交明细
        public ActionResult OptionTradeList()
        {
            return View();
        }
        /// <summary>
        /// OptionTradeGrid数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult OptionTradeGrid_Read(int? page, int? rows, string PartnerName, string ManageStatus, string OptionType, string BeginDate, string EndDate)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            IEnumerable<OptionTrade> iot = OptionTradeRepository.FindAll();
            if (!string.IsNullOrEmpty(PartnerName))
            {
                iot = iot.Where(o => o.PartnerName == PartnerName);
            }
            if (!string.IsNullOrEmpty(ManageStatus) && ManageStatus != "请选择")
            {
                iot = iot.Where(o => o.ManageStatus == ManageStatus);
            }
            if (!string.IsNullOrEmpty(OptionType) && OptionType != "请选择")
            {
                iot = iot.Where(o => o.OptionType == OptionType);
            }
            if (!string.IsNullOrEmpty(BeginDate))
            {
                iot = iot.Where(o => Convert.ToDateTime(o.BeginDate).ToString("yyyy-MM-dd") == BeginDate);
            }
            if (!string.IsNullOrEmpty(EndDate))
            {
                iot = iot.Where(o => Convert.ToDateTime(o.EndDate).ToString("yyyy-MM-dd") == EndDate);
            }

            //分产品分类合计
            var groupsum = iot.GroupBy(o => o.OptionsProductID).Select(o => (new OptionTradeGroupModel
            {
                OptionsProductID = "分产品合计",
                ProductName = o.Select(item => item.ProductName).First(),
                Deadline = "分产品合计",
                TradeNum = Convert.ToDecimal(o.Sum(item => item.TradeNum)),
                TradeCharge = Convert.ToDecimal(o.Sum(item => item.TradeCharge)),
                TradePrice = Convert.ToDecimal(o.Sum(item => item.TradePrice)),
                TradeMargin = Convert.ToDecimal(o.Sum(item => item.TradeMargin)),
                RiseCompensate = Convert.ToDecimal(o.Sum(item => item.RiseCompensate)),
                FallCompensate = Convert.ToDecimal(o.Sum(item => item.FallCompensate))
            })).ToList();
            if (iot != null && iot.Count() != 0)
            {
                //添加总合计
                groupsum.Add(iot.Select(o => (new OptionTradeGroupModel
                {
                    OptionsProductID = "总合计",
                    ProductName = "所有产品",
                    Deadline = "总合计",
                    TradeNum = Convert.ToDecimal(iot.Sum(item => item.TradeNum)),
                    TradeCharge = Convert.ToDecimal(iot.Sum(item => item.TradeCharge)),
                    TradePrice = Convert.ToDecimal(iot.Sum(item => item.TradePrice)),
                    TradeMargin = Convert.ToDecimal(iot.Sum(item => item.TradeMargin)),
                    RiseCompensate = Convert.ToDecimal(iot.Sum(item => item.RiseCompensate)),
                    FallCompensate = Convert.ToDecimal(iot.Sum(item => item.FallCompensate))
                })).First());
            }

            return Json(new
            {
                total = iot.Count(),
                rows = iot.Skip((ppage - 1) * prows).Take(prows),
                footer = groupsum
            });
        }

        /// <summary>
        /// 配置合约名称
        /// 废弃
        /// </summary>
        /// <param name="Contract"></param>
        /// <returns></returns>
        public ActionResult ConfigContract(string Contract, string OptionTradeID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Contract) && !string.IsNullOrEmpty(OptionTradeID))
                {
                    //int id = Convert.ToInt32(OptionTradeID);
                    Guid gid = new Guid(OptionTradeID);
                    OptionTrade op = OptionTradeRepository.Find(o => o.OptionTradeID == gid);
                    List<OptionTrade> iot = OptionTradeRepository.FindList(o => o.OptionsProductID == op.OptionsProductID && o.BeginDate == op.BeginDate, string.Empty, false).ToList();
                    foreach (var item in iot)
                    {
                        item.Contract = Contract.ToUpper();
                        item.ManageStatus = "1";
                        OptionTradeRepository.Update(item);
                    }
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "配置合约名称成功，将OptionTradeID=" + OptionTradeID + "的合约名称配置为" + Contract });
                    return Json(new
                    {
                        Success = true
                    });
                }
                return Json(new
                {
                    Success = false
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Message = ex.ToString()
                });
            }

        }
        #endregion
        #region 期权成交汇总
        public ActionResult OptionTradeSum()
        {
            return View();
        }
        /// <summary>
        /// OptionTradeSum数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="BeginDate"></param>
        /// <returns></returns>
        public ActionResult OptionTradeSumGrid_Read(int? page, int? rows, string PartnerName, string ManageStatus, string OptionType, string BeginDate1, string BeginDate2, string EndDate1, string EndDate2)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            IEnumerable<OptionTrade> iot = OptionTradeRepository.FindAll();
            if (!string.IsNullOrEmpty(PartnerName))
            {
                iot = iot.Where(i => i.PartnerName == PartnerName);
            }
            if (!string.IsNullOrEmpty(ManageStatus) && ManageStatus != "请选择")
            {
                iot = iot.Where(i => i.ManageStatus == ManageStatus);
            }
            if (!string.IsNullOrEmpty(OptionType) && OptionType != "请选择")
            {
                iot = iot.Where(i => i.OptionType == OptionType);
            }
            //分组求和
            var groupsum = iot.GroupBy(o => new { o.OptionsProductID, o.BeginDate }).Select(
                o => (new OptionTradeSumModel
                {
                    OptionsProductID = o.Select(item => item.OptionsProductID).First().ToString(),
                    ProductName = o.Select(item => item.ProductName).First(),
                    PartnerName = o.Select(item => item.PartnerName).First(),
                    BeginDate = Convert.ToDateTime(o.Select(item => item.BeginDate).First()),
                    EndDate = string.IsNullOrEmpty(o.Select(item => item.EndDate).First().ToString()) ? (DateTime?)null : Convert.ToDateTime(o.Select(item => item.EndDate).First()),
                    OptionType = o.Select(item => item.OptionType).First(),
                    TradeNumSum = Convert.ToDecimal(o.Sum(item => item.TradeNum)),
                    TradeChargeSum = Convert.ToDecimal(o.Sum(item => item.TradeCharge)),
                    TradePriceSum = Convert.ToDecimal(o.Sum(item => item.TradePrice)),
                    TradeMarginSum = Convert.ToDecimal(o.Sum(item => item.TradeMargin)),
                    RiseCompensateSum = Convert.ToDecimal(o.Sum(item => item.RiseCompensate)),
                    FallCompensateSum = Convert.ToDecimal(o.Sum(item => item.FallCompensate))
                })).ToList();
            //查询

            if (!string.IsNullOrEmpty(BeginDate1) && !string.IsNullOrEmpty(BeginDate2))
            {
                DateTime date1 = Convert.ToDateTime(BeginDate1);
                DateTime date2 = Convert.ToDateTime(BeginDate2);
                groupsum = groupsum.Where(g => g.BeginDate <= date2 && g.BeginDate >= date1).ToList();
                //iot = iot.Where(o => !string.IsNullOrEmpty(o.BeginDate) && o.BeginDate.Contains(BeginDate));
            }
            if (!string.IsNullOrEmpty(EndDate1) && !string.IsNullOrEmpty(EndDate2))
            {
                DateTime date1 = Convert.ToDateTime(EndDate1);
                DateTime date2 = Convert.ToDateTime(EndDate2);
                groupsum = groupsum.Where(g => g.EndDate <= date2 && g.EndDate >= date1).ToList();
            }
            //求总合计
            List<OptionTradeSumModel> allsum = new List<OptionTradeSumModel>();
            if (groupsum != null && groupsum.Count() != 0)
            {
                allsum.Add(groupsum.Select(g => (new OptionTradeSumModel
                {
                    OptionsProductID = "",
                    ProductName = "分类合计",
                    PartnerName = "",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    OptionType = "",
                    TradeNumSum = groupsum.Sum(item => item.TradeNumSum),
                    TradeChargeSum = groupsum.Sum(item => item.TradeChargeSum),
                    TradePriceSum = groupsum.Sum(item => item.TradePriceSum),
                    TradeMarginSum = groupsum.Sum(item => item.TradeMarginSum),
                    RiseCompensateSum = groupsum.Sum(item => item.RiseCompensateSum),
                    FallCompensateSum = groupsum.Sum(item => item.FallCompensateSum)
                })).First());
                allsum.Add(groupsum.Select(g => (new OptionTradeSumModel
                {
                    OptionsProductID = "",
                    ProductName = "公司盈利合计",
                    PartnerName = "",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    OptionType = "",
                    TradeNumSum = groupsum.Sum(item => item.TradeChargeSum) +
                                  groupsum.Sum(item => item.TradePriceSum) +
                                  //groupsum.Sum(item => item.TradeMarginSum) + 
                                  groupsum.Where(item => item.OptionType == "看跌期权").Sum(item => item.RiseCompensateSum) +
                                  groupsum.Where(item => item.OptionType == "看涨期权").Sum(item => item.FallCompensateSum)
                })).First());
                allsum.Add(groupsum.Select(g => (new OptionTradeSumModel
                {
                    OptionsProductID = "",
                    ProductName = "公司赔付合计",
                    PartnerName = "",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    OptionType = "",
                    TradeNumSum = groupsum.Where(item => item.OptionType == "看跌期权").Sum(item => item.FallCompensateSum) +
                                  groupsum.Where(item => item.OptionType == "看涨期权").Sum(item => item.RiseCompensateSum)

                })).First());
            }
            return Json(new
            {
                total = groupsum.Count(),
                rows = groupsum.Skip((ppage - 1) * prows).Take(prows),
                footer = allsum
            });
        }
        #endregion
        #region 结算价类型
        public ActionResult CallPriceTypeConfig()
        {
            return View();
        }
        /// <summary>
        /// 部分类型数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult CallPriceTypeConfig_Read()
        {
            return Json(CallPriceTypeRepository.FindAll());
        }
        /// <summary>
        /// 新增结算价类型
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddCallPriceType(CallPriceType callprice)
        {
            if (callprice != null)
            {
                if (CallPriceTypeRepository.Add(callprice) != null)
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增结算价类型" });
                    return Json(new
                    {
                        Success = true,
                        Msg = "新增结算价类型添加成功。"
                    });
                }
            }
            return Json(new
            {
                Success = false,
                Msg = "添加失败，请重新提交。"
            });
        }
        /// <summary>
        /// 得到结算价类型明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCallPriceTypeDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                CallPriceType findtype = CallPriceTypeRepository.Find(u => u.CallPriceTypeID == typeid);

                if (findtype != null)
                {
                    return Json(new
                    {
                        Success = true,
                        CallPriceTypeName = findtype.CallPriceTypeName,
                        CallPriceTypeDescribe = findtype.CallPriceTypeDescribe
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新结算价类型
        /// </summary>
        /// <param name="numtype"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateCallPriceType(CallPriceType callprice)
        {
            if (callprice != null)
            {
                //user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                if (CallPriceTypeRepository.Update(callprice))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新结算价类型成功" });
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
        /// <summary>
        /// 删除结算价类型
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteCallPriceType(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int typeid = Convert.ToInt32(ID);
                CallPriceType findtype = CallPriceTypeRepository.Find(u => u.CallPriceTypeID == typeid);
                if (CallPriceTypeRepository.Delete(findtype))
                {
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除结算价类型" });
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
        #endregion

        #region 总开关设置
        public ActionResult ONOFFtest()
        {
            return View();
        }
        public ActionResult ONOFFConfig()
        {
            return View();
        }
        /// <summary>
        /// 获得开关设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetONOFFSet()
        {
            try
            {
                ONOFFSet set = ONOFFSetRepository.FindAll().First();
                if (set != null)
                {
                    return Json(new
                    {
                        Success = true,
                        ONOFFMode = set.ONOFFMode,
                        HandSwitch = set.HandSwitch
                    }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }


        }
        /// <summary>
        /// 进行开关设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult SwitchSet(bool ONOFFMode, bool HandSwitch)
        {
            try
            {
                ONOFFSet findset = ONOFFSetRepository.FindAll().First();
                findset.HandSwitch = HandSwitch;
                findset.ONOFFMode = ONOFFMode ? 0 : 1;
                if (ONOFFSetRepository.Update(findset))
                {
                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false });
                }

            }
            catch (Exception)
            {
                return Json(new { Success = false });
            }
        }
        public ActionResult ONTimeGrid_Read()
        {
            return Json(ONTimeRepository.FindAll());
        }
        /// <summary>
        /// 新增启动时间
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddONTime(DateTime BeginTime,DateTime EndTime)
        {
            try
            {
                if (!string.IsNullOrEmpty(BeginTime.ToString())&& !string.IsNullOrEmpty(EndTime.ToString()))
                {
                    if (BeginTime< EndTime)
                    {

                        ONTimeRepository.Add(new ONTime {
                             BeginTime= BeginTime,
                             EndTime=EndTime
                        });
                        return Json(new { Success = true });
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "开始时间必须小于结束时间，请重新设置。" });
                    }
                    
                }
                else
                {
                    return Json(new { Success = false, Message= "开始时间或结束时间不能为空，请重新设置。" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message= ex.Message });
            }
            
        }
        /// <summary>
        /// 获取开启时间数据源
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetONTimeDetails(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    int id = Convert.ToInt32(ID);
                    ONTime ontime = await ONTimeRepository.FindAsync(time => time.ONTimeID == id);
                    return Json(new { Success = true,
                        BeginTime = ontime.BeginTime.ToString("HH:mm:ss"),
                        EndTime = ontime.EndTime.ToString("HH:mm:ss")
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = false },JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        /// <summary>
        /// 更新开启时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateONTime(ONTime time)
        {
            try
            {
                if (time != null)
                {
                    if (time.BeginTime < time.EndTime)
                    {
                        if (ONTimeRepository.Update(time))
                        {
                            return Json(new { Success = true });
                        }
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "开始时间必须小于结束时间" });
                    }

                }
                return Json(new { Success = false });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// 删除启动时间
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteONTime(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    int id = Convert.ToInt32(ID);
                    ONTime time = ONTimeRepository.Find(on => on.ONTimeID == id);
                    if (time!=null)
                    {
                        ONTimeRepository.Delete(time);
                        return Json(new { Success = true });
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "没有这条记录" });
                    }
                }
                else
                {
                    return Json(new { Success = false, Message = "传送的参数为空" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
            
            
        }
        #endregion
    }
}