using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCC.FunctionMethodDB
{
    /// <summary>
    /// 用于 学生 老师 管理的共性 
    /// </summary>
    public interface IDataV
    {
        /// <summary>
        /// 根据ID获取密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        String GetPwd(int id);

        /// <summary>
        /// 根据ID设置密码 1 ok 0失败
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int SetPwd(int id, String newPwd);

        /// <summary>
        /// 管理员登陆判断
        /// 返回 0 表明登陆成功
        /// 返回 1 表明无此编号  返回 2 表明密码错误
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        int CheckLoginInfo(String ID,String Pwd);

        /// <summary>
        /// 根据登陆ID获取DB id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetID(String id);

        /// <summary>
        /// 根据登陆ID获取Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        String GetName(String id);
    }
}
