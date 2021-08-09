using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalStaffOrdersApp.Models
{
    public class OrdersStaff
    {
        [Key]
        public int StaffID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StaffFName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StaffLName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StaffAddressType { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StaffStreetAddress { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string StaffSuburb { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StaffCity { get; set; }

        public int StaffPostalCode { get; set; }
    }
}
//Kimone Kuppasamy August 2021
//Model for staff field declaration
