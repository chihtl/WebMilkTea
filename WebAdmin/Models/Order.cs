namespace WebAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        public int ID { get; set; }

        public DateTime? Date { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total_amount { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone_number { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Fullname { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
