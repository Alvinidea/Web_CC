using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationDormData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.Dorm_table.Add(obj as Dorm_table);
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
        public int AddAll(List<Dorm_table> teas)
        {

            try
            {
                foreach (Dorm_table stu in teas)
                    db.Dorm_table.Add(stu);
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
                int str = (int)obj;
                var user = (from e in db.Dorm_table
                            where e.IDDorm == str
                            select e).FirstOrDefault();
                db.Dorm_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为Dorm_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Dorm_table stu = obj as Dorm_table;
                var user = (from e in db.Dorm_table
                            where e.IDDorm == stu.IDDorm
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
                var user = (from e in db.Dorm_table
                            where e.IDDorm == stu
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
                var user = from e in db.Dorm_table
                           select e;
                if (user.FirstOrDefault() == null)
                    return new List<Dorm_table>();
                return user.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}