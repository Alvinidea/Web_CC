//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebCC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course_table
    {
        public Course_table()
        {
            this.NewCourse_table = new HashSet<NewCourse_table>();
        }
    
        public int IDCourse { get; set; }
        public string NumberCourse { get; set; }
        public string NameCourse { get; set; }
        public string ProfileCourse { get; set; }
        public Nullable<int> ScoreCourse { get; set; }
        public Nullable<int> StudyTimeCourse { get; set; }
    
        public virtual ICollection<NewCourse_table> NewCourse_table { get; set; }
    }
}
