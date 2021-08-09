using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalStaffOrdersApp.Models
{
    public class OrdersProduct
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ProductTitle { get; set; }
        
        [Column(TypeName = "nvarchar(200)")]
        public string ProductDescription { get; set; }

        public double ProductPrice {get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string ProductImage { get; set; }

        public int ProductQuanitity { get; set; }

    }
}
//Kimone Kuppasamy August 2021
//Model for product field declaration
