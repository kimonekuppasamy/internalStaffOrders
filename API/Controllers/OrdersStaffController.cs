using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalStaffOrdersApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternalStaffOrdersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersStaffController : ControllerBase
    {
        private readonly OrdersDBContext _context;

        public OrdersStaffController(OrdersDBContext context)
        {
            _context = context;
        }

        // GET: api/OrdersStaff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersStaff>>> GetOrdersStaff()
        {
            return await _context.OrdersStaffs.ToListAsync();
        }

        // GET: api/OrdersStaff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersStaff>> GetOrdersStaffs(int id)
        {
            var OrdersStaff = await _context.OrdersStaffs.FindAsync(id);

            if (OrdersStaff == null)
            {
                return NotFound();
            }

            return OrdersStaff;
        }

        // PUT: api/OrdersStaff/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersStaff(int id, OrdersStaff OrdersStaff)
        {
            OrdersStaff.StaffID = id;

            _context.Entry(OrdersStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrdersStaff
        [HttpPost]
        public async Task<ActionResult<OrdersStaff>> PostOrdersStaff(OrdersStaff OrdersStaff)
        {
            _context.OrdersStaffs.Add(OrdersStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersStaff", new { id = OrdersStaff.StaffID }, OrdersStaff);
        }

        // DELETE: api/OrdersStaff/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersStaff>> DeleteOrdersStaff(int id)
        {
            var OrdersStaff = await _context.OrdersStaffs.FindAsync(id);
            if (OrdersStaff == null)
            {
                return NotFound();
            }

            _context.OrdersStaffs.Remove(OrdersStaff);
            await _context.SaveChangesAsync();

            return OrdersStaff;
        }

        private bool OrdersStaffExists(int id)
        {
            return _context.OrdersStaffs.Any(e => e.StaffID == id);
        }


    }
}
//Kimone Kuppasamy August 2021
//Controller for staff CRUD operations
