using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.Models
{
    public class TeacherBeginSetNewCourse_Post
    {
        /// <summary>
        /// 开课时间
        /// </summary>
        public DateTime BeginTimeNewCourse { get; set; }
        /// <summary>
        /// 教室ID
        /// </summary>
        public int IDClassroom { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int IDCourse { get; set; }
        /// <summary>
        /// 上课时间ID
        /// </summary>
        public int IDSchoolhour { get; set; }
        /// <summary>
        /// 课程状态
        /// </summary>
        public int StateNewCourse { get; set; }
        /// <summary>
        /// 课程性质
        /// </summary>
        public int NatureNewCourse { get; set; }
        /// <summary>
        /// 容纳量
        /// </summary>
        public int AccommodateNewCourse { get; set; }

    }
}
