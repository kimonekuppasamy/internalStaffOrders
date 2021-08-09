using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalStaffOrdersApp.Models;

namespace InternalStaffOrdersApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(OrdersDBContext _context)
        {
            _context.Database.EnsureCreated();
            // Look for any products.
            if (_context.OrdersProducts.Any())
            {
                return;   // DB has been seeded
            }

            if (_context.OrdersStaffs.Any())
            {
                return;   // DB has been seeded
            }

            var ordersProduct = new OrdersProduct[]
            {
            new OrdersProduct{ProductTitle="Pens",ProductDescription="Pack of 4 assorted",ProductPrice=12,ProductImage="https://images.freeimages.com/images/large-previews/023/pens-1474336.jpg",ProductQuanitity=10},
            new OrdersProduct{ProductTitle="Notepad",ProductDescription="A5 50 pages",ProductPrice=10,ProductImage="https://images.freeimages.com/images/large-previews/d4d/notepad-1-1258066.jpg",ProductQuanitity=12},
            new OrdersProduct{ProductTitle="Chair",ProductDescription="Black Office Chair",ProductPrice=1200,ProductImage="https://images.freeimages.com/images/large-previews/12c/leather-chair-1241015.jpg",ProductQuanitity=5},
            new OrdersProduct{ProductTitle="Company T-Shirt",ProductDescription="Customisable company shirt",ProductPrice=120,ProductImage="https://images.freeimages.com/images/large-previews/36d/t-shirt-1426871.jpg",ProductQuanitity=20},
            new OrdersProduct{ProductTitle="USB Mouse",ProductDescription="Silver wireless mouse",ProductPrice=156,ProductImage="https://images.freeimages.com/images/large-previews/c22/wireless-mouse-1242777.jpg",ProductQuanitity=5},
            new OrdersProduct{ProductTitle="Keyboard",ProductDescription="Silver Keyboard",ProductPrice=220,ProductImage="https://images.freeimages.com/images/large-previews/a2d/stainless-steel-keyboard-1-1550848.jpg",ProductQuanitity=8},
            new OrdersProduct{ProductTitle="Stapler",ProductDescription="Scented sticky note pad",ProductPrice=25,ProductImage="https://images.freeimages.com/images/large-previews/fef/page-markers-1177488.jpg",ProductQuanitity=13},
            new OrdersProduct{ProductTitle="Calendar",ProductDescription="2022 Desk Calendar",ProductPrice=50,ProductImage="https://images.freeimages.com/images/large-previews/815/calendar-1568148.jpg",ProductQuanitity=25},
            new OrdersProduct{ProductTitle="Scissors",ProductDescription="Blue and Black office scissors",ProductPrice=42,ProductImage="https://images.freeimages.com/images/large-previews/011/scissors-1240730.jpg",ProductQuanitity=10}
            };
            foreach (OrdersProduct p in ordersProduct)
            {
                _context.OrdersProducts.Add(p);
            }

            _context.SaveChanges();

            var ordersStaff = new OrdersStaff[]
            {
            new OrdersStaff{ StaffFName = "Cora", StaffLName = "Nash", StaffAddressType = "Residential", StaffStreetAddress = "P.O. Box 341, 1505 Taciti Street", StaffSuburb = "U", StaffCity = "Belfast", StaffPostalCode = 3291 },
            new OrdersStaff{ StaffFName = "Maryam", StaffLName = "Kelly", StaffAddressType = "Residential", StaffStreetAddress = "9947 Duis Rd.", StaffSuburb = "Berlin", StaffCity = "Berlin", StaffPostalCode = 2822 },
            new OrdersStaff{ StaffFName = "Rowan", StaffLName = "Galloway", StaffAddressType = "Residential", StaffStreetAddress = "P.O. Box 908, 4525 Vel Road", StaffSuburb = "Berlin", StaffCity = "Berlin", StaffPostalCode = 3850 },
            new OrdersStaff{ StaffFName = "Marsden", StaffLName = "Lynn", StaffAddressType = "Residential", StaffStreetAddress = "8180 Enim, Street", StaffSuburb = "Pays de la Loire", StaffCity = "Rezé", StaffPostalCode = 3708 },
            new OrdersStaff{ StaffFName = "Amal", StaffLName = "Hughes", StaffAddressType = "Company", StaffStreetAddress = "9162 Semper. Rd.", StaffSuburb = "BC", StaffCity = "Kimberly", StaffPostalCode = 2862 },
            new OrdersStaff{ StaffFName = "Audrey", StaffLName = "Chang", StaffAddressType = "PO BOX", StaffStreetAddress = "Ap #957-3748 Congue Rd.", StaffSuburb = "Connacht", StaffCity = "Galway", StaffPostalCode = 2419 },
            new OrdersStaff{ StaffFName = "TaShya", StaffLName = "Battle", StaffAddressType = "Residential", StaffStreetAddress = "9585 Et, Rd.", StaffSuburb = "Quebec", StaffCity = "Batiscan", StaffPostalCode = 3778 },
            new OrdersStaff{ StaffFName = "Gisela", StaffLName = "Gay", StaffAddressType = "Residential", StaffStreetAddress = "560-9065 Morbi St.", StaffSuburb = "Sverdlovsk Oblast", StaffCity = "Yekaterinburg", StaffPostalCode = 2699 },
            new OrdersStaff{ StaffFName = "Yoko", StaffLName = "Holland", StaffAddressType = "PO BOX", StaffStreetAddress = "Ap #535-358 Id, St.", StaffSuburb = "CH", StaffCity = "Saint-Dizier", StaffPostalCode = 3835 },
            new OrdersStaff{ StaffFName = "Hilda", StaffLName = "Brock", StaffAddressType = "PO BOX", StaffStreetAddress = "559-3491 Amet, St.", StaffSuburb = "ON", StaffCity = "Blind River", StaffPostalCode = 3794 },
            new OrdersStaff{ StaffFName = "Marsden", StaffLName = "Huber", StaffAddressType = "PO BOX", StaffStreetAddress = "285-2893 Vel St.", StaffSuburb = "SI", StaffCity = "Queenstown", StaffPostalCode = 2370 },
            new OrdersStaff{ StaffFName = "Hadassah", StaffLName = "Woods", StaffAddressType = "PO BOX", StaffStreetAddress = "Ap #347-7349 Libero. St.", StaffSuburb = "Kansas", StaffCity = "Wichita", StaffPostalCode = 3901 },
            new OrdersStaff{ StaffFName = "Colt", StaffLName = "Bradford", StaffAddressType = "Residential", StaffStreetAddress = "P.O. Box 768, 2898 Gravida. Street", StaffSuburb = "BO", StaffCity = "Maiduguri", StaffPostalCode = 3642 },
            new OrdersStaff{ StaffFName = "Idola", StaffLName = "Barry", StaffAddressType = "Company", StaffStreetAddress = "914-2722 Scelerisque St.", StaffSuburb = "Emilia-Romagna", StaffCity = "Porretta Terme", StaffPostalCode = 2376 },
            new OrdersStaff{ StaffFName = "Erich", StaffLName = "Wagner", StaffAddressType = "PO BOX", StaffStreetAddress = "6821 Quis, Rd.", StaffSuburb = "MP", StaffCity = "Tarnów", StaffPostalCode = 3196 },
            new OrdersStaff{ StaffFName = "Melanie", StaffLName = "Becker", StaffAddressType = "Residential", StaffStreetAddress = "838 Enim Ave", StaffSuburb = "East Java", StaffCity = "Blitar", StaffPostalCode = 3756 },
            new OrdersStaff{ StaffFName = "Deanna", StaffLName = "Le", StaffAddressType = "PO BOX", StaffStreetAddress = "Ap #483-8550 Aliquet Ave", StaffSuburb = "Sbg", StaffCity = "Bischofshofen", StaffPostalCode = 3666 },
            new OrdersStaff{ StaffFName = "Jackson", StaffLName = "Kennedy", StaffAddressType = "Company", StaffStreetAddress = "P.O. Box 903, 6715 Donec St.", StaffSuburb = "LAZ", StaffCity = "Pastena", StaffPostalCode = 2568 },
            new OrdersStaff{ StaffFName = "Ima", StaffLName = "Ford", StaffAddressType = "PO BOX", StaffStreetAddress = "Ap #515-2221 Mi St.", StaffSuburb = "Jalisco", StaffCity = "Zapopan", StaffPostalCode = 2919 },
            new OrdersStaff{ StaffFName = "Solomon", StaffLName = "Klein", StaffAddressType = "PO BOX", StaffStreetAddress = "3572 Blandit Rd.", StaffSuburb = "SAM", StaffCity = "Tolyatti", StaffPostalCode = 3012 }
            };

            foreach (OrdersStaff s in ordersStaff)
            {
                _context.OrdersStaffs.Add(s);
            }
            _context.SaveChanges();

        }
    }
}

//Kimone Kuppasamy August 2021
//Class to create and populate the database and tables with data
