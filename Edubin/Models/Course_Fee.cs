//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Edubin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course_Fee
    {
        public int id { get; set; }
        public string Course { get; set; }
        public long Fee { get; set; }
    
        public virtual Course_Details Course_Details { get; set; }
    }
}