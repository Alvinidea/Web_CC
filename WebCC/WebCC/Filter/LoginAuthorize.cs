using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCC.Filter
{

    /// <summary>
    /// 登陆验证   若未登录 将回到Login界面
    /// </summary>
    public class LoginAuthorize : AuthorizeAttribute
    {

        //
        // 摘要:
        //     在过程请求授权时调用。
        //
        // 参数:
        //   filterContext:
        //     筛选器上下文，它封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     filterContext 参数为 null。
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        //
        // 摘要:
        //     重写时，提供一个入口点用于进行自定义授权检查。
        //
        // 参数:
        //   httpContext:
        //     HTTP 上下文，它封装有关单个 HTTP 请求的所有 HTTP 特定的信息。
        //
        // 返回结果:
        //     如果用户已经过授权，则为 true；否则为 false。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     httpContext 参数为 null。
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        // 摘要:
        //     处理未能授权的 HTTP 请求。
        //
        // 参数:
        //   filterContext:
        //     封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。filterContext 对象包括控制器、HTTP 上下文、请求上下文、操作结果和路由数据。
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}