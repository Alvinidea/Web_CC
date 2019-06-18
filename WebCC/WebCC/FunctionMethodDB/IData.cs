using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCC.FunctionMethodDB
{
    public abstract class IData
    {
        
        protected DBWebCCEntities db = new DBWebCCEntities();
        /// <summary>
        /// 增
        /// 返回值为int 类型 1成功  0 失败
        /// </summary>
        public abstract int Add(Object obj);
        /// <summary>
        /// 删
        ///  返回值为int 类型 1成功  0 失败
        /// </summary>
        public abstract int Delete(Object obj);
        /// <summary>
        /// 改
        /// 返回值为int 类型 1成功  0 失败
        /// </summary>
        public abstract int Modify(Object obj);
        /// <summary>
        /// 查
        /// 返回值为int 类型 对象成功 null 失败
        /// </summary>
        public abstract Object Select(Object obj);
    }
}
