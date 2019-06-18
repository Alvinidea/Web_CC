using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationNewCourseData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.NewCourse_table.Add(obj as NewCourse_table);
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
        public int AddAll(List<NewCourse_table> teas)
        {
            try
            {
                foreach (NewCourse_table stu in teas)
                    db.NewCourse_table.Add(stu);
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
        /// <param name="obj">已开课程id</param>
        public override int Delete(Object obj)
        {
            try
            {
                int str = (int)obj;
                var user = (from e in db.NewCourse_table
                            where e.IDNewCourse == str
                            select e).FirstOrDefault();
                db.NewCourse_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// /// <summary>
        /// 单个数据删除 
        /// </summary>
        /// <param name="tid">教师id</param>
        /// <param name="cid">课程id</param>
        /// <returns></returns>
        public int Delete(int tid,int cid)
        {
            try
            {
                var user = (from e in db.NewCourse_table
                            where e.IDTeacher == tid && e.IDCourse == cid
                            select e).FirstOrDefault();
                db.NewCourse_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为NewCourse_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                NewCourse_table stu = obj as NewCourse_table;
                var user = (from e in db.NewCourse_table
                            where e.IDNewCourse == stu.IDNewCourse
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
        /// 通过编号的单个数据查询  int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Object Select(Object obj)
        {
            try
            {
                int stu = (int)obj;
                var user = (from e in db.NewCourse_table
                            where e.IDNewCourse == stu
                            select e).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #region 已开课程有关视图查询

        /// <summary>
        /// 学生获取所有已开课程
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object GetStudentBeginNewCourse_View()
        {
            try
            {
                var view = from e in db.StudentBeginNewCourse_V
                           select e;
                return view;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 老师通过  IDCourse  判断是否已开此课程 已开返回true 否则返回false
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Boolean IsSetTheCourse(int id,int IDCourse)
        {
            try
            {
                var view = from e in db.NewCourse_table
                           where e.IDCourse == IDCourse && id == e.IDTeacher
                           select e;
                if (view.FirstOrDefault() == null)
                    return false ;
                else
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}