using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCC.Models;

namespace WebCC.FunctionMethod
{
    public class NewCourseeFuction
    {
        /// <summary>
        /// 通过上传的信息设置新开的课程的信息
        /// </summary>
        /// <param name="info">client端上传的信息</param>
        /// <param name="id">开课老师id</param>
        /// <returns></returns>
        public static NewCourse_table AddNewCourse(TeacherBeginSetNewCourse_Post info,int id)
        {
            NewCourse_table newCourse = new NewCourse_table();
            //课程建立时间
            newCourse.SetTimeNewCourse = DateTime.Now;
            //开始上课时间
            newCourse.BeginTimeNewCourse = DateTime.Now;

            newCourse.IDCourse = info.IDCourse;
            newCourse.IDSchoolhour = info.IDSchoolhour;
            newCourse.IDClassroom = info.IDClassroom;
            newCourse.NatureNewCourse = info.NatureNewCourse;
            
            newCourse.StateNewCourse = info.StateNewCourse;
            newCourse.AccommodateNewCourse = info.AccommodateNewCourse;
            newCourse.IDTeacher = id;
            
            return newCourse;
        }
    }
}