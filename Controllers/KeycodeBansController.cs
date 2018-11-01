using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IndygoWeb.Models;

namespace IndygoWeb.Controllers
{
    public class KeycodeBansController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/KeycodeBans
        public IQueryable<KeycodeBan> GetKeycodeBans()
        {
            return db.KeycodeBans;
        }

        // GET: api/KeycodeBans/5
        [ResponseType(typeof(KeycodeBan))]
        public async Task<IHttpActionResult> GetKeycodeBan(string id)
        {
            KeycodeBan keycodeBan = await db.KeycodeBans.FindAsync(id);
            if (keycodeBan == null)
            {
                return NotFound();
            }

            return Ok(keycodeBan);
        }

        // PUT: api/KeycodeBans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeycodeBan(string id, KeycodeBan keycodeBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keycodeBan.KeycodeId)
            {
                return BadRequest();
            }

            db.Entry(keycodeBan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeycodeBanExists(id))
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

        // POST: api/KeycodeBans
        [ResponseType(typeof(KeycodeBan))]
        public async Task<IHttpActionResult> PostKeycodeBan(KeycodeBan keycodeBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KeycodeBans.Add(keycodeBan);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KeycodeBanExists(keycodeBan.KeycodeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = keycodeBan.KeycodeId }, keycodeBan);
        }

        // DELETE: api/KeycodeBans/5
        [ResponseType(typeof(KeycodeBan))]
        public async Task<IHttpActionResult> DeleteKeycodeBan(string id)
        {
            KeycodeBan keycodeBan = await db.KeycodeBans.FindAsync(id);
            if (keycodeBan == null)
            {
                return NotFound();
            }

            db.KeycodeBans.Remove(keycodeBan);
            await db.SaveChangesAsync();

            return Ok(keycodeBan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeycodeBanExists(string id)
        {
            return db.KeycodeBans.Count(e => e.KeycodeId == id) > 0;
        }
    }
}