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
    
    public partial class Exam_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam_Details()
        {
            this.Exam_Result = new HashSet<Exam_Result>();
        }
    
        public int Exam_Id { get; set; }
        public System.DateTime Exam_Date { get; set; }
        public System.TimeSpan Exam_Time { get; set; }
        public string Course { get; set; }
        public Nullable<int> Student { get; set; }
    
        public virtual Course_Details Course_Details { get; set; }
        public virtual Student_Details Student_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_Result> Exam_Result { get; set; }
    }
}
