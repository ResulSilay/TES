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
    
    public partial class Approved_View
    {
        public int Id { get; set; }
        public Nullable<int> TenderId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> FileId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Type { get; set; }
        public int t_Id { get; set; }
        public string Title { get; set; }
        public string t_Description { get; set; }
        public string Context { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<float> Money { get; set; }
        public Nullable<int> t_Status { get; set; }
        public Nullable<int> t_Type { get; set; }
        public string Name { get; set; }
    }
}
