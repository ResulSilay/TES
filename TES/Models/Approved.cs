//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TES.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Approved
    {
        public int Id { get; set; }
        public Nullable<int> TenderId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> FileId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Type { get; set; }
    }
}