//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutogearWeb.EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Suburb
    {
        public Suburb()
        {
            this.PostCodes = new HashSet<PostCode>();
        }
    
        public int SuburbId { get; set; }
        public string Suburb_Name { get; set; }
        public int StateId { get; set; }
    
        public virtual ICollection<PostCode> PostCodes { get; set; }
        public virtual State State { get; set; }
    }
}
