using OP.Entities;
using OP.Repository;
using OP.Web.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OP.Web.Controllers
{
    /// <summary>
    /// 宣传册
    /// </summary>
    public class BrochureController : Controller
    {
        private InterfaceBrochureRepository BrochureRepository;
        public BrochureController(InterfaceBrochureRepository br)
        {
            BrochureRepository = br;
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
        public ActionResult TemplateGrid_Read(int? page, int? rows)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            var find = BrochureRepository.FindAll().Where(b => b.IsTemp = true);
            var returntemp = find.OrderByDescending(b => b.TempDate).Select(b => new {
                b.BrochureID,
                b.TempName,
                b.TempDescrip,
                TempDate = b.TempDate.ToString("yyyy-MM-dd")
            }).ToList();
            return Json(new {
                total = returntemp.Count(),
                rows = returntemp.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 新增，更新宣传册模板
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTemplate(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid gid = new Guid(id);
                Brochure bro = BrochureRepository.Find(b => b.BrochureID == gid);
                if (bro!=null)
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
                    if(BrochureRepository.Add(model)!=null)
                    {
                        return Json(new
                        {
                            Success = true
                        });
                    }
                }
                return Json(new {
                    Success = false
                });
            }
            catch (Exception)
            {
                return Json(new {
                    Success = false
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
                if (model!=null)
                {
                    model.TempDate = DateTime.Now.ToLocalTime();
                    if (BrochureRepository.Update(model))
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
        /// 删除宣传册模板事件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult DeleteTemplateAction(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    Guid gid = new Guid(ID);
                    Brochure find = BrochureRepository.Find(b => b.BrochureID == gid);
                    if (find!=null)
                    {
                        if (BrochureRepository.Delete(find))
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
    }
}