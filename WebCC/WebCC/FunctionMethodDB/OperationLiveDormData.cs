using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class OperationLiveDormData : IData
    {
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public override int Add(Object obj)
        {
            try
            {
                db.LiveDorm_table.Add(obj as LiveDorm_table);
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
        public int AddAll(List<LiveDorm_table> teas)
        {
            try
            {
                foreach (LiveDorm_table stu in teas)
                    db.LiveDorm_table.Add(stu);
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
                var user = (from e in db.LiveDorm_table
                            where e.IDLiveDorm == str
                            select e).FirstOrDefault();
                db.LiveDorm_table.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 形参为LiveDorm_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                LiveDorm_table stu = obj as LiveDorm_table;
                var user = (from e in db.LiveDorm_table
                            where e.IDLiveDorm == stu.IDLiveDorm
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
                var user = (from e in db.LiveDorm_table
                            where e.IDLiveDorm == stu
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
                var user = from e in db.LiveDorm_table
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