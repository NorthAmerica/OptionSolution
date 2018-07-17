using OP.Entities.Models;
using OP.Repository;
using OP.Web.Attribute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace OP.Web.Controllers
{
    /// <summary>
    /// 宣传册
    /// </summary>
    public class BrochureController : AsyncController
    {
        private IBrochureRepository BrochureRepository;
        private IOptionsProductRepository OptionsProductRepository;
        private IEventLogRepository LogRepository;
        public BrochureController(IBrochureRepository br, IOptionsProductRepository opr,IEventLogRepository elr )
        {
            BrochureRepository = br;
            OptionsProductRepository = opr;
            LogRepository = elr;
        }
        // GET: Brochure
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TemplateConfig()
        {
            return View();
        }
        /// <summary>
        /// 宣传册模板数据源
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public async Task<ActionResult> TemplateGrid_Read(int? page, int? rows)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            List<Brochure> findall = await BrochureRepository.FindAllAsync();
            var find = findall.Where(b => b.IsTemp == true);
            var returntemp = find.OrderByDescending(b => b.TempDate).Select(b => new
            {
                b.BrochureID,
                b.TempName,
                b.TempDescrip,
                TempDate = b.TempDate.ToString("yyyy-MM-dd")
            }).ToList();
            return Json(new
            {
                total = returntemp.Count(),
                rows = returntemp.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 新增，更新宣传册模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> AddTemplate(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid gid = new Guid(id);
                Brochure bro = await BrochureRepository.FindAsync(b => b.BrochureID == gid);
                if (bro != null)
                {
                    return View(bro);
                }
            }
            return View(new Brochure());
        }

        /// <summary>
        /// 新增宣传册模板事件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddTemplateAction(Brochure model)
        {
            try
            {
                if (model != null)
                {
                    model.TempDate = DateTime.Now.ToLocalTime();
                    model.IsTemp = true;
                    if (BrochureRepository.Add(model) != null)
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增宣传册模板事件成功" });
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增宣传册模板事件失败"+ex.Message });
                return Json(new
                {
                    Success = false
                });
            }
        }
        /// <summary>
        /// 拷贝宣传册模板
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> CopyTemplateAction(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    Brochure find = await BrochureRepository.FindAsync(b => b.BrochureID == gid);
                    if (find!=null)
                    {
                        find.TempName = find.TempName + "-副本";
                        find.TempDate = DateTime.Now;
                        find.BrochureID = new Brochure().BrochureID;
                        BrochureRepository.Add(find);
                        return Json(new
                        {
                            Success = true
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误，请检查。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "修改宣传册模板事件失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }

        }
        /// <summary>
        /// 修改宣传册模板事件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateTemplateAction(Brochure model)
        {
            try
            {
                if (model != null)
                {
                    model.IsTemp = true;
                    model.TempDate = DateTime.Now.ToLocalTime();
                    if (BrochureRepository.Update(model))
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "修改宣传册模板事件成功" });
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "修改宣传册模板事件失败"+ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除宣传册模板事件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTemplateAction(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    Brochure find = await BrochureRepository.FindAsync(b => b.BrochureID == gid);
                    if (find != null)
                    {
                        if (BrochureRepository.Delete(find))
                        {
                            LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除宣传册模板事件成功" });
                            return Json(new
                            {
                                Success = true
                            });
                        }
                    }
                }
                return Json(new
                {
                    Success = false
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除宣传册模板事件失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }
        }
        /// <summary>
        /// 选择宣传册模板作为正式宣传册
        /// </summary>
        /// <param name="OptionsProductID"></param>
        /// <param name="BrochureID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> SelectBrochureTemp(string OptionsProductID, string BrochureID)
        {
            try
            {
                if (!string.IsNullOrEmpty(OptionsProductID) && !string.IsNullOrEmpty(BrochureID))
                {
                    Guid bid = new Guid(BrochureID);
                    Guid opid = new Guid(OptionsProductID);
                    Brochure find = await BrochureRepository.FindAsync(b => b.BrochureID == bid);
                    find.IsTemp = false;
                    find.AddDate = DateTime.Now.ToLocalTime();
                    find.OptionsProductID = opid;
                    find.BrochureID = new Brochure().BrochureID;
                    Brochure addBro = BrochureRepository.Add(find);
                    if (addBro != null)
                    {
                        bool IsExist = await BrochureRepository.ExistAsync(b => b.OptionsProductID == opid && b.BrochureID != addBro.BrochureID);
                        if (IsExist)
                        {
                            Brochure x = await BrochureRepository.FindAsync(b => b.OptionsProductID == opid && b.BrochureID != addBro.BrochureID);
                            //删除原有的正式宣传册
                            BrochureRepository.Delete(x);
                        }
                        //更新产品说明链接
                        string BrochureURL = ConfigurationManager.AppSettings["BrochureURL"].ToString() + opid.ToString();
                        OptionsProduct findop = await OptionsProductRepository.FindAsync(op => op.OptionsProductID == opid);
                        findop.ProductUrl = BrochureURL;
                        OptionsProductRepository.Update(findop);
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "选择宣传册模板作为正式宣传册成功" });
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "选择宣传册模板作为正式宣传册失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }
        }
        /// <summary>
        /// 跳转更新正式宣传册页面
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UpdateBrochure(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid OptionsProductID = new Guid(id);
                Brochure findBro = await BrochureRepository.FindAsync(b => b.OptionsProductID == OptionsProductID && b.IsTemp == false);
                if (findBro != null)
                {
                    return View(findBro);
                }
            }
            return View(new Brochure());
        }
        /// <summary>
        /// 更新正式宣传册事件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateBrochureAction(Brochure model)
        {
            try
            {
                if (model != null)
                {
                    Brochure find = await BrochureRepository.FindAsync(b => b.BrochureID == model.BrochureID);

                    find.AddDate = DateTime.Now.ToLocalTime();
                    find.BuyBegin = model.BuyBegin;
                    find.BuyTime = model.BuyTime;
                    find.ContractDescrip = model.ContractDescrip;
                    find.EndDateDescrip = model.EndDateDescrip;
                    find.ExampleDescrip = model.ExampleDescrip;
                    find.FAQ = model.FAQ;
                    find.PayDescrip = model.PayDescrip;
                    find.PurchaseAgreementURL = model.PurchaseAgreementURL;
                    find.RiskAnnouncementURL = model.RiskAnnouncementURL;
                    find.SettlementFormula = model.SettlementFormula;
                    find.StartDateDescrip = model.StartDateDescrip;
                    find.IsTemp = false;
                    if (BrochureRepository.Update(find))
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新正式宣传册事件成功" });
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新正式宣传册事件失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }
        }
        /// <summary>
        /// 上传盈亏结构图和示例图
        /// </summary>
        /// <returns></returns>
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> UploadPicAction(string Type, string BrochureID, HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {

                    string fileExtenSion = Path.GetExtension(uploadedFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/FileUpLoad/"), System.IO.Path.GetFileName(uploadedFile.FileName));
                    uploadedFile.SaveAs(path);//将文件保存到本地
                    Guid gid = new Guid(BrochureID);
                    Brochure find = await BrochureRepository.FindAsync(bro => bro.BrochureID == gid);
                    if (Type == "SFPic")
                    {
                        find.SFPic = await GetBytesFromImage(path);
                    }
                    else
                    {
                        find.ExamplePic = await GetBytesFromImage(path);
                    }

                    find.IsTemp = false;
                    if (BrochureRepository.Update(find))
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "上传盈亏结构图和示例图成功" });
                        return Json(new
                        {
                            statusCode = 200,
                            status = "已经上传了" + uploadedFile.FileName + "文件。"
                        });
                    }

                }
                return Json(new
                {
                    statusCode = 400,
                    status = "文件传输有误，请重新上传。"
                });

            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "上传盈亏结构图和示例图失败" + ex.Message });
                return Json(new
                {
                    statusCode = 400,
                    status = "文件上传发生异常," + ex.Message
                });
            }
        }

        /// <summary>
        /// 图片转换为二进制        
        /// </summary
        private async Task<byte[]> GetBytesFromImage(string filename)
        {

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            int length = (int)fs.Length;

            byte[] image = new byte[length];

            await fs.ReadAsync(image, 0, length);

            fs.Close();

            return image;

        }

    }
}