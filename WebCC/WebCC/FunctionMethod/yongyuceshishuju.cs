using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCC.FunctionMethodDB
{
    public class yongyuceshishuju
    {
        DBWebCCEntities db = new DBWebCCEntities();

        public void basicInfo()
        {
            Dorm_table dorm = new Dorm_table();
            dorm.NumDorm = 6125;
            dorm.CountDorm = 6;
            db.Dorm_table.Add(dorm);

            Building_table building = new Building_table();
            building.NameBuilding = "殒命楼";
            building.NumBuilding = 1000;
            building.CountBuilding = 120;
            db.Building_table.Add(building);

            Schoolhour_table schoolhour = new Schoolhour_table();
            schoolhour.TimesectionSchoolhour = 1;
            schoolhour.TimesectionSchoolhourDetail = 2;
            db.Schoolhour_table.Add(schoolhour);

            Course_table course = new Course_table();
            course.NumberCourse = "1000";
            course.NameCourse = "高数";
            course.ScoreCourse = 4;
            course.StudyTimeCourse = 70;
            course.ProfileCourse = "牛逼的很";
            db.Course_table.Add(course);

            db.SaveChanges();
        }

        public void TestData2()
        {
            Classroom_table classroom = new Classroom_table();
            classroom.IDBuilding = 70002;
            classroom.NumClassroom = 1234;
            classroom.PeopleNumClassroom = 60;
            db.Classroom_table.Add(classroom);

            Student_table ar = new Student_table();
            ar.IDAuthority = 10001;
            ar.NumberStudent = "000000";
            ar.PasscodeStudent = "000000";
            ar.NameStudent = "000000";
            ar.GradeStudent = 3;
            db.Student_table.Add(ar);

            Teacher_table teacher = new Teacher_table();
            teacher.IDAuthority = 10003;
            teacher.NumberTeacher = "000000";
            teacher.NameTeacher = "000000";
            teacher.PasscodeTeacher = "000000";
            db.Teacher_table.Add(teacher);

            Arranger_table ada = new Arranger_table();
            ada.IDAuthority = 10000;
            ada.NameArranger = "000000";
            ada.NumberArranger = "000000";
            ada.PasscodeArranger = "000000";
            db.Arranger_table.Add(ada);

            db.SaveChanges();
        }

        public void TestData3()
        {
            LiveDorm_table li = new LiveDorm_table();
            li.IDStudent = 2000001;
            li.IDDorm = 10000002;
            li.OtherLiveDorm = "";
            db.LiveDorm_table.Add(li);

            NewCourse_table asda = new NewCourse_table();
            asda.IDTeacher = 300001;
            asda.IDSchoolhour = 3;
            asda.IDCourse = 500002;
            asda.IDClassroom = 60002;
            asda.SetTimeNewCourse = DateTime.Now;
            asda.BeginTimeNewCourse = DateTime.Now;
            asda.NatureNewCourse = 1;
            db.NewCourse_table.Add(asda);


            db.SaveChanges();
        }

        public void TestData4()
        {
            StudyCourse_table asdsd = new StudyCourse_table();
            asdsd.IDStudent = 2000001;
            asdsd.IDNewCourse = 8000000;
            asdsd.GradeStudyCourse = -1;

            db.StudyCourse_table.Add(asdsd); ;
            db.SaveChanges();
        }
    }
    public class s
    {
        DBWebCCEntities db;
        /// <summary>
        /// 单个对象添加
        /// </summary>
        public  String Add(Object obj)
        {
            try
            {
                db.Authority_table.Add(obj as Authority_table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// 多个对象添加
        /// </summary>
        /// <param name="teas"></param>
        public String AddAll(List<Authority_table> teas)
        {

            try
            {
                foreach (Authority_table stu in teas)
                    db.Authority_table.Add(stu);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// 单个数据删除 通过编号
        /// </summary>
        /// <param name="obj"></param>
        public String Delete(Object obj)
        {

            try
            {
                int str = (int)obj;
                var user = (from e in db.Authority_table
                            where e.IDAuthority == str
                            select e).FirstOrDefault();
                db.Authority_table.Remove(user);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// 形参为Authority_table 对象 根据编号修改对象信息
        /// </summary>
        /// <param name="obj"></param>
        public String Modify(Object obj)
        {

            try
            {
                Authority_table stu = obj as Authority_table;
                var user = (from e in db.Authority_table
                            where e.IDAuthority == stu.IDAuthority
                            select e).FirstOrDefault();
                user = stu;
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// 通过ID的单个数据查询  int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  Object Select(Object obj)
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
        /// <summary>
        /// 查询所有权限信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object SelectAll()
        {
            try
            {
                var user = from e in db.Authority_table
                           select e;
                if (user.FirstOrDefault() == null)
                    return new List<Authority_table>();
                return user.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}