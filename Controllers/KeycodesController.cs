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
    public class KeycodesController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/Keycodes
        public IQueryable<Keycode> GetKeycodes()
        {
            return db.Keycodes;
        }

        // GET: api/Keycodes/5
        [ResponseType(typeof(Keycode))]
        public async Task<IHttpActionResult> GetKeycode(string id)
        {
            Keycode keycode = await db.Keycodes.FindAsync(id);
            if (keycode == null)
            {
                return NotFound();
            }

            return Ok(keycode);
        }

        // PUT: api/Keycodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeycode(string id, Keycode keycode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keycode.KeycodeId)
            {
                return BadRequest();
            }

            db.Entry(keycode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeycodeExists(id))
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

        // POST: api/Keycodes
        [ResponseType(typeof(Keycode))]
        public async Task<IHttpActionResult> PostKeycode(Keycode keycode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keycodes.Add(keycode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KeycodeExists(keycode.KeycodeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = keycode.KeycodeId }, keycode);
        }

        // DELETE: api/Keycodes/5
        [ResponseType(typeof(Keycode))]
        public async Task<IHttpActionResult> DeleteKeycode(string id)
        {
            Keycode keycode = await db.Keycodes.FindAsync(id);
            if (keycode == null)
            {
                return NotFound();
            }

            db.Keycodes.Remove(keycode);
            await db.SaveChangesAsync();

            return Ok(keycode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeycodeExists(string id)
        {
            return db.Keycodes.Count(e => e.KeycodeId == id) > 0;
        }
    }
}