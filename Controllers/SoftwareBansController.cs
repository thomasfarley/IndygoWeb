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
    public class SoftwareBansController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/SoftwareBans
        public IQueryable<SoftwareBan> GetSoftwareBans()
        {
            return db.SoftwareBans;
        }

        // GET: api/SoftwareBans/5
        [ResponseType(typeof(SoftwareBan))]
        public async Task<IHttpActionResult> GetSoftwareBan(string id)
        {
            SoftwareBan softwareBan = await db.SoftwareBans.FindAsync(id);
            if (softwareBan == null)
            {
                return NotFound();
            }

            return Ok(softwareBan);
        }

        // PUT: api/SoftwareBans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSoftwareBan(string id, SoftwareBan softwareBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != softwareBan.TokenId)
            {
                return BadRequest();
            }

            db.Entry(softwareBan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareBanExists(id))
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

        // POST: api/SoftwareBans
        [ResponseType(typeof(SoftwareBan))]
        public async Task<IHttpActionResult> PostSoftwareBan(SoftwareBan softwareBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SoftwareBans.Add(softwareBan);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SoftwareBanExists(softwareBan.TokenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = softwareBan.TokenId }, softwareBan);
        }

        // DELETE: api/SoftwareBans/5
        [ResponseType(typeof(SoftwareBan))]
        public async Task<IHttpActionResult> DeleteSoftwareBan(string id)
        {
            SoftwareBan softwareBan = await db.SoftwareBans.FindAsync(id);
            if (softwareBan == null)
            {
                return NotFound();
            }

            db.SoftwareBans.Remove(softwareBan);
            await db.SaveChangesAsync();

            return Ok(softwareBan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoftwareBanExists(string id)
        {
            return db.SoftwareBans.Count(e => e.TokenId == id) > 0;
        }
    }
}