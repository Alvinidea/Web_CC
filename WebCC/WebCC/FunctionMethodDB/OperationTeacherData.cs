using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationTeacherData : IData, IDataV
    {
        #region 教师表

        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.Teacher_table.Add(obj as Teacher_table);
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
        /// <param name="teas"></param>
        public int AddAll(List<Teacher_table> teas)
        {
            try
            {
                foreach (Teacher_table stu in teas)
                    db.Teacher_table.Add(stu);
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
                var user = (from e in db.Teacher_table
                            where e.NumberTeacher == str
                            select e).FirstOrDefault();
                db.Teacher_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 单个数据删除 通过id
        /// </summary>
        /// <param name="obj"></param>
        public int Delete(int obj)
        {
            try
            {
                var user = (from e in db.Teacher_table
                            where e.IDTeacher == obj
                            select e).FirstOrDefault();
                db.Teacher_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为Teacher_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Teacher_table stu = obj as Teacher_table;
                var user = (from e in db.Teacher_table
                            where e.NumberTeacher == stu.NumberTeacher
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
                var user = (from e in db.Teacher_table
                            where e.NumberTeacher == stu
                            select e).FirstOrDefault();
                //密码不可见
                //user.PasscodeTeacher = "";
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 通过编号的单个数据查询  String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  Object Select(int obj)
        {
            try
            {
                var user = (from e in db.Teacher_table
                            where e.IDTeacher == obj
                            select e).FirstOrDefault();
                //密码不可见
                //user.PasscodeTeacher = "";
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region jiaoshi模块视图 
        /// <summary>
        /// 通过id 获取 学生详细信息
        /// </summary>
        /// <param name="id"> 学生id </param>
        /// <returns></returns>
        public ManageTeacher_V GetTeacher_ViewInfo(int id)
        {
            var Teacher = from e in db.ManageTeacher_V
                          where e.IDTeacher == id
                          select e;
            ManageTeacher_V stuInfo = Teacher.FirstOrDefault() as ManageTeacher_V;
            return stuInfo;
        }
        /// <summary>
        /// 通过教师编号 获取 教师详细信息
        /// </summary>
        /// <param name="num"> 学生编号 </param>
        /// <returns></returns>
        public ManageTeacher_V GetTeacher_ViewInfo(String num)
        {
            var Teacher = from e in db.ManageTeacher_V
                          where e.NumberTeacher == num
                          select e;
            ManageTeacher_V stuInfo = Teacher.FirstOrDefault() as ManageTeacher_V;
            return stuInfo;
        }
        /// <summary>
        /// 通过教师编号 获取 已选课程
        /// </summary>
        /// <param name="num"> 教师编号</param>
        /// <returns></returns>
        public List<TeacherFinishedSetCourse_V> GetTeacherFinishedSetCourse_View(int tid)
        {

            var view = from e in db.TeacherFinishedSetCourse_V
                       where e.IDTeacher == tid
                       select e;
            if (view == null || view.FirstOrDefault() == null)
                return new List<TeacherFinishedSetCourse_V>();
            List<TeacherFinishedSetCourse_V> list =
                view.ToList() as List<TeacherFinishedSetCourse_V>;
            return list;
        }
        /// <summary>
        /// 通过教师编号 和课程编号  获取 已选课程 (更新版本 开设课程页面用 )
        /// </summary>
        /// <param name="cid">教师编号</param>
        /// <param name="tid">课程编号</param>
        /// <returns></returns>
        public List<TeacherFinishedSetCourse_V> GetTeacherFinishedSetCourse_View(int tid, int cid)
        {

            var view = from e in db.TeacherFinishedSetCourse_V
                       where e.IDCourse == cid && e.IDTeacher == tid
                       select e;
            if (view == null || view.FirstOrDefault() == null)
                return new List<TeacherFinishedSetCourse_V>();
            List<TeacherFinishedSetCourse_V> list =
                view.ToList() as List<TeacherFinishedSetCourse_V>;
            return list;
        }

        /// <summary>
        /// 通过教师编号 获取 课程成绩
        /// </summary>
        /// <param name="num"> 教师编号 </param>
        /// <returns></returns>
        public List<TeacherFinishedGetGrade_V> GetTeacherFinishedGetGrade_View(int id)
        {
            
               var view = from e in db.TeacherFinishedGetGrade_V
                          where e.IDTeacher == id
                       select e;
            if (view == null || view.FirstOrDefault() == null)
                return new List<TeacherFinishedGetGrade_V>();
            List<TeacherFinishedGetGrade_V> list = 
                view.ToList() as List<TeacherFinishedGetGrade_V>;
            return list;
        }

        /// <summary>
        /// 通过教师id 课程号码 获取 成绩单
        /// </summary>
        /// <param name="tid">教师ID</param>
        /// <param name="num">课程号</param>
        /// <returns></returns>
        public List<TeacherFinishedGetGrade_V> GetTeacherFinishedGetGrade_View_Add(int tid, String num )
        {
            var view = from e in db.TeacherFinishedGetGrade_V
                       where e.IDTeacher == tid && num == e.NumberCourse
                       select e;
            if (view == null || num == "")
                return  (new List<TeacherFinishedGetGrade_V>());
            List<TeacherFinishedGetGrade_V> list = view.ToList();
            return list;
        }

        /// <summary>
        /// 获取更改学生成绩页面 ajax提交
        /// </summary>
        /// <param name="id">教师id</param>
        /// <returns></returns>
        public List<TeacherFinishedGetGrade_V> SetTeacherSetStuGrade(int id)
        {
            ///有问题
            var view = (from e in db.TeacherFinishedGetGrade_V
                        where e.IDTeacher == id
                        select e).ToList();
            if (view == null)
                return new List<TeacherFinishedGetGrade_V>();
            return view.ToList();
        }

        /// <summary>
        /// 通过学生编号 获取成绩
        /// </summary>
        /// <param name = "id" > 学生id </ param >
        /// < returns ></ returns >
        public List<TeacherFinishedGetGrade_V> GetTeacherGetGrades_View(String num)
        {
            var view = from e in db.TeacherFinishedGetGrade_V
                       where e.NumberStudent == num
                       select e;
            if (view == null)
                return new List<TeacherFinishedGetGrade_V>();
            List<TeacherFinishedGetGrade_V> list = view.ToList() as List<TeacherFinishedGetGrade_V>;
            return list;
        }

        #endregion

        #region 共性模块  反射实验
        /// <summary>
        /// 根据ID获取密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String GetPwd(int id)
        {
            try
            {
                var user = (from e in db.Teacher_table
                            where e.IDTeacher == id
                            select e).FirstOrDefault();
                return user.PasscodeTeacher;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 根据ID设置密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SetPwd(int id, String newPwd)
        {
            try
            {
                var user = (from e in db.Teacher_table
                            where e.IDTeacher == id
                            select e).FirstOrDefault();

                user.PasscodeTeacher = newPwd;
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
                var mana = from d in db.Teacher_table
                           where d.NumberTeacher == ID
                           select d;
                if (mana.FirstOrDefault() == null)
                    return 1;
                if (!PasscodeTransfer.PwdIsCompare(mana.FirstOrDefault().PasscodeTeacher, Pwd))
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
            var stu = from d in db.Teacher_table
                      where d.NumberTeacher == id
                      select d;
            return stu.FirstOrDefault().IDTeacher;
        }

        /// <summary>
        /// 根据登陆ID获取Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String GetName(String id)
        {
            var stu = from d in db.Teacher_table
                      where d.NumberTeacher == id
                      select d;
            return stu.FirstOrDefault().NameTeacher;
        }
        #endregion
    }
}