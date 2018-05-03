using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StockManagementWS;

namespace StockManagementWS.Controllers
{
    public class ProductReturnsController : ApiController
    {
        private StockManagementContext db = new StockManagementContext();

        // GET: api/ProductReturns
        public IQueryable<ProductReturn> GetProductReturn()
        {
            return db.ProductReturn;
        }

        // GET: api/ProductReturns/5
        [ResponseType(typeof(ProductReturn))]
        public IHttpActionResult GetProductReturn(int id)
        {
            ProductReturn productReturn = db.ProductReturn.Find(id);
            if (productReturn == null)
            {
                return NotFound();
            }

            return Ok(productReturn);
        }

        // PUT: api/ProductReturns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductReturn(int id, ProductReturn productReturn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productReturn.Id)
            {
                return BadRequest();
            }

            db.Entry(productReturn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductReturnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductReturns
        [ResponseType(typeof(ProductReturn))]
        public IHttpActionResult PostProductReturn(ProductReturn productReturn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductReturn.Add(productReturn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productReturn.Id }, productReturn);
        }

        // DELETE: api/ProductReturns/5
        [ResponseType(typeof(ProductReturn))]
        public IHttpActionResult DeleteProductReturn(int id)
        {
            ProductReturn productReturn = db.ProductReturn.Find(id);
            if (productReturn == null)
            {
                return NotFound();
            }

            db.ProductReturn.Remove(productReturn);
            db.SaveChanges();

            return Ok(productReturn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductReturnExists(int id)
        {
            return db.ProductReturn.Count(e => e.Id == id) > 0;
        }
    }
}