using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCC.FunctionMethod;
using WebCC.FunctionMethodDB;
using WebCC.Models;
/// <summary>
/// 静态变量   每一个客户端都可以改变
/// </summary>
namespace WebCC.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //new yongyuceshishuju().basicInfo();
            //new yongyuceshishuju().TestData2();
            //new yongyuceshishuju().TestData3();
            //new yongyuceshishuju().TestData4();
            return View();
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            string stm = Request.Form["STM"];

            // 第一层 1 2 0 分别代表 id错误 密码错误 登陆成功
            // 第二层 1 2 3 分别代表 管理 教师 学生
            switch (MTSFunction.STM(Convert.ToInt32(stm), login))
            {
                case 1:
                    //暂时用   后面用Ajax代替
                    Response.Write("<script>alert('无此ID，请检查');</script>");
                    //return View();
                    break;
                case 2:
                    //暂时用   后面用Ajax代替
                    Response.Write("<script>alert('密码错误');</script>");
                    //return View();
                    break;
                case 0:
                    FormsAuthentication.SetAuthCookie(login.ID, false);
                    switch (stm)
                    {
                        case "1":
                            SetSession(login.ID, 1);
                            return RedirectToAction("Index", "Manager");
                        case "2":
                            SetSession(login.ID, 2);
                            return RedirectToAction("Index", "Teacher");
                        case "3":
                            SetSession(login.ID, 3);
                            return RedirectToAction("Index", "Student");
                    }
                    break;
            }
            return View(new Login());
        }
        /// <summary>
        /// 设置用户Session信息
        /// </summary>
        /// <param name="login"></param>
        /// <param name="i"></param>
        public void SetSession(String login,int i)
        {
            IDataV context = MTSContext.Context(i);
            //login 指的是编号
            SessionInfo_Num = login;
            SessionInfo_Name = context.GetName(login);
            SessionInfo_ID = context.GetID(login);
            SessionInfo_Authority = i;
        }
        /// <summary>
        /// 用户注销操作
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }


        //----------------------------无关项-------------------------------------

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Authority_table ar = db.Authority_table.First();
            ViewData["AR"] = ar;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}