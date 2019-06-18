using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCC.FunctionMethod;
using WebCC.Models;

namespace WebCC.FunctionMethodDB
{
    public class MTSFunction
    {
        /// <summary>
        /// 区别管理员 教师 学生
        /// </summary>
        /// <param name="stm"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public static int STM(int stm, Login login)
        {
            //用于返回登陆状态信号
            IDataV context = MTSContext.Context(stm);
            int sign = context.CheckLoginInfo(login.ID,login.PassCode);
            return sign;


            //  这是用反射+ 简单工厂 之前的代码
            //switch (stm)
            //{
            //    case "1":
            //        验证管理员id和密码
            //        sign = CheckManaInfo(login);
            //        break;
            //    case "2":
            //        sign = CheckTeaInfo(login);
            //        验证教师id和密码
            //        break;
            //    case "3":
            //        sign = CheckStuInfo(login);
            //        验证学生id和密码
            //        break;
            //}
            //return sign;
        }

        /// <summary>
        /// 0 成功修改  1 old密码错误 2 两次密码不对应 3 登陆id 数据库错误 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="old"></param>
        /// <param name="new1"></param>
        /// <param name="new2"></param>
        /// <returns></returns>
        public static int ModifyPwd(int id, int idtype, String[] pwd)
        {
            //调用 工厂上下文 
            IDataV operate = FunctionMethod.MTSContext.Context(idtype);

            if (PasscodeTransfer.PwdIsCompare(operate.GetPwd(id), PasscodeTransfer.PwdEncryption(pwd[0])))
            {
                if (PasscodeTransfer.PwdEncryption(pwd[1]) == PasscodeTransfer.PwdEncryption(pwd[2]))//2 两次密码不对应
                {
                    //修改密码
                    if (0 == operate.SetPwd(id, PasscodeTransfer.PwdEncryption(pwd[2])))
                    {//数据库错误
                        return 3;
                    }
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }
        }










        /// <summary>
        /// 设置Session Name 用于显示
        /// 返回-1代表错误
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static String SetSessionName(String id,int stm)
        {
            IDataV context = MTSContext.Context(stm);
            return context.GetName(id);



            //DBWebCCEntities db = new DBWebCCEntities();
            //switch (stm)
            //{
            //    case 3:
            //        var stu = from d in db.Student_table
            //                  where d.NumberStudent == id
            //                  select d;
            //        return stu.FirstOrDefault().NameStudent;
            //    case 2:
            //        var tea = from d in db.Teacher_table
            //                  where d.NumberTeacher == id
            //                  select d;
            //        return tea.FirstOrDefault().NameTeacher;
            //    case 1:
            //        var mana = from d in db.Arranger_table
            //                   where d.NumberArranger == id
            //                   select d;
            //        return mana.FirstOrDefault().NameArranger;

            //};
            //return "-1";
        }


        /// <summary>
        /// 设置Session ID 用于显示
        /// 返回-1代表错误
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SetSessionID(String id, int stm)
        {
            IDataV context = MTSContext.Context(stm);
            return context.GetID(id);


            //DBWebCCEntities db = new DBWebCCEntities();

            //switch (stm)
            //{
            //    case 3:
            //        var stu = from d in db.Student_table
            //                  where d.NumberStudent == id
            //                  select d;
            //        return stu.FirstOrDefault().IDStudent;
            //    case 2:
            //        var tea = from d in db.Teacher_table
            //                  where d.NumberTeacher == id
            //                  select d;
            //        return tea.FirstOrDefault().IDTeacher;
            //    case 1:
            //        var mana = from d in db.Arranger_table
            //                   where d.NumberArranger == id
            //                   select d;
            //        return mana.FirstOrDefault().IDArranger;

            //};
            //return -1;
        }


        //  这是用反射+ 简单工厂 之前的代码

        /// <summary>
        /// 管理员登陆判断
        /// 返回 0 表明登陆成功
        /// 返回 1 表明无此编号 返回 2 表明密码错误
        /// </summary>
        /// <param name = "login" ></ param >
        /// < returns ></ returns >
        //public static int CheckManaInfo(Login login)
        //{
        //    DBWebCCEntities db = new DBWebCCEntities();
        //    var mana = from d in db.Student_table
        //               where d.NumberStudent == login.ID
        //               select d;
        //    if (mana.FirstOrDefault() == null)
        //        return 1;
        //    if (!PasscodeTransfer.PwdIsCompare(mana.FirstOrDefault().PasscodeStudent, login.PassCode))
        //        return 2;
        //    return 0;
        //}
        /// <summary>
        /// 教师登陆判断
        /// 返回 0 表明登陆成功
        /// 返回 1 表明无此编号 返回 2 表明密码错误
        /// </summary>
        /// <param name = "login" ></ param >
        /// < returns ></ returns >
        //public static int CheckTeaInfo(Login login)
        //{
        //    DBWebCCEntities db = new DBWebCCEntities();
        //    var tea = from d in db.Student_table
        //              where d.NumberStudent == login.ID
        //              select d;
        //    if (tea.FirstOrDefault() == null)
        //        return 1;
        //    if (!PasscodeTransfer.PwdIsCompare(tea.FirstOrDefault().PasscodeStudent, login.PassCode))
        //        return 2;
        //    return 0;
        //}
        /// <summary>
        /// 学生登陆判断
        /// 返回 0 表明登陆成功
        /// 返回 1 表明无此编号 返回 2 表明密码错误
        /// </summary>
        /// <param name = "login" ></ param >
        /// < returns ></ returns >
        //public static int CheckStuInfo(Login login)
        //{
        //    DBWebCCEntities db = new DBWebCCEntities();
        //    var stu = from d in db.Student_table
        //              where d.NumberStudent == login.ID
        //              select d;
        //    if (stu.FirstOrDefault() == null)
        //        return 1;
        //    if (!PasscodeTransfer.PwdIsCompare(stu.FirstOrDefault().PasscodeStudent, login.PassCode))
        //        return 2;
        //    return 0;
        //}
    }
}