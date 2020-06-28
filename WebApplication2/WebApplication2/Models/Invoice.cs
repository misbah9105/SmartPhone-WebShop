namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        public int IDInvoice { get; set; }

        public int? IDUser { get; set; }

        [StringLength(50)]
        public string DeliveryAdd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Total { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        public virtual User User { get; set; }
    }
}
