using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCC.Controllers
{
    public class BaseController : Controller
    {

        /// <summary>
        /// DB上下文
        /// </summary>
        protected DBWebCCEntities db = new DBWebCCEntities();

        /// <summary>
        /// 存于Session的 用户ID
        /// </summary>
        public int SessionInfo_ID
        {
            get
            {
                return (int)Session["LoginedID"];
            }
            set
            {
                Session["LoginedID"] = value;
            }
        }

        /// <summary>
        /// 存于Session的 用户ID
        /// </summary>
        public String SessionInfo_Num
        {
            get
            {
                return Session["LoginedNum"] as String;
            }
            set
            {
                Session["LoginedNum"] = value;
            }
        }
        /// <summary>
        /// 存于Session的 用户名
        /// </summary>
        public String SessionInfo_Name
        {
            get
            {
                return Session["LoginedName"] as String;
            }
            set
            {
                Session["LoginedName"] = value;
            }
        }
        /// <summary>
        /// 存于Session的 用户名
        /// </summary>
        public int SessionInfo_Authority
        {
            get
            {
                return (int)Session["LoginedAuthority"];
            }
            set
            {
                Session["LoginedAuthority"] = value;
            }
        }
    }
}