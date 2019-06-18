using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WebCC.FunctionMethodDB;

namespace WebCC.FunctionMethod
{
    /// <summary>
    /// 关于M T S的上下文
    /// </summary>
    public class MTSContext
    {
        /// <summary>
        /// 密码上下文
        /// </summary>
        /// <param name="idtype"></param>
        /// <returns></returns>
        public static IDataV Context(int idtype)
        {
            //反射
            Assembly assembly = Assembly.GetExecutingAssembly();
            if (idtype == 1)
                return (IDataV)assembly.CreateInstance("WebCC.FunctionMethodDB.OperationManagerData");
            else if (idtype == 2)
                return (IDataV)assembly.CreateInstance("WebCC.FunctionMethodDB.OperationTeacherData");
            else
                return (IDataV)assembly.CreateInstance("WebCC.FunctionMethodDB.OperationStudentData");
        }
    }
}