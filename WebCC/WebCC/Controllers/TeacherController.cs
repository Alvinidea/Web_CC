using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebCC.Filter;
using WebCC.FunctionMethod;
using WebCC.FunctionMethodDB;
using WebCC.Models;

namespace WebCC.Controllers
{
    [LoginAuthorize]
    public class TeacherController : BaseController
    {

        public TeacherController()
        {

        }
        // GET: Teacher
        #region 只是显示

        // GET: Student
        [LoginAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 教师信息 视图 ManageTeacher_V
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult TeacherInfo()
        {
            return View(new OperationTeacherData()
                .GetTeacher_ViewInfo(SessionInfo_ID));
        }

        #region 修改密码
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
            int isNotSccess = MTSFunction.ModifyPwd(SessionInfo_ID,2,Pwd);
            switch (isNotSccess)
            {
                case 0:
                    Response.Write("<script>alert('密码修改完毕')</script>");
                    break;
                case 1:
                    Response.Write("<script>alert('旧密码输入错误！请重新输入！')</script>");
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
        #endregion

        #endregion

        #region 已开设课程显示  视图
        /// <summary>
        /// 已开设课程显示  视图
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult TeacherFinishedSetCourse()
        {
            return View(new OperationTeacherData().
                GetTeacherFinishedSetCourse_View(SessionInfo_ID));
        }

        #endregion

        #region 开设选课 可操作 （未设置） 无类型页面
        /// <summary>
        /// 开设选课 可操作 （未设置） 无类型页面
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult TeacherBeginSetNewCourse()
        {
            List<int> Course = new List<int>();
            List<int> Classroom = new List<int>();
            List<int> Schooltime = new List<int>();
            var Courses = from e in db.Course_table
                                 select e;
            var Classrooms = from e in db.Classroom_table
                                select e;
            var Schooltimes = from e in db.Schoolhour_table
                             select e;
            foreach (var course in Courses)
            {
                Course.Add(course.IDCourse);
            }
            foreach (var course in Classrooms)
            {
                Classroom.Add(course.IDClassroom);
            }
            foreach (var course in Schooltimes)
            {
                Schooltime.Add(course.IDSchoolhour);
            }
            ViewBag.Course = Course;
            ViewBag.Classroom = Classroom;
            ViewBag.Schooltime = Schooltime;
            return View();
        }
        /// <summary>
        /// 提交开设选课 可操作 （未设置） 无类型页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherBeginSetNewCourse_Post(TeacherBeginSetNewCourse_Post info)
        {
            NewCourse_table newC = NewCourseeFuction.AddNewCourse(info, SessionInfo_ID);
            if(new OperationNewCourseData().Add(newC) == 1)
                return Json(new { msg = "创建课程成功!!!" }, 
                    JsonRequestBehavior.AllowGet);
            else
                return Json(new { IDCourse = 0 },
                    JsonRequestBehavior.AllowGet);
        }



        #region 开设选课 (更新版本)
        /// <summary>
        /// 获取第一个页面
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult TeacherBeginSetNewCourse_jsonGet()
        {
            List<int> Classroom = new List<int>();
            List<int> Schooltime = new List<int>();
            var Classrooms = from e in db.Classroom_table
                             select e;
            var Schooltimes = from e in db.Schoolhour_table
                              select e;

            foreach (var course in Classrooms)
            {
                Classroom.Add(course.IDClassroom);
            }
            foreach (var course in Schooltimes)
            {
                Schooltime.Add(course.IDSchoolhour);
            }
            ViewBag.Classroom = Classroom;
            ViewBag.Schooltime = Schooltime;

            List<Course_table> view =new OperationCourseData().SelectAll() as List<Course_table>;
            PagingDeal.GetPageInfo(view.Count, 1);
            //设置可开设课程   分页总数
            ViewBag.totalPage = PagingDeal.PageInfo[0];

            //暂时不能用   
            //TeacherBeginSetNewCourse_jsonGet 对应页面的126 行
            //List<TeacherFinishedSetCourse_V> list = new OperationTeacherData().GetTeacherFinishedSetCourse_View(SessionInfo_ID);
            //PagingDeal.GetPageInfo(list.Count, 1);
            ////设置已开设课程   分页总数
            //ViewBag.totalPage2 = PagingDeal.PageInfo[0];
            return View();
        }
        /// <summary>
        /// 获取 可设置课程信息 （第一次加载文档 和 分页的时候）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherBeginSetNewCourse_jsonGet(int currentPage)
        {
            //查询信息
            var view = new OperationCourseData().SelectAll() as List<Course_table>;
            //分页处理
            PagingDeal.GetPageInfo(view.Count, currentPage);
            //设置可开设课程       分页总数
            ViewBag.totalPage = PagingDeal.PageInfo[0];
            return Json(view.Skip(PagingDeal.Count * (currentPage - 1)).Take(PagingDeal.PageInfo[1]),
                JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取 已设置课程信息 （第一次加载文档 和 分页的时候）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherBeginSetNewCourse_jsonGet_hasBeenSet(int currentPage2)
        {
            List<TeacherFinishedSetCourse_V> list =
                new OperationTeacherData().GetTeacherFinishedSetCourse_View(SessionInfo_ID);

            //暂时不能用   
            //TeacherBeginSetNewCourse_jsonGet 对应页面的126 行
            // 本页179行
            //PagingDeal.GetPageInfo(list.Count, currentPage2);
            ////设置已开设课程   分页总数
            //ViewBag.totalPage2 = PagingDeal.PageInfo[0];
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取准备开设的课程信息  addTr(IDCourse)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherBeginSetNewCourse_jsonGet_choose(int IDCourse)
        {
            //判断是否已经开设此课程 已开则
            if (new OperationNewCourseData().IsSetTheCourse(SessionInfo_ID,IDCourse) == true)
            {
                return Json(new { IDCourse = 0},JsonRequestBehavior.AllowGet);
            }
            var info = new OperationCourseData().Select(IDCourse);
            return Json(new OperationCourseData().Select(IDCourse),
                JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加选课 可选课程信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherBeginSetNewCourse_jsonSet_add(TeacherBeginSetNewCourse_Post setNewCourse_Post)
        {
            //转换开设课程信息
            NewCourse_table newC = NewCourseeFuction.AddNewCourse(setNewCourse_Post,SessionInfo_ID);

            if (new OperationNewCourseData().Add(newC) == 1)
            {
                List < TeacherFinishedSetCourse_V >  list = 
                    new OperationTeacherData().GetTeacherFinishedSetCourse_View(SessionInfo_ID,setNewCourse_Post.IDCourse);
                return Json(list,JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { IDCourse = 0 }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 删除选课 可选课程信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherBeginSetNewCourse_jsonSet_delete(int IDCourse)
        {
            if (0 == new OperationNewCourseData().Delete(SessionInfo_ID,IDCourse))
            {
                //代表未开设过此课程  这儿的IDCourse只是借用名称 传消息
                return Json(new { IDCourse = IDCourse, msg = 0 }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { IDCourse = IDCourse, msg = 1 }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        #region MyRegion

        /// <summary>
        /// 获取学生本课程成绩单  视图
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult TeacherFinishedGetGrade()
        {
            return View(new OperationTeacherData().
                GetTeacherFinishedGetGrade_View(SessionInfo_ID));
        }
        /// <summary>
        /// 根据课程号码获取学生本课程成绩单   视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [LoginAuthorize]
        public ActionResult TeacherFinishedGetGrade_AccordingNum(String num)
        {
            ////这儿有问题
            //return View("TeacherFinishedGetGrade", view);
            return View("TeacherFinishedGetGrade", 
                new OperationTeacherData().GetTeacherFinishedGetGrade_View_Add(SessionInfo_ID,num));
        }
        /// <summary>
        /// 获取更改学生成绩页面 ajax提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherSetStuGrade()
        {
            var view = (from e in db.TeacherFinishedGetGrade_V
                        where e.IDTeacher == SessionInfo_ID
                       select e).ToList();
            if (view == null)
                View(new List<NewCourse_table>());
            return Json(view,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取更改学生成绩页面 ajax提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TeacherSetStuGrade_Update(int stu)
        {
            var view = (from e in db.TeacherFinishedGetGrade_V
                        where e.IDTeacher == SessionInfo_ID
                        select e).ToList();
            if (view == null)
                View(new List<NewCourse_table>());
            return Json(view, JsonRequestBehavior.AllowGet);
        }
        #endregion

       
    }
}