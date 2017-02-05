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
    
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            this.PhotoItems = new HashSet<PhotoItem>();
            this.WorkerReviews = new HashSet<WorkerReview>();
        }
    
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Worker_Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Rating { get; set; }
    
        public virtual Recipe Recipe { get; set; }
        public virtual Worker Worker { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoItem> PhotoItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerReview> WorkerReviews { get; set; }
    }
}
