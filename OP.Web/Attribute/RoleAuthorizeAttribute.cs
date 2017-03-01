using OP.Entities.Models;
using OP.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OP.Web.Attribute
{
    /// <summary>
    /// 验证当前用户角色是否有权限访问目前的操作
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class RoleAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext == null)
            {
                throw new Exception("此特性只适合于Web应用程序使用！");
            }
            if (filterContext.HttpContext.Session == null)
            {
                throw new Exception("服务器Session不可用！");
            }
            List<int> lRoleId = (List<int>)filterContext.HttpContext.Session["Roles"];
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            
            if (!GetRoleAction(lRoleId, controllerName, actionName))
            {
                JavaScriptResult result = new JavaScriptResult();
                result.Script = "很抱歉，您没有操作该菜单的权限，请与管理员联系。";
                filterContext.Result = result;
            }
        }
        /// <summary>
        /// 查询是否有权限
        /// </summary>
        /// <param name="lRoleId"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        private bool GetRoleAction(List<int> lRoleId, string controllerName, string actionName)
        {
            MenuActionRepository menuActionRep = new MenuActionRepository();
            string url = "/"+controllerName + "/" + actionName;
            if (!menuActionRep.Exist(m => m.ActionUrl == url))
            {
                return false;
            }
            int intMenuActionID = menuActionRep.Find(m => m.ActionUrl == url).MenuActionID;
            RoleActionRepository roleActionRep = new RoleActionRepository();

            foreach (var roldID in lRoleId)
            {
                if(roleActionRep.Exist(r => r.MenuActionID == intMenuActionID && r.RoleID == roldID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}