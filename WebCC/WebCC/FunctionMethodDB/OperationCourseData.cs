using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationCourseData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {

            try
            {
                db.Course_table.Add(obj as Course_table);
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
        public int AddAll(List<Course_table> teas)
        {
            try
            {
                foreach (Course_table stu in teas)
                    db.Course_table.Add(stu);
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
        public override int Delete(Object obj)
        {
            try
            {
                String str = (String)obj;
                var user = (from e in db.Course_table
                            where e.NumberCourse == str
                            select e).FirstOrDefault();
                db.Course_table.Remove(user);
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
                var user = (from e in db.Course_table
                            where e.IDCourse == obj
                            select e).FirstOrDefault();
                db.Course_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为Course_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Course_table stu = obj as Course_table;
                var user = (from e in db.Course_table
                            where e.NumberCourse == stu.NumberCourse
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
                String stu = (String)obj;
                var user = (from e in db.Course_table
                            where e.NumberCourse == stu
                            select e).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 通过ID的单个数据查询
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object Select(int obj)
        {
            try
            {
                var user = (from e in db.Course_table
                            where e.IDCourse == obj
                            select e).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 通过ID的单个数据查询
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object SelectAll()
        {
            try
            {
                //解决循环引用
                db.Configuration.ProxyCreationEnabled = false;

                var user = from e in db.Course_table
                            select e;
                if (user.FirstOrDefault() == null)
                    return new List<Course_table>();
                return user.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}