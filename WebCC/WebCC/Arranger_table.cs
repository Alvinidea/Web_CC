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
    
    public partial class Arranger_table
    {
        public int IDArranger { get; set; }
        public Nullable<int> IDAuthority { get; set; }
        public string NumberArranger { get; set; }
        public string NameArranger { get; set; }
        public string EmailArranger { get; set; }
        public Nullable<int> AgeArranger { get; set; }
        public string SexArranger { get; set; }
        public string PhoneNumArranger { get; set; }
        public string PasscodeArranger { get; set; }
        public string ImageArranger { get; set; }
    
        public virtual Authority_table Authority_table { get; set; }
    }
}
