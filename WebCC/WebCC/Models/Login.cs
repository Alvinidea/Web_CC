using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.Models
{
    public class Login
    {
        /// <summary>
        /// 登陆id  对应的是编号
        /// </summary>
        public String ID { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public String PassCode { get; set; }

    }
}