using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationStudyCourseData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.StudyCourse_table.Add(obj as StudyCourse_table);
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
        public int AddAll(List<StudyCourse_table> teas)
        {

            try
            {
                foreach (StudyCourse_table stu in teas)
                    db.StudyCourse_table.Add(stu);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 单个数据删除 通过 IDNewCourse ak 
        /// </summary>
        /// <param name="obj"></param>
        public override int Delete(Object obj)
        {
            try
            {
                int str = (int)obj;
                var user = (from e in db.StudyCourse_table
                            where e.IDNewCourse == str
                            select e).FirstOrDefault();
                db.StudyCourse_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为StudyCourse_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                StudyCourse_table stu = obj as StudyCourse_table;
                var user = (from e in db.StudyCourse_table
                            where e.IDStudyCourse == stu.IDStudyCourse
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
                var user = (from e in db.StudyCourse_table
                            where e.IDStudyCourse == stu
                            select e).FirstOrDefault();
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
                var user = from e in db.StudyCourse_table
                           select e;
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}