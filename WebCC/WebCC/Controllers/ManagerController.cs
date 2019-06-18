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
    public class ManagerController : BaseController
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        //“/Manager”的控制器或该控制器未实现 IController。

        #region 用户信息
        /// <summary>
        /// 权限信息 增删改查 基本表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageAuthority()
        {
            return View(new OperationManagerData().GetAuthority_table());
        }
        [HttpPost]
        public ActionResult ManageAuthority_Add(int auth)
        {
            int sign = new OperationManagerData().SetAuthority_table(auth);
            if (sign == 1)
                return Json(new { msg="successd"},JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 个人信息 增删改查 
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageInfo()
        {
            return View(new OperationManagerData().GetManageManager_View(SessionInfo_Num));
        }
        /// <summary>
        /// 管理员信息 增删改查 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageManager()
        {
            return View(new OperationManagerData().GetManageManagers_View());
        }
        public ActionResult ManageManager_Add([Bind(Exclude = "IDArranger,ImageArranger")] Arranger_table arranger)
        {
            arranger.ImageArranger = "这是测试用的字符串！！！";
            if(new OperationManagerData().Add(arranger)==1)
                return Json(new { msg = "Successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 教师信息 增删改查 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageTeacher()
        {
            return View(new OperationManagerData().GetManageTeachers_View());
        }
        public ActionResult ManageTeacher_Add([Bind(Exclude = "IDTeacher,ImageTeacher")] Teacher_table teacher)
        {
            teacher.ImageTeacher = "这是测试用的字符串！！！";
            if(1 == new OperationTeacherData().Add(teacher))
                return Json(new { msg = "Successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 学生信息 增删改查 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageStudent()
        {
            return View(new OperationManagerData().GetManageStudents_View());
        }


        public ActionResult ManageStudent_Add([Bind(Exclude = "PasscodeStudent,IDStudent,IDAuthority,ImageStudent")] Student_table student)
        {
            student.PasscodeStudent = "000000";
            student.IDAuthority = 10001;
            student.ImageStudent = "这是测试用的字符串！！！";
            if(new OperationStudentData().Add(student) ==1)
                return Json(new { msg = "Successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="IDStudent"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ManageStudent_Add_Delete(int IDStudent)
        {
            return Json(new { msg = IDStudent },JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑学生信息
        /// </summary>
        /// <param name="IDStudent"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ManageStudent_Add_Edit(int IDStudent)
        {
            return Json(new { msg = IDStudent }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ManageStudent_SearchByID(String NumberStudent)
        {            
            return Json(new { msg = NumberStudent }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑学生信息
        /// </summary>
        /// <param name="IDStudent"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ManageStudent_SearchByName(String NameStudent)
        {
            return Json(new { msg = NameStudent }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 课程信息
        /// <summary>
        /// 课程信息 增删改查 表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageCourse()
        {
            return View(new OperationCourseData().SelectAll());
        }
        /// <summary>
        /// 课程信息 增删改查 表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageCourse_Add([Bind(Exclude="IDCourse")] Course_table course)
        {
            if(1==new OperationCourseData().Add(course))
                return Json(new { msg = "Successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上课时间信息 增删改查 表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageSchoolhour()
        {
            return View(new OperationSchoolhourData().SelectAll());
        }
        /// <summary>
        /// 已开设课程信息 增删改查 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageFinishedSetCourse()
        {
            return View(new OperationManagerData().GetManageFinishedSetCourse_View());
        }
        /// <summary>
        /// 学生选课信息 增删改查  视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageStuChooseCourse()
        {
            return View(new OperationManagerData().GetManageStuChooseCourse_View());
        }
        #endregion

        #region 成绩信息
        /// <summary>
        /// 成绩信息  包括 成绩单 挂科 重修 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageStuGrade()
        {
            return View(new OperationManagerData().GetManageStuGrade_View());
        }
        #endregion

        #region 后勤信息
        /// <summary>
        /// 宿舍管理 增删改查  表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageDorm(int currentPage = 1)
        {
            //获取宿舍列表
            var list = new OperationDormData().SelectAll() as List<Dorm_table>;
            //调用分页处理方法
            PagingDeal.GetPageInfo(list.Count,currentPage);
            //设置分页页数
            ViewBag.totalPage = PagingDeal.PageInfo[0];
            //这儿有问题 第二次点第一页时候怎么办
            if (currentPage > 1)
            {
                return Json(list.Skip((currentPage - 1) * PagingDeal.Count).Take(PagingDeal.PageInfo[1])
                    ,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(list.Skip((currentPage - 1) * PagingDeal.Count).Take(PagingDeal.PageInfo[1]));
            }

        }
        /// <summary>
        /// 宿舍管理 增 (参数  前后端的名字要相同（就是靠名字对应的）)
        /// </summary>
        /// <param name="num"></param>
        /// <param name="mateNum"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ManageDorm_Add(int num,int mateNum)
        {
            Dorm_table dorm = new Dorm_table();
            dorm.NumDorm = num;
            dorm.CountDorm = mateNum;
            new OperationDormData().Add(dorm);
            return Json(new { msg = "successd" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 学生住宿信息 增删改查   视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageLiveDorm()
        {
            return View(new OperationManagerData().GetManageLiveDorm_View());
        }
        /// <summary>
        /// 学生住宿信息 增删改查   视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageLiveDorm_Add(
            [Bind(Exclude ="IDLiveDorm")] LiveDorm_table liveDorm)
        { 
            if( new OperationLiveDormData().Add(liveDorm)==1)
            return Json(new { msg = "Successd" }, JsonRequestBehavior.AllowGet);
                else
            return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 教学楼信息 增删改查  表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageBuilding()
        {
            return View(new OperationBuildingData().SelectAll());
        }
        /// <summary>
        /// 教学楼信息 增删改查  表
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageBuilding_Add(int num,String name,int roomNum)
        {
            Building_table building = new Building_table();
            building.NumBuilding = num;
            building.NameBuilding = name;
            building.CountBuilding = roomNum;
            if(1==new OperationBuildingData().Add(building))
                return Json(new { msg = "successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 教室信息 增删改查  视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageClassroom()
        {
            return View(new OperationManagerData().GetManageClassroom_View());
        }
        public ActionResult ManageClassroom_Add(int num, int bid, int mateNum)
        {
            Classroom_table classroom = new Classroom_table();
            classroom.NumClassroom = num;
            classroom.IDBuilding = bid;
            classroom.PeopleNumClassroom = mateNum;
            if(1==new OperationClassroomData().Add(classroom))
                return Json(new { msg = "successd" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { msg = "Failed" }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}