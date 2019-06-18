using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationManagerData : IData, IDataV
    {
        #region 管理表

        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.Arranger_table.Add(obj as Arranger_table);
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
        public int AddAll(List<Arranger_table> teas)
        {
            try
            {
                foreach (Arranger_table stu in teas)
                    db.Arranger_table.Add(stu);
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
                var user = (from e in db.Arranger_table
                            where e.NameArranger == str
                            select e).FirstOrDefault();
                db.Arranger_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为Arranger_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Arranger_table stu = obj as Arranger_table;
                var user = (from e in db.Arranger_table
                            where e.NameArranger == stu.NameArranger
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
                var user = (from e in db.Arranger_table
                            where e.NumberArranger == stu
                            select e).FirstOrDefault();
                //密码不可见
                user.PasscodeArranger = "";
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
        public Object Select(int obj)
        {
            try
            {
                var user = (from e in db.Arranger_table
                            where e.IDArranger == obj
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
        /// 查询所有Tea info
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object SelectAll()
        {
            try
            {
                var user = from e in db.Arranger_table
                           select e;
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region 管理员界面

        #region 用户信息
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        public List<Authority_table> GetAuthority_table()
        {
            var auth = from e in db.Authority_table
                       select e;
            return auth.ToList();
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public int SetAuthority_table(int level)
        {
            try
            {

                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }
        /// <summary>
        /// 获取管理元个人信息
        /// </summary>
        /// <param name="num">管理员编号</param>
        /// <returns></returns>
        public ManageManager_V GetManageManager_View(String num)
        {
            var auth = from e in db.ManageManager_V
                       where e.NumberArranger == num
                       select e;
            if (auth.FirstOrDefault() == null)
                return (new ManageManager_V());
            return auth.FirstOrDefault() as ManageManager_V;
        }
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns></returns>
        public List<ManageManager_V> GetManageManagers_View()
        {
            var auth = from e in db.ManageManager_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return (new List<ManageManager_V>());
            return auth.ToList();
        }
        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <returns></returns>
        public List<ManageTeacher_V> GetManageTeachers_View()
        {
            var auth = from e in db.ManageTeacher_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return (new List<ManageTeacher_V>());
            return auth.ToList();
        }
        /// <summary>
        /// 获取学生信息 
        /// </summary>
        /// <returns></returns>
        public List<ManageStudent_V> GetManageStudents_View()
        {
            var auth = from e in db.ManageStudent_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return (new List<ManageStudent_V>());
            return auth.ToList();
        }
        #endregion

        #region 课程信息

        /// <summary>
        /// 已开设课程信息 增删改查 视图
        /// </summary>
        /// <returns></returns>
        public List<ManageFinishedSetCourse_V> GetManageFinishedSetCourse_View()
        {
            var auth = from e in db.ManageFinishedSetCourse_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return new List<ManageFinishedSetCourse_V>();
            return auth.ToList();
        }
        /// <summary>
        /// 学生选课信息 增删改查  视图
        /// </summary>
        /// <returns></returns>
        public List<ManageStuChooseCourse_V> GetManageStuChooseCourse_View()
        {
            var auth = from e in db.ManageStuChooseCourse_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return new List<ManageStuChooseCourse_V>();
            return auth.ToList();
        }
        #endregion

        #region 成绩信息

        /// <summary>
        /// 学生成绩信息
        /// </summary>
        /// <returns></returns>
        public List<ManageStuGrade_V> GetManageStuGrade_View()
        {
            var auth = from e in db.ManageStuGrade_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return new List<ManageStuGrade_V>();
            return auth.ToList();
        }

        #endregion

        #region 后勤信息

        //Dorm用OperationDormData类操作
        //Building用OperationBuildingData类操作

        /// <summary>
        /// 学生住宿信息 增删改查   视图
        /// </summary>
        /// <returns></returns>
        public List<ManageLiveDorm_V> GetManageLiveDorm_View()
        {
            var auth = from e in db.ManageLiveDorm_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return new List<ManageLiveDorm_V>();
            return auth.ToList();
        }

        /// <summary>
        /// 教室信息 增删改查  视图
        /// </summary>
        /// <returns></returns>
        public List<ManageClassroom_V> GetManageClassroom_View()
        {
            var auth = from e in db.ManageClassroom_V
                       select e;
            if (auth.FirstOrDefault() == null)
                return (new List<ManageClassroom_V>());
            return auth.ToList();
        }
        #endregion

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
                var user = (from e in db.Arranger_table
                            where e.IDArranger == id
                            select e).FirstOrDefault();
                return user.PasscodeArranger;
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
                var user = (from e in db.Arranger_table
                            where e.IDArranger == id
                            select e).FirstOrDefault();

                user.PasscodeArranger = newPwd;
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
                var mana = from d in db.Arranger_table
                           where d.NumberArranger == ID
                           select d;
                if (mana.FirstOrDefault() == null)
                    return 1;
                if (!PasscodeTransfer.PwdIsCompare(mana.FirstOrDefault().PasscodeArranger, Pwd))
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
            var stu = from d in db.Arranger_table
                      where d.NumberArranger == id
                      select d;
            return stu.FirstOrDefault().IDArranger;
        }

        /// <summary>
        /// 根据登陆ID获取Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String GetName(String id)
        {
            var stu = from d in db.Arranger_table
                      where d.NumberArranger == id
                      select d;
            return stu.FirstOrDefault().NameArranger;
        }

        #endregion
    }
}