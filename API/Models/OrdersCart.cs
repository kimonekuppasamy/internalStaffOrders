using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalStaffOrdersApp.Models
{
    public class OrdersCart
    {
        [Key]
        public int OrderID { get; set; }

        public int OrderNumber { get; set; }

        public int StaffID { get; set; }

        public int ProductID { get; set; }

        public int OrderQuantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string OrderStatus { get; set; }

    }
}
//Kimone Kuppasamy August 2021
//Model for cart field declaration
