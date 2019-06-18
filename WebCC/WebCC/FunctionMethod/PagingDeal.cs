using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethod
{
    public class PagingDeal
    {
        /// <summary>
        /// 页面数据条数
        /// </summary>
        static int count = 5;
        public static int Count { get { return count; } set { count = value; } }
        /// <summary>
        ///  [0] 总页数  [1] 获取的页数
        /// </summary>
        static int[] pageinfo = new int[2];
        /// <summary>
        ///  [0] 总页数  [1] 获取的页数
        /// </summary>
        public static int[] PageInfo { get { return pageinfo; } set { pageinfo = value; } }
        /// <summary>
        /// 获取分页信息   [0] 总页数  [1] 获取行数
        /// </summary>
        /// <param name="tatolCount">数据总条目</param>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        public static void GetPageInfo(int tatolCount,int currentPage)
        {
            //总页数
            pageinfo[0] = (tatolCount / count) + ((tatolCount % count == 0) ? 0 : 1);
            if (currentPage == pageinfo[0]) //判断当前页是不是尾页
            {//若是尾页
                if (tatolCount % count == 0)
                    //判断是不是刚好充满 例子：当tatolCount=4 pageinfo[0] = 2  count = 2 时候
                    //应该返回 一页规定的行数 也就是count
                    pageinfo[1] = count;
                else
                    //否则就应该 返回 tatolCount % count 最后一页的行数
                    pageinfo[1] = tatolCount % count;
            }
            else
                pageinfo[1] = count;
        }
    }
}