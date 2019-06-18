using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;

namespace WebCC.FunctionMethodDB
{
    /// <summary>
    /// 纯密码处理
    /// 密码加密 密码解密  登陆验证密码会用到 改密码会用到
    /// </summary>
    public class PasscodeTransfer
    {
        /// <summary>
        /// 密码对比  是否相同
        /// </summary>
        /// <param name="pwdL"></param>
        /// <param name="pwdD"></param>
        /// <returns></returns>
        public static Boolean PwdIsCompare(String pwdL,String pwdD)
        {
            //这儿需要将密码 加密
            pwdL = PwdEncryption(pwdL);
            pwdD = PwdEncryption(pwdD);
            //加密之后比较
            if (pwdD.Equals(pwdL))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="pwdL"></param>
        /// <returns></returns>
        public static String PwdEncryption(String pwdL)
        {
            string cl = pwdL;
            string pwd = "";
            StringBuilder sf = new StringBuilder(pwd);
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                sf.Append(pwd).Append(s[i].ToString("X"));
                //pwd = pwd + s[i].ToString("X");

            }
            return sf.ToString();

        }

    }

}