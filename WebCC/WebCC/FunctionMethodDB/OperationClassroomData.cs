using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationClassroomData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.Classroom_table.Add(obj as Classroom_table);
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
        public int AddAll(List<Classroom_table> teas)
        {

            try
            {
                foreach (Classroom_table stu in teas)
                    db.Classroom_table.Add(stu);
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
                int str = (int)obj;
                var user = (from e in db.Classroom_table
                            where e.IDClassroom == str
                            select e).FirstOrDefault();
                db.Classroom_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为Classroom_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Classroom_table stu = obj as Classroom_table;
                var user = (from e in db.Classroom_table
                            where e.IDClassroom == stu.IDClassroom
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
                var user = (from e in db.Classroom_table
                            where e.IDClassroom == stu
                            select e).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 通过编号的单个数据查询  int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object SelectAll()
        {
            try
            {
                var user = from e in db.Classroom_table
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