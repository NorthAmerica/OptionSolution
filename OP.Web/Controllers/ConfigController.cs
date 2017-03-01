using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OP.Entities.Models;
using OP.Repository;
using OP.Web.Models;
using OP.Web.Tools;
using OP.Web.Attribute;
using System.Threading.Tasks;

namespace OP.Web.Controllers
{
    [Authorization]
    public class ConfigController : AsyncController
    {
        private InterfaceMenuRepository MenuRepository;
        private InterfaceRoleMenuRepository RoleMenuRepository;
        private InterfaceRoleRepository RoleRepository;
        private InterfaceUserRepository UserRepository;
        private InterfaceUserRoleRepository UserRoleRepository;
        private InterfaceEventLogRepository LogRepository;
        private InterfaceGuestBookRepository GuestBookRepository;
        private InterfaceMenuActionRepository MenuActionRepository;
        private InterfaceRoleActionRepository RoleActionRepository;
        public ConfigController(InterfaceMenuRepository menu,
            InterfaceRoleMenuRepository rolemenu,
            InterfaceRoleRepository role,
            InterfaceUserRepository user,
            InterfaceUserRoleRepository userrole,
            InterfaceEventLogRepository eventlog,
            InterfaceGuestBookRepository guestbook,
            InterfaceMenuActionRepository menuaction,
            InterfaceRoleActionRepository roleaction)
        {
            MenuRepository = menu;
            RoleMenuRepository = rolemenu;
            RoleRepository = role;
            UserRepository = user;
            UserRoleRepository = userrole;
            LogRepository = eventlog;
            GuestBookRepository = guestbook;
            MenuActionRepository = menuaction;
            RoleActionRepository = roleaction;
        }
        // GET: Config首页
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["IsAdmin"]?.ToString()))
            {
                if (Session["IsAdmin"]?.ToString() == "True")
                {
                    return View();
                }
                else
                {
                    return new RedirectResult("/Home/Index");
                }
            }
            else
            {
                return new RedirectResult("/Home/Index");
            }

        }
        /// <summary>
        /// 菜单创建
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult ConfigMenu()
        {
            return PartialView();
        }
        #region 人员管理
        public ActionResult UserConfig()
        {
            return View();
        }
        /// <summary>
        /// 显示所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UserConfig_Read()
        {
            List<User> lu = await UserRepository.FindAllAsync();
            return Json(lu);
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddUser(User user)
        {
            try
            {
                if (user != null)
                {
                    user.Date = DateTime.Now.ToLocalTime().ToString();
                    user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                    if (UserRepository.Add(user) != null)
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增用户成功" });
                        return Json(new
                        {
                            Success = true,
                            Msg = "用户添加成功。"
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，请重新提交。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增用户失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，" + ex.Message
                });
            }
        }
        /// <summary>
        /// 根据UserID得到User信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetUserDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {

                int userid = Convert.ToInt32(ID);
                User finduser = await UserRepository.FindAsync(u => u.UserID == userid);

                if (finduser != null)
                {
                    return Json(new
                    {
                        Success = true,
                        Name = finduser.UserName,
                        Password = EncryptUtils.Base64Decrypt(finduser.UserPassword),
                        Enable = finduser.Enable,
                        IsAdmin = finduser.IsAdmin
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateUser(User user)
        {
            try
            {
                if (user != null)
                {
                    user.UserPassword = EncryptUtils.Base64Encrypt(user.UserPassword);
                    if (UserRepository.Update(user))
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
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "修改用户资料失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    //Guid userid = new Guid(ID);
                    int userid = Convert.ToInt32(ID);
                    User finduser = await UserRepository.FindAsync(u => u.UserID == userid);
                    if (UserRepository.Delete(finduser))
                    {
                        //查询关联表 用户角色表
                        IEnumerable<UserRole> IUR = await UserRoleRepository.FindListAsync(u => u.UserID == userid, string.Empty, false);
                        if (IUR != null && IUR.Count() != 0)
                        {
                            //删除关联项
                            UserRoleRepository.DeleteRange(IUR);
                        }
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除用户失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        #endregion
        #region 角色管理
        public ActionResult RoleConfig()
        {
            return View();
        }
        /// <summary>
        /// Role数据源
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> RoleConfig_Read()
        {
            List<Role> lr = await RoleRepository.FindAllAsync();
            return Json(lr);
        }
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddRole(Role role)
        {
            try
            {
                if (role != null)
                {
                    Role addRole = RoleRepository.Add(role);
                    if (addRole != null)
                    {
                        return Json(new
                        {
                            Success = true,
                            Msg = "角色添加成功。"
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，请重新提交。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增角色失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，" + ex.Message
                });
            }
        }
        /// <summary>
        /// 获取ROLE详细信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetRoleDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                //Guid roleid = new Guid(ID);
                int roleid = Convert.ToInt32(ID);
                Role findrole = await RoleRepository.FindAsync(u => u.RoleID == roleid);
                if (findrole != null)
                {
                    return Json(new
                    {
                        Success = true,
                        RoleName = findrole.RoleName,
                        RoleDescribe = findrole.RoleDescribe
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateRole(Role role)
        {
            try
            {
                if (role != null)
                {
                    if (RoleRepository.Update(role))
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
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新权限失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除Role
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRole(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {

                    int roleid = Convert.ToInt32(ID);
                    Role findrole = await RoleRepository.FindAsync(u => u.RoleID == roleid);
                    if (RoleRepository.Delete(findrole))
                    {
                        //查询关联关系 菜单角色表
                        IEnumerable<RoleMenu> IRM = await RoleMenuRepository.FindListAsync(r => r.RoleID == roleid, string.Empty, false);
                        if (IRM != null && IRM.Count() != 0)
                        {
                            //删除已存在的菜单角色表
                            RoleMenuRepository.DeleteRange(IRM);
                        }
                        //查询关联关系 用户角色表
                        IEnumerable<UserRole> IUR = await UserRoleRepository.FindListAsync(u => u.RoleID == roleid, string.Empty, false);
                        if (IUR != null && IUR.Count() != 0)
                        {
                            //删除已存在的用户角色表
                            UserRoleRepository.DeleteRange(IUR);
                        }
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除权限失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        #endregion
        #region 菜单维护
        public ActionResult MenuConfig()
        {
            return View();
        }
        /// <summary>
        /// Menu数据源
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> MenuConfig_Read()
        {
            List<Menu> findall = await MenuRepository.FindAllAsync();
            IEnumerable<Menu> topMenu = findall.OrderBy(m => m.OrderNum).Where(m => m.FMenuID == 0);
            List<MenuTreeModel> result = new List<MenuTreeModel>();
            foreach (Menu Menu in topMenu)
            {
                MenuTreeModel toptree = new MenuTreeModel();
                toptree.MenuID = Menu.MenuID.ToString();
                toptree.MenuName = Menu.MenuName;
                toptree.MenuURL = Menu.MenuURL;
                toptree.OrderNum = Menu.OrderNum;
                toptree.children = await addchild(Menu.MenuID);
                result.Add(toptree);
            }
            return Json(result);
        }
        /// <summary>
        /// 无限添加子节点
        /// </summary>
        /// <param name="FID">父ID</param>
        /// <returns></returns>
        private async Task<List<MenuTreeModel>> addchild(int FID)
        {
            List<Menu> findall = await MenuRepository.FindAllAsync();
            IEnumerable<Menu> childmenu = findall.OrderBy(m => m.OrderNum).Where(m => m.FMenuID == FID);
            if (childmenu != null && childmenu.Count() != 0)
            {
                List<MenuTreeModel> childtree = new List<MenuTreeModel>();
                foreach (Menu child in childmenu)
                {
                    childtree.Add(new MenuTreeModel
                    {
                        MenuID = child.MenuID.ToString(),
                        MenuName = child.MenuName,
                        MenuURL = child.MenuURL,
                        OrderNum = child.OrderNum,
                        children = await addchild(child.MenuID)
                    });
                }
                return childtree;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 添加主菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddMainMenu(Menu menu)
        {
            try
            {
                if (menu != null)
                {
                    menu.FMenuID = 0;
                    Menu addMenu = MenuRepository.Add(menu);
                    if (addMenu != null)
                    {
                        return Json(new
                        {
                            Success = true,
                            Msg = "主菜单添加成功。"
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，请重新提交。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "添加主菜单失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，" + ex.Message
                });
            }

        }
        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddMenu(Menu menu)
        {
            try
            {
                if (menu != null)
                {
                    Menu addMenu = MenuRepository.Add(menu);
                    if (addMenu != null)
                    {
                        return Json(new
                        {
                            Success = true,
                            Msg = "主菜单添加成功。"
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，请重新提交。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "添加子菜单失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，" + ex.Message
                });
            }

        }
        /// <summary>
        /// 获取菜单详细信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetMenuDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                int menuid = Convert.ToInt32(ID);
                Menu findmenu = await MenuRepository.FindAsync(u => u.MenuID == menuid);
                if (findmenu != null)
                {
                    return Json(new
                    {
                        Success = true,
                        MenuName = findmenu.MenuName,
                        MenuURL = findmenu.MenuURL,
                        OrderNum = findmenu.OrderNum,
                        FMenuID = findmenu.FMenuID
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateMenu(Menu menu)
        {
            try
            {
                if (menu != null)
                {
                    if (MenuRepository.Update(menu))
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
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新菜单失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMenu(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    int menuid = Convert.ToInt32(ID);
                    Menu findmenu = await MenuRepository.FindAsync(u => u.MenuID == menuid);
                    if (findmenu != null)
                    {
                        List<Menu> Ldelete = new List<Menu>();
                        Ldelete.Add(findmenu);
                        DeleteChild(Ldelete, menuid);
                        if (MenuRepository.DeleteRange(Ldelete.AsEnumerable()) != 0)
                        {
                            //查找并删除菜单角色表中的数据
                            foreach (Menu item in Ldelete)
                            {
                                RoleMenu findrm = await RoleMenuRepository.FindAsync(r => r.MenuID == item.MenuID);
                                if (findrm != null)
                                {
                                    RoleMenuRepository.Delete(findrm);
                                }
                            }
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除菜单失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除子菜单
        /// </summary>
        private async void DeleteChild(List<Menu> Ldelete, int menuid)
        {
            try
            {
                List<Menu> findall = await MenuRepository.FindAllAsync();
                IEnumerable<Menu> findchilds = findall.Where(m => m.FMenuID == menuid);

                if (findchilds != null && findchilds.Count() != 0)
                {
                    Ldelete.AddRange(findchilds);
                    foreach (var child in findchilds)
                    {
                        DeleteChild(Ldelete, child.MenuID);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除子菜单失败" + ex.Message });
                throw;
            }
        }
        #endregion
        #region 人员角色维护
        public ActionResult UserRoleConfig()
        {
            return View();
        }
        /// <summary>
        /// RoleTree数据源
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> RoleTree_Read()
        {
            IEnumerable<Role> allRole = await RoleRepository.FindAllAsync();
            TreeModel tm = new TreeModel();
            tm.id = "0";
            tm.text = "所有角色";
            List<TreeModel> innerdata = new List<TreeModel>();
            foreach (Role item in allRole)
            {
                innerdata.Add(new TreeModel
                {
                    id = item.RoleID.ToString(),
                    text = item.RoleName
                });
            }
            tm.children = innerdata;
            List<TreeModel> result = new List<TreeModel>();
            result.Add(tm);
            return Json(result);
        }
        /// <summary>
        /// 人员角色数据源
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UserRole_Read(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                //Guid roleid = new Guid(id);
                int roleid = Convert.ToInt32(id);
                List<UserRole> findall = await UserRoleRepository.FindAllAsync();
                IEnumerable<UserRole> iur = findall.Where(u => u.RoleID == roleid);
                if (iur != null && iur.Count() != 0)
                {
                    List<User> lUser = new List<User>();
                    foreach (UserRole item in iur)
                    {
                        User findu = await UserRepository.FindAsync(u => u.UserID == item.UserID);
                        lUser.Add(findu);
                    }
                    return Json(lUser);
                }
            }
            return Json(new { });
        }
        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="UserIDs"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateUserRole(string RoleID, string UserIDs)
        {
            try
            {
                if (RoleID != null && UserIDs != null)
                {
                    string[] userid = UserIDs.Split(',');
                    //Guid groleid = new Guid(RoleID);
                    int intRoleID = Convert.ToInt32(RoleID);
                    foreach (var item in userid)
                    {
                        //Guid gUserID = new Guid(item);
                        int intUserID = Convert.ToInt32(item);
                        bool IsExist = await UserRoleRepository.ExistAsync(ur => ur.RoleID == intRoleID && ur.UserID == intUserID);
                        if (!IsExist)
                        {
                            UserRole ur = new UserRole();
                            ur.RoleID = intRoleID;
                            ur.UserID = intUserID;
                            UserRoleRepository.Add(ur);
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
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新用户角色失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除用户角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUserRole(string RoleID, string UserIDs)
        {
            try
            {
                if (RoleID != null && UserIDs != null)
                {
                    string[] userid = UserIDs.Split(',');
                    int intRoleID = Convert.ToInt32(RoleID);
                    foreach (var item in userid)
                    {
                        int intUserID = Convert.ToInt32(item);
                        UserRole ur = await UserRoleRepository.FindAsync(u => u.RoleID == intRoleID && u.UserID == intUserID);
                        if (ur != null)
                        {
                            UserRoleRepository.Delete(ur);
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
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除用户角色失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        #endregion
        #region 角色菜单维护
        
        public ActionResult RoleMenuConfig()
        {
            return View();
        }
        /// <summary>
        /// RoleMenu数据源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> RoleMenu_Read(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int menuid = Convert.ToInt32(id);
                List<RoleMenu> findall = await RoleMenuRepository.FindAllAsync();
                IEnumerable<RoleMenu> irm = findall.Where(u => u.MenuID == menuid);
                if (irm != null && irm.Count() != 0)
                {
                    List<Role> lRole = new List<Role>();
                    foreach (RoleMenu item in irm)
                    {
                        Role role = await RoleRepository.FindAsync(u => u.RoleID == item.RoleID);
                        lRole.Add(role);
                    }
                    return Json(lRole);
                }
            }
            return Json(new { });
        }
        /// <summary>
        /// 更新RoleMenu
        /// </summary>
        /// <param name="MenuID"></param>
        /// <param name="RoleIDs"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateRoleMenu(string MenuID, string RoleIDs)
        {
            try
            {
                if (MenuID != null && RoleIDs != null)
                {
                    string[] roleid = RoleIDs.Split(',');
                    int intMenuID = Convert.ToInt32(MenuID);
                    List<RoleMenu> lrm = new List<RoleMenu>();
                    foreach (var item in roleid)
                    {
                        int intRoleID = Convert.ToInt32(item);
                        bool IsExist = await RoleMenuRepository.ExistAsync(ur => ur.RoleID == intRoleID && ur.MenuID == intMenuID);
                        if (!IsExist)
                        {
                            RoleMenu rm = new RoleMenu();
                            rm.RoleID = intRoleID;
                            rm.MenuID = intMenuID;
                            lrm.Add(rm);
                        }
                        await UpdateChild(lrm, intMenuID, intRoleID);
                    }
                    RoleMenuRepository.AddRange(lrm);
                    return Json(new { Success = true });
                }
                return Json(new
                {
                    Success = false
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "更新RoleMenu失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 更新添加子菜单
        /// </summary>
        /// <param name="MenuID"></param>
        /// <param name="RoleID"></param>
        private async Task<string> UpdateChild(List<RoleMenu> lrm, int MenuID, int RoleID)
        {
            List<Menu> findall = await MenuRepository.FindAllAsync();
            IEnumerable<Menu> im = findall.Where(m => m.FMenuID == MenuID);
            if (im != null && im.Count() != 0)
            {
                foreach (Menu item in im)
                {
                    bool IsExist = await RoleMenuRepository.ExistAsync(umr => umr.MenuID == item.MenuID && umr.RoleID == RoleID);
                    if (!IsExist)
                    {
                        RoleMenu rm = new RoleMenu();
                        rm.RoleID = RoleID;
                        rm.MenuID = item.MenuID;
                        lrm.Add(rm);
                    }
                    await UpdateChild(lrm, item.MenuID, RoleID);
                }

            }
            return string.Empty;
        }
        /// <summary>
        /// 删除RoleMenu
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRoleMenu(string MenuID, string RoleIDs)
        {
            try
            {
                if (MenuID != null && RoleIDs != null)
                {
                    string[] roleid = RoleIDs.Split(',');
                    int intMenuID = Convert.ToInt32(MenuID);
                    List<RoleMenu> lrm = new List<RoleMenu>();
                    foreach (var item in roleid)
                    {
                        int intRoleID = Convert.ToInt32(item);
                        bool IsExist = await RoleMenuRepository.ExistAsync(ur => ur.RoleID == intRoleID && ur.MenuID == intMenuID);
                        if (IsExist)
                        {
                            RoleMenu rm = await RoleMenuRepository.FindAsync(ur => ur.RoleID == intRoleID && ur.MenuID == intMenuID);
                            lrm.Add(rm);
                        }
                        await DeleteChild(lrm, intMenuID, intRoleID);
                    }
                    RoleMenuRepository.DeleteRange(lrm);
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除RoleMenu失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 删除子菜单角色
        /// </summary>
        /// <param name="lrm"></param>
        /// <param name="MenuID"></param>
        /// <param name="RoleID"></param>
        private async Task<string> DeleteChild(List<RoleMenu> lrm, int MenuID, int RoleID)
        {
            IEnumerable<Menu> im = MenuRepository.FindAll().Where(m => m.FMenuID == MenuID);
            if (im != null && im.Count() != 0)
            {
                foreach (Menu item in im)
                {
                    bool IsExist = await RoleMenuRepository.ExistAsync(umr => umr.MenuID == item.MenuID && umr.RoleID == RoleID);
                    if (IsExist)
                    {
                        RoleMenu rm = await RoleMenuRepository.FindAsync(umr => umr.MenuID == item.MenuID && umr.RoleID == RoleID);
                        lrm.Add(rm);
                    }
                    await DeleteChild(lrm, item.MenuID, RoleID);
                }
            }
            return string.Empty;
        }
        #endregion
        #region 日志列表
        public ActionResult EventLogList()
        {
            return View();
        }

        public async Task<ActionResult> EventLogGrid_Read(int? page, int? rows, string Name, string Date)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            List<EventLog> findall = await LogRepository.FindAllAsync();
            IEnumerable<EventLog> iel = findall.OrderByDescending(l => l.Date);
            if (!string.IsNullOrEmpty(Name))
            {
                iel = iel.Where(e => e.Name.Contains(Name));
            }
            if (!string.IsNullOrEmpty(Date))
            {
                iel = iel.Where(e => e.Date.ToString("yyyy-MM-dd") == Date);
            }
            return Json(new
            {
                total = iel.Count(),
                rows = iel.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        #endregion
        #region 留言栏管理
        public ActionResult GuestBookList()
        {
            return View();
        }
        public async Task<ActionResult> GuestBookGrid_Read(int? page, int? rows)
        {
            int ppage = Convert.ToInt32(page == null ? 1 : page);
            int prows = Convert.ToInt32(rows == null ? 1 : rows);
            List<GuestBook> findall = await GuestBookRepository.FindAllAsync();
            IEnumerable<GuestBook> igb = findall.OrderByDescending(l => l.GuestDate);
            var result = igb.Select(g => new
            {
                g.GuestBookID,
                g.GuestContent,
                g.GuestMobile,
                g.GuestName,
                GuestDate = g.GuestDate.ToString("yyyy-MM-dd")
            }).ToList();
            return Json(new
            {
                total = result.Count(),
                rows = result.Skip((ppage - 1) * prows).Take(prows)
            });
        }
        /// <summary>
        /// 查询留言栏详情
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetGuestBookDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {

                int GuestBookID = Convert.ToInt32(ID);
                GuestBook findGB = await GuestBookRepository.FindAsync(g => g.GuestBookID == GuestBookID);

                if (findGB != null)
                {
                    return Json(new
                    {
                        Success = true,
                        GuestBookID = findGB.GuestBookID,
                        GuestContent = findGB.GuestContent,
                        GuestDate = findGB.GuestDate.ToString("yyyy-MM-dd"),
                        GuestMobile = findGB.GuestMobile,
                        GuestName = findGB.GuestName
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 操作及操作权限维护
        
        public ActionResult ActionConfig()
        {
            return View();
        }
        /// <summary>
        /// 操作规则列表数据源
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ActionGrid_Read(string ID)
        {
            List<MenuAction> lma = await MenuActionRepository.FindAllAsync();
            if (!string.IsNullOrEmpty(ID))
            {
                int intId = Convert.ToInt32(ID);
                lma = lma.Where(a => a.MenuID == intId).ToList();
            }
            return Json(lma);
        }
        /// <summary>
        /// 新增操作规则
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult AddAction(MenuAction model)
        {
            try
            {
                if (model != null)
                {
                    if (MenuActionRepository.Add(model) != null)
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增操作成功" });
                        return Json(new
                        {
                            Success = true,
                            Msg = "操作添加成功。"
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，请重新提交。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增操作失败" + ex.Message });
                return Json(new
                {
                    Success = false,
                    Msg = "添加失败，" + ex.Message
                });
            }
        }
        /// <summary>
        /// 更新操作规则
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public ActionResult UpdateAction(MenuAction model)
        {
            try
            {
                if (model != null)
                {
                    if (MenuActionRepository.Update(model))
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "修改操作规则成功" });
                        return Json(new
                        {
                            Success = true
                        });
                    }
                }
                return Json(new
                {
                    Success = false,
                    Message="更新失败，参数有误。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "修改操作规则失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 根据MenuActionID得到MenuAction信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetActionDetails(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {

                int MenuActionID = Convert.ToInt32(ID);
                MenuAction findaction = await MenuActionRepository.FindAsync(u => u.MenuActionID == MenuActionID);

                if (findaction != null)
                {
                    return Json(new
                    {
                        Success = true,
                        ActionName = findaction.ActionName,
                        ActionUrl = findaction.ActionUrl
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Success = false
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除操作规则
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAction(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    //Guid userid = new Guid(ID);
                    int MenuActionID = Convert.ToInt32(ID);
                    MenuAction findAction = await MenuActionRepository.FindAsync(u => u.MenuActionID == MenuActionID);
                    if (MenuActionRepository.Delete(findAction))
                    {
                        //查询关联表 操作角色表
                        IEnumerable<RoleAction> IRM = await RoleActionRepository.FindListAsync(u => u.MenuActionID == MenuActionID, string.Empty, false);
                        if (IRM != null && IRM.Count() != 0)
                        {
                            //删除关联项
                            RoleActionRepository.DeleteRange(IRM);
                        }
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除操作规则成功"});
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除操作规则失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }

        /// <summary>
        /// 删除操作权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRoleAction(string MenuActionID,string RoleID)
        {
            try
            {
                if (!string.IsNullOrEmpty(MenuActionID)&&!string.IsNullOrEmpty(RoleID))
                {

                    int intMenuActionID = Convert.ToInt32(MenuActionID);
                    int intRoleID = Convert.ToInt32(RoleID);
                    RoleAction findRole = await RoleActionRepository.FindAsync(u => u.MenuActionID == intMenuActionID&&u.RoleID== intRoleID);
                    if (RoleActionRepository.Delete(findRole))
                    {
                        LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除操作权限成功" });
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
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "删除操作权限失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// 新增操作权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CSRFValidateAntiForgeryToken]
        public async Task<ActionResult> AddRoleAction(string MenuActionID, string RoleIDs)
        {
            try
            {
                if (MenuActionID != null && RoleIDs != null)
                {
                    string[] roleid = RoleIDs.Split(',');
                    int intMenuActionID = Convert.ToInt32(MenuActionID);
                    List<RoleAction> lrm = new List<RoleAction>();
                    foreach (var item in roleid)
                    {
                        int intRoleID = Convert.ToInt32(item);
                        bool IsExist = await RoleActionRepository.ExistAsync(ur => ur.RoleID == intRoleID && ur.MenuActionID == intMenuActionID);
                        if (!IsExist)
                        {
                            RoleAction ra = new RoleAction();
                            ra.RoleID = intRoleID;
                            ra.MenuActionID = intMenuActionID;
                            lrm.Add(ra);
                        }
                        
                    }
                    RoleActionRepository.AddRange(lrm);
                    return Json(new { Success = true });
                }
                return Json(new
                {
                    Success = false,
                    Message = "参数有误，请检查。"
                });
            }
            catch (Exception ex)
            {
                LogRepository.Add(new EventLog() { Name = Session["LoginedUser"].ToString(), Date = DateTime.Now.ToLocalTime(), Event = "新增操作权限失败" + ex.Message });
                return Json(new
                {
                    Success = false
                });
            }

        }
        /// <summary>
        /// RoleActionGrid数据源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> RoleActionGrid_Read(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int MenuActionID = Convert.ToInt32(id);
                List<RoleAction> findall = await RoleActionRepository.FindAllAsync();
                IEnumerable<RoleAction> irm = findall.Where(u => u.MenuActionID == MenuActionID);
                if (irm != null && irm.Count() != 0)
                {
                    List<Role> lRole = new List<Role>();
                    foreach (RoleAction item in irm)
                    {
                        Role role = await RoleRepository.FindAsync(u => u.RoleID == item.RoleID);
                        lRole.Add(role);
                    }
                    return Json(lRole);
                }
            }
            return Json(new { });
        }
        #endregion
    }
}