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
    public class KeyRegistrationsController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/KeyRegistrations
        public IQueryable<KeyRegistration> GetKeyRegistrations()
        {
            return db.KeyRegistrations;
        }

        // GET: api/KeyRegistrations/5
        [ResponseType(typeof(KeyRegistration))]
        public async Task<IHttpActionResult> GetKeyRegistration(string id)
        {
            KeyRegistration keyRegistration = await db.KeyRegistrations.FindAsync(id);
            if (keyRegistration == null)
            {
                return NotFound();
            }

            return Ok(keyRegistration);
        }

        // PUT: api/KeyRegistrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeyRegistration(string id, KeyRegistration keyRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyRegistration.KeycodeId)
            {
                return BadRequest();
            }

            db.Entry(keyRegistration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyRegistrationExists(id))
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

        // POST: api/KeyRegistrations
        [ResponseType(typeof(KeyRegistration))]
        public async Task<IHttpActionResult> PostKeyRegistration(KeyRegistration keyRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KeyRegistrations.Add(keyRegistration);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KeyRegistrationExists(keyRegistration.KeycodeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = keyRegistration.KeycodeId }, keyRegistration);
        }

        // DELETE: api/KeyRegistrations/5
        [ResponseType(typeof(KeyRegistration))]
        public async Task<IHttpActionResult> DeleteKeyRegistration(string id)
        {
            KeyRegistration keyRegistration = await db.KeyRegistrations.FindAsync(id);
            if (keyRegistration == null)
            {
                return NotFound();
            }

            db.KeyRegistrations.Remove(keyRegistration);
            await db.SaveChangesAsync();

            return Ok(keyRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyRegistrationExists(string id)
        {
            return db.KeyRegistrations.Count(e => e.KeycodeId == id) > 0;
        }
    }
}