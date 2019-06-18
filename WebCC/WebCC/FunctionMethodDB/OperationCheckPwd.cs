using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    /// <summary>
    /// 被 PasscodeTransfer调用
    /// </summary>
    public class OperationCheckPwd : IData
    {
        /// <summary>
        /// 无意义
        /// </summary>
        public override int Add(Object obj)
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
        /// 无意义
        /// </summary>
        /// <param name="obj"></param>
        public override int Delete(Object obj)
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
        /// 形参为Authority_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public override int Modify(Object obj)
        {
            try
            {
                Authority_table stu = obj as Authority_table;
                var user = (from e in db.Authority_table
                            where e.IDAuthority == stu.IDAuthority
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
                var user = (from e in db.Authority_table
                            where e.IDAuthority == stu
                            select e).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}