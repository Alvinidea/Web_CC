using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCC.Filter;
using WebCC.FunctionMethod;
using WebCC.FunctionMethodDB;

namespace WebCC.Controllers
{
    [LoginAuthorize]
    public class StudentController : BaseController
    {

        #region 第一次访问

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 学生信息 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentInfo()
        {
            var student = new OperationStudentData().GetStudent_ViewInfo(SessionInfo_ID);
            return View(student);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult ModifyPwd()
        {
            return View();
        }
        /// <summary>
        /// 修改密码Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModifyPwd(FormCollection form)
        {
            String[] Pwd = { form["oldPwd"] as String, form["firstPwd"] as String, form["secondPwd"] as String };
            int isNotSccess = MTSFunction.ModifyPwd(SessionInfo_ID, 3, Pwd);
            switch (isNotSccess)
            {
                case 0:
                    Response.Write("<script>alert('密码修改完毕')</script>");
                    break;
                case 1:
                    Response.Write("<script>alert('old密码输入错误！请重新输入！')</script>");
                    break;
                case 2:
                    Response.Write("<script>alert('两次密码不对应！请重新输入！')</script>");
                    break;
                case 3:
                    Response.Write("<script>alert('登陆id 数据库错误！ 联系管理员')</script>");
                    break;
            }
            return View();
        }
        /// <summary>
        /// 已选课程显示 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentFinishedChooseCourse()
        {
            List<StudentFinishedChooseCourse_V> view = 
                new OperationStudentData().GetStudentFinishedChooseCourse_View(SessionInfo_Num);
            return View(view);
        }
        /// <summary>
        /// 获取成绩单  视图
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentGetGrade()
        {
            return View(new OperationStudentData().
                GetStudentGetGrades_View(SessionInfo_Num));
        }
        /// <summary>
        /// 获取成绩单  视图 单科
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentGetGrade_One(int studyID)
        {
            //有问题 传Json
            return View(new OperationStudentData().GetStudentGetGrade_View(SessionInfo_Num, studyID));
        }
        
        /// <summary>
        /// 开始选课  视图
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentBeginNewCourse()
        {
            List<StudentBeginNewCourse_V> view =
             new OperationStudentData().GetStudentBeginNewCourse_View();
            return View(view);
        }
        /// <summary>
        /// 开始选课  视图
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentBeginNewCourse_Add(int idNewC)
        {
            int sign = new OperationStudentData().
                SetStudentStudyCourse_table(SessionInfo_ID, idNewC);
            if (sign == 1)
                return Json(new { msg = "Successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 选课页面功能
        /// <summary>
        /// json获取
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentBeginNewCourse_jsonGet()
        {
            //设置分页总数 初次加载使用
            PagingDeal.GetPageInfo(new OperationStudentData().GetStudentBeginNewCourse_View().Count, 1);
            //设置分页总数
            ViewBag.totalPage = PagingDeal.PageInfo[0];
            return View();
        }
        /// <summary>
        /// 获取 可选课程信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentBeginNewCourse_jsonGet(int currentPage)
        {
            List<StudentBeginNewCourse_V> view =
                 new OperationStudentData().GetStudentBeginNewCourse_View();
            PagingDeal.GetPageInfo(view.Count, currentPage);
            //设置分页总数
            ViewBag.totalPage = PagingDeal.PageInfo[0];
            return Json(view.Skip(PagingDeal.Count * (currentPage - 1)).Take(PagingDeal.PageInfo[1]),
                JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加选课 可选课程信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentBeginNewCourse_jsonSet_add(int IDNewCourse)
        {
            if (IDNewCourse != -1)
            {
                if (0 == new OperationStudentData().SetStudentStudyCourse_table(SessionInfo_ID, IDNewCourse))
                {
                    //代表已经选过此课程  这儿的IDNewCourse只是借用名称 传消息
                    return Json(new { IDNewCourse = 0 }, JsonRequestBehavior.AllowGet);
                }
                List<StudentBeginNewCourse_V> view =
                     new OperationStudentData().GetStudentBeginNewCourse_View(IDNewCourse);
                return Json(view, JsonRequestBehavior.AllowGet);
            }
            else
            {// -1 获取所有已选课程信息
                List<StudentBeginNewCourse_V> view =
                    new OperationStudentData().GetStudentBeginNewCourse_View();
                return Json(view, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 删除选课 可选课程信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentBeginNewCourse_jsonSet_delete(int IDNewCourse)
        {
            if (0 == new OperationStudyCourseData().Delete(IDNewCourse))
            {
                //代表未选过此课程  这儿的IDNewCourse只是借用名称 传消息
                return Json(new { IDNewCourse = IDNewCourse, msg = 0 }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { IDNewCourse = IDNewCourse , msg = 1}, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}