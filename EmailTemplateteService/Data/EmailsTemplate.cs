//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmailTemplateteService.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmailsTemplate
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Nullable<short> brabch_num { get; set; }
        public Nullable<int> mis_campaign { get; set; }
    
        public virtual branch branch { get; set; }
    }
}