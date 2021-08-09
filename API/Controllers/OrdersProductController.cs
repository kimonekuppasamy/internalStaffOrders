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
    public class OrdersProductController : ControllerBase
    {
        private readonly OrdersDBContext _context;

        public OrdersProductController(OrdersDBContext context)
        {
            _context = context;
        }

        // GET: api/OrdersProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersProduct>>> GetOrdersProducts()
        {
            return await _context.OrdersProducts.ToListAsync();
        }

        // GET: api/OrdersProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersProduct>> GetOrdersProduct(int id)
        {
            var OrdersProduct = await _context.OrdersProducts.FindAsync(id);

            if (OrdersProduct == null)
            {
                return NotFound();
            }

            return OrdersProduct;
        }

        // PUT: api/OrdersProduct/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersProduct(int id, OrdersProduct OrdersProduct)
        {
            OrdersProduct.ProductID = id;

            _context.Entry(OrdersProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersProductExists(id))
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

        // POST: api/OrdersProduct
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrdersProduct>> PostOrdersProduct(OrdersProduct OrdersProduct)
        {
            _context.OrdersProducts.Add(OrdersProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersProduct", new { id = OrdersProduct.ProductID }, OrdersProduct);
        }

        // DELETE: api/OrdersProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersProduct>> DeleteOrdersProduct(int id)
        {
            var OrdersProduct = await _context.OrdersProducts.FindAsync(id);
            if (OrdersProduct == null)
            {
                return NotFound();
            }

            _context.OrdersProducts.Remove(OrdersProduct);
            await _context.SaveChangesAsync();

            return OrdersProduct;
        }

        private bool OrdersProductExists(int id)
        {
            return _context.OrdersProducts.Any(e => e.ProductID == id);
        }
    }
}
//Kimone Kuppasamy August 2021
//Controller for products CRUD operations