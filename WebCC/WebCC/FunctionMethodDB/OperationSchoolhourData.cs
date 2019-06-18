using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationSchoolhourData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.Schoolhour_table.Add(obj as Schoolhour_table);
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
        public int AddAll(List<Schoolhour_table> teas)
        {
            try
            {
                foreach (Schoolhour_table stu in teas)
                    db.Schoolhour_table.Add(stu);
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
                var user = (from e in db.Schoolhour_table
                            where e.IDSchoolhour == str
                            select e).FirstOrDefault();
                db.Schoolhour_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为Schoolhour_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {

            try
            {
                Schoolhour_table stu = obj as Schoolhour_table;
                var user = (from e in db.Schoolhour_table
                            where e.IDSchoolhour == stu.IDSchoolhour
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
        /// 通过id的单个数据查询  int
        /// </summary>
        /// <param name="obj">id</param>
        /// <returns></returns>
        public override Object Select(Object obj)
        {
            try
            {
                int stu = (int)obj;
                var user = (from e in db.Schoolhour_table
                            where e.IDSchoolhour == stu
                            select e).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// All数据查询
        /// </summary>
        /// <param name="obj">id</param>
        /// <returns></returns>
        public Object SelectAll()
        {
            try
            {
                var user = from e in db.Schoolhour_table
                            select e;
                if (user.FirstOrDefault() == null)
                    return new List<Schoolhour_table>();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}