using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationStudentData:IData,IDataV
    {
        #region 学生表增删改查
        /// <summary>
        /// 单个对象添加 Student_table类型
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.Student_table.Add(obj as Student_table);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 多个对象添加
        /// </summary>
        /// <param name="stus"></param>
        public int AddAll(List<Student_table> stus)
        {
            try
            {
                foreach (Student_table stu in stus)
                    db.Student_table.Add(stu);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 单个数据删除 通过编号
        /// </summary>
        /// <param name="obj"></param>
        public override int Delete(Object obj)
        {
            try
            {
                String str = obj as String;
                var user = (from e in db.Student_table
                            where e.NumberStudent == str
                            select e).FirstOrDefault();
                db.Student_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        /// <summary>
        /// 形参为Student_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Student_table stu = obj as Student_table;
                var user = (from e in db.Student_table
                            where e.NumberStudent == stu.NumberStudent
                            select e).FirstOrDefault();
                user = stu;
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 通过编号的单个数据查询  String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Object Select(Object obj)
        {
            try
            {
                String stu = obj as String;
                var user = (from e in db.Student_table
                            where e.NumberStudent == stu
                            select e).FirstOrDefault();
                //密码不可见
                //user.PasscodeStudent = "";
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 通过ID的单个数据查询  String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  Object Select(int obj)
        {
            try
            {
                var user = (from e in db.Student_table
                            where e.IDStudent == obj
                            select e).FirstOrDefault();
                //密码不可见
                //user.PasscodeStudent = "";
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 查询所有stu info
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object SelectAll()
        {
            try
            {
                var user = from e in db.Student_table
                            select e;                
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region 学生模块视图 
        /// <summary>
        /// 通过id 获取 学生详细信息
        /// </summary>
        /// <param name="id"> 学生id </param>
        /// <returns></returns>
        public StudentInfo_V GetStudent_ViewInfo(int id)
        {
            var student = from e in db.StudentInfo_V
                          where e.IDStudent == id
                          select e;
            StudentInfo_V stuInfo = student.FirstOrDefault() as StudentInfo_V;
            return stuInfo;
        }
        /// <summary>
        /// 通过学生编号 获取 学生详细信息
        /// </summary>
        /// <param name="num"> 学生编号 </param>
        /// <returns></returns>
        public ManageStudent_V GetStudent_ViewInfo(String num)
        {
            var student = from e in db.ManageStudent_V
                          where e.NumberStudent == num
                          select e;
            ManageStudent_V stuInfo = student.FirstOrDefault() as ManageStudent_V;
            return stuInfo;
        }
        /// <summary>
        ///         /// <summary>
        /// 通过学生编号 获取 已选课程
        /// </summary>
        /// <param name="num">学生编号</param>
        /// <returns></returns>
        public List<StudentFinishedChooseCourse_V> GetStudentFinishedChooseCourse_View(String num)
        {
            var view = from e in db.StudentFinishedChooseCourse_V
                        where e.NumberStudent == num
                        select e;
            if (view == null)
                return new List<StudentFinishedChooseCourse_V>();
            List<StudentFinishedChooseCourse_V> list = view.ToList() as List<StudentFinishedChooseCourse_V>;
            return list;
        }

        /// <summary>
        ///  获取 可选课程
        /// </summary>
        /// <returns></returns>
        public List<StudentBeginNewCourse_V> GetStudentBeginNewCourse_View()
        {
            var view = from e in db.StudentBeginNewCourse_V
                       select e;
            if (view == null)
                return new List<StudentBeginNewCourse_V>();
            List<StudentBeginNewCourse_V> list = view.ToList() as List<StudentBeginNewCourse_V>;
            return list;
        }

        /// <summary>
        /// 刚刚选课后返回刚刚选课的课程信息   通过学生编号 获取 可选课程
        /// </summary>
        /// <param name="IDNewCourse"> 课程ID </param>
        /// <returns></returns>
        public List<StudentBeginNewCourse_V> GetStudentBeginNewCourse_View(int IDNewCourse)
        {
            var view = from e in db.StudentBeginNewCourse_V
                       where e.IDNewCourse == IDNewCourse
                       select e;
            if (view == null)
                return new List<StudentBeginNewCourse_V>();
            List<StudentBeginNewCourse_V> list = view.ToList() as List<StudentBeginNewCourse_V>;
            return list;
        }

        /// <summary>
        /// 通过学生编号 设置选程
        /// 返回值 1 成功 0失败
        /// </summary>
        /// <param name="id">学生id</param>
        /// <param name="cid">可选课程id</param>
        /// <returns></returns>
        public int SetStudentStudyCourse_table(int id,int cid)
        {
            StudyCourse_table snewCourse = new StudyCourse_table();
            snewCourse.IDNewCourse = cid;
            snewCourse.IDStudent = id;
            //刚选的可成绩默认 -1
            snewCourse.GradeStudyCourse = -1;
            return new OperationStudyCourseData().Add(snewCourse);
        }

        /// <summary>
        /// 通过学生编号 获取成绩
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns></returns>
        public List<StudentGetGrade_V> GetStudentGetGrades_View(String num)
        {
            var view = from e in db.StudentGetGrade_V
                       where e.NumberStudent == num && e.GradeStudyCourse != -1
                       select e;
            if (view == null)
                return new List<StudentGetGrade_V>();
            List<StudentGetGrade_V> list = view.ToList() as List<StudentGetGrade_V>;
            return list;
        }

        /// <summary>
        /// 通过学生编号和已选课程编号获取成绩
        /// </summary>
        /// <param name="id">学生id</param>
        /// <param name="cid">已选课程id</param>
        /// <returns></returns>
        public List<StudentGetGrade_V> GetStudentGetGrade_View(String num,int studyId)
        {
            var view = from e in db.StudentGetGrade_V
                       where e.NumberStudent == num && e.IDStudyCourse == studyId && e.GradeStudyCourse != -1
                       select e;
            if (view.FirstOrDefault() == null)
                return new List<StudentGetGrade_V>();
            List<StudentGetGrade_V> list = view.ToList() as List<StudentGetGrade_V>;
            return list;
        }
        #endregion


        #region 共性模块  反射实验

        public String GetPwd(int id)
        {
            try
            {
                var user = (from e in db.Student_table
                            where e.IDStudent == id
                            select e).FirstOrDefault();
                return user.PasscodeStudent;
            }
            catch (Exception e)
            {
                return null ;
            }
        }
        public int SetPwd(int id,String newPwd)
        {
            try
            {
                var user = (from e in db.Student_table
                            where e.IDStudent == id
                            select e).FirstOrDefault();

                user.PasscodeStudent = newPwd;
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// 登陆判断
        /// 返回 0 表明登陆成功
        /// 返回 1 表明无此编号  返回 2 表明密码错误
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int CheckLoginInfo(String ID, String Pwd)
        {
            {
                DBWebCCEntities db = new DBWebCCEntities();
                var mana = from d in db.Student_table
                           where d.NumberStudent == ID
                           select d;
                if (mana.FirstOrDefault() == null)
                    return 1;
                if (!PasscodeTransfer.PwdIsCompare(mana.FirstOrDefault().PasscodeStudent, Pwd))
                    return 2;
                return 0;
            }
        }
        /// <summary>
        /// 根据登陆ID获取DB id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetID(String id)
        {
            var stu = from d in db.Student_table
                      where d.NumberStudent == id
                      select d;
            return stu.FirstOrDefault().IDStudent;
        }

        /// <summary>
        /// 根据登陆ID获取Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String GetName(String id)
        {
            var stu = from d in db.Student_table
                      where d.NumberStudent == id
                      select d;
            return stu.FirstOrDefault().NameStudent;
        }
        #endregion
    }
}