using Ninject;
using OP.Entities.Models;
using OP.Repository;
using OP.Web.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using OP.Web.Tools;
using System.Data;
using System.IO;

namespace OP.Web.Controllers
{
    public class MonitorController : AsyncController
    {
        private InterfaceMonitorRepository MonitorRepository;
        private InterfaceMonitorConditionRepository MonitorConditionRepository;
        private InterfaceEventLogRepository LogRepository;
        public MonitorController(InterfaceMonitorRepository monitor, 
            InterfaceMonitorConditionRepository monitorcondition,
            InterfaceEventLogRepository eventLog)
        {
            MonitorRepository = monitor;
            MonitorConditionRepository = monitorcondition;
            LogRepository = eventLog;
        }

        // GET: Monitor
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 审核页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AuditMonitor()
        {
            return View();
        }
        public async Task<ActionResult> MonitorList_Read(int? page, int? rows)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            IEnumerable<Monitor> imonitor = await MonitorRepository.FindAllAsync();
            IEnumerable<Monitor> imonitorByOrder = imonitor.OrderByDescending(i => i.MonitorDate).ToList();
            return Json(new
            {
                total = imonitorByOrder.Count(),
                rows = imonitorByOrder.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 新增监控条目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddMonitor(bool IsCopy,Monitor model)
        {
            try
            {
                int MonitorConditionNum = 0;
                Guid OldMonitorID = Guid.Empty;
                if (model != null)
                {
                    model.Editor = Session["LoginedUser"] != null ? Session["LoginedUser"].ToString() : "";
                    model.EditTime = DateTime.Now.ToLocalTime();
                    model.IsActive = false;
                    model.IsAudit = false;
                    if (IsCopy)
                    {
                        OldMonitorID = model.MonitorID;
                        model.MonitorID = Guid.NewGuid();
                    }
                    Monitor addModel = MonitorRepository.Add(model);
                    
                    if (IsCopy)
                    {
                        List<MonitorCondition> lmc = MonitorConditionRepository.FindList(m => m.MonitorID == OldMonitorID, string.Empty,false).ToList();
                        if (lmc!=null && lmc.Count!=0)
                        {
                            foreach (var item in lmc)
                            {
                                item.Contract = model.Contract;
                                item.MonitorDate = model.MonitorDate;
                                item.MonitorConditionID = Guid.NewGuid();
                                item.MonitorID = addModel.MonitorID;
                            }
                            MonitorConditionNum = MonitorConditionRepository.AddRange(lmc);
                        }
                    }
                    if (addModel != null)
                    {
                        return Json(new { Success = true ,Msg = "新增监控条件"+ MonitorConditionNum });
                    }
                }
                return Json(new { Success = false, Msg = "参数有误" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Msg = ex.ToString() });
            }

        }
        /// <summary>
        /// 复制监控条目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult CopyMonitor(string MonitorID, Monitor model)
        {
            return Json(new { Success = false, Msg = "参数有误" });
        }
        /// <summary>
        /// 启动监控
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> BeginMonitor(string[] id)
        {
            try
            {
                if (id.Length != 0)
                {
                    foreach (var itemid in id)
                    {
                        Guid gid = new Guid(itemid);
                        bool IsExist = await MonitorRepository.ExistAsync(o => o.MonitorID == gid);
                        if (IsExist)
                        {
                            Monitor mo = await MonitorRepository.FindAsync(o => o.MonitorID == gid);
                            mo.IsActive = true;
                            if (!MonitorRepository.Update(mo))
                            {
                                return Json(new
                                {
                                    Success = false,
                                    Msg = "更新数据有误。"
                                });
                            }
                        }
                    }
                }
                return Json(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Msg = ex.ToString()
                });
            }
            
        }
        /// <summary>
        /// 停用监控
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> EndMonitor(string[] id)
        {
            try
            {
                if (id.Length != 0)
                {
                    foreach (var itemid in id)
                    {
                        Guid gid = new Guid(itemid);
                        bool IsExist = await MonitorRepository.ExistAsync(o => o.MonitorID == gid);
                        if (IsExist)
                        {
                            Monitor mo = await MonitorRepository.FindAsync(o => o.MonitorID == gid);
                            mo.IsActive = false;
                            if (!MonitorRepository.Update(mo))
                            {
                                return Json(new
                                {
                                    Success = false,
                                    Msg = "更新数据有误。"
                                });
                            }
                        }
                    }
                }
                return Json(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Msg = ex.ToString()
                });
            }
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> PassMonitor(string[] id)
        {
            try
            {
                if (id.Length != 0)
                {
                    foreach (var itemid in id)
                    {
                        Guid gid = new Guid(itemid);
                        bool IsExist = await MonitorRepository.ExistAsync(o => o.MonitorID == gid);
                        if (IsExist)
                        {
                            Monitor mo = await MonitorRepository.FindAsync(o => o.MonitorID == gid);
                            mo.IsAudit = true;
                            mo.Auditor= Session["LoginedUser"] != null ? Session["LoginedUser"].ToString() : "";
                            mo.AuditTime = DateTime.Now.ToLocalTime();
                            if (!MonitorRepository.Update(mo))
                            {
                                return Json(new
                                {
                                    Success = false,
                                    Msg = "更新数据有误。"
                                });
                            }
                        }
                    }
                }
                return Json(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Msg = ex.ToString()
                });
            }

        }
        /// <summary>
        /// 审核不通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> RejectMonitor(string[] id)
        {
            try
            {
                if (id.Length != 0)
                {
                    foreach (var itemid in id)
                    {
                        Guid gid = new Guid(itemid);
                        bool IsExist = await MonitorRepository.ExistAsync(o => o.MonitorID == gid);
                        if (IsExist)
                        {
                            Monitor mo = await MonitorRepository.FindAsync(o => o.MonitorID == gid);
                            mo.IsAudit = false;
                            mo.IsActive = false;
                            mo.Auditor = Session["LoginedUser"] != null ? Session["LoginedUser"].ToString() : "";
                            mo.AuditTime = DateTime.Now.ToLocalTime();
                            if (!MonitorRepository.Update(mo))
                            {
                                return Json(new
                                {
                                    Success = false,
                                    Msg = "更新数据有误。"
                                });
                            }
                        }
                    }
                }
                return Json(new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Msg = ex.ToString()
                });
            }

        }
        /// <summary>
        /// 上传Excel监控参数
        /// </summary>
        /// <returns></returns>
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> UploadMonitorCondition(string monitordate,string id,HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    Guid MonitorID = new Guid(id);
                    DateTime MonitorDate = Convert.ToDateTime(monitordate);
                    string fileExtenSion = Path.GetExtension(uploadedFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/FileUpLoad/"), System.IO.Path.GetFileName(uploadedFile.FileName));

                    string justName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                    uploadedFile.SaveAs(path);//将文件保存到本地
                    DataTable dt = await ExcelReader.ReadExcel(fileExtenSion, path);
                    if (dt.Rows.Count==0||dt==null)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据数量为空，请重新检查文件。"
                        });
                    }

                    if (dt.Columns.Count < 2)
                    {
                        return Json(new
                        {
                            statusCode = 400,
                            status = "数据列数量有误，请重新检查数据是否合格。"
                        });
                    }
                    int count = 0;
                    List<MonitorCondition> lmc = new List<MonitorCondition>();
                    foreach (DataRow item in dt.Rows)
                    {
                        MonitorCondition mc = new MonitorCondition();
                        mc.MonitorID = MonitorID;
                        mc.Contract = justName;
                        mc.MainPosition = Convert.ToInt32(item[0]);
                        mc.MinPosition = Convert.ToInt32(item[1]);
                        mc.MaxPosition = Convert.ToInt32(item[2]);
                        mc.MinPrice = Convert.ToInt32(item[3]);
                        mc.MaxPrice = Convert.ToInt32(item[4]);
                        mc.MonitorDate = MonitorDate;
                        lmc.Add(mc);
                    }
                    count = MonitorConditionRepository.AddRange(lmc);
                    
                    LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "上传监控指标数据" + count.ToString() + "条数据。" });
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
        /// 监控参数数据源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<ActionResult> MonitorConditionGrid_Read(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                //int intid = Convert.ToInt32(id);
                Guid gid = new Guid(id);
                IEnumerable<MonitorCondition> ifr = await MonitorConditionRepository.FindListAsync(f => f.MonitorID == gid, string.Empty, false);
                if (ifr != null && ifr.Count() != 0)
                {
                    return Json(ifr);
                }
            }
            return Json(new { });
        }
    }
}