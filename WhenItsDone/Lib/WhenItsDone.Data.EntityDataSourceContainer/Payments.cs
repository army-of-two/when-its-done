//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhenItsDone.Data.EntityDataSourceContainer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payments
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int WorkerId { get; set; }
        public decimal AmountPaid { get; set; }
        public int ClientId { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Workers Workers { get; set; }
    }
}
