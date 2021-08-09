using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalStaffOrdersApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersCartController : ControllerBase
    {
        private readonly OrdersDBContext _context;

        public OrdersCartController(OrdersDBContext context)
        {
            _context = context;
        }

        // GET: api/OrdersCart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersCart>>> GetOrdersCarts()
        {
            return await _context.OrdersCarts.ToListAsync();
        }

        // GET: api/OrdersCart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersCart>> GetOrdersCart(int id)
        {
            var OrdersCart = await _context.OrdersCarts.FindAsync(id);

            if (OrdersCart == null)
            {
                return NotFound();
            }

            return OrdersCart;
        }

        // PUT: api/OrdersCart/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersCart(int id, OrdersCart OrdersCart)
        {
            OrdersCart.OrderID = id;

            _context.Entry(OrdersCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersCartExists(id))
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

        // POST: api/OrdersCart
        [HttpPost]
        public async Task<ActionResult<OrdersCart>> PostOrdersCart(OrdersCart OrdersCart)
        {
            _context.OrdersCarts.Add(OrdersCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersCart", new { id = OrdersCart.OrderID }, OrdersCart);
        }

        // DELETE: api/OrdersCart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersCart>> DeleteOrdersCart(int id)
        {
            var OrdersCart = await _context.OrdersCarts.FindAsync(id);
            if (OrdersCart == null)
            {
                return NotFound();
            }

            _context.OrdersCarts.Remove(OrdersCart);
            await _context.SaveChangesAsync();

            return OrdersCart;
        }

        private bool OrdersCartExists(int id)
        {
            return _context.OrdersCarts.Any(e => e.OrderID == id);
        }

    }
}
//Kimone Kuppasamy August 2021
//Controller for cart CRUD operations