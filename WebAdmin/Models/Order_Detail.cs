namespace WebAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order Detail")]
    public partial class Order_Detail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? Order_id { get; set; }

        public int? Product_id { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
      

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
