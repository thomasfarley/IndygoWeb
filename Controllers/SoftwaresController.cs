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
    public class SoftwaresController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/Softwares
        public IQueryable<Software> GetSoftwares()
        {
            return db.Softwares;
        }

        // GET: api/Softwares/5
        [ResponseType(typeof(Software))]
        public async Task<IHttpActionResult> GetSoftware(string id)
        {
            Software software = await db.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            return Ok(software);
        }

        // PUT: api/Softwares/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSoftware(string id, Software software)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != software.TokenId)
            {
                return BadRequest();
            }

            db.Entry(software).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareExists(id))
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

        // POST: api/Softwares
        [ResponseType(typeof(Software))]
        public async Task<IHttpActionResult> PostSoftware(Software software)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Softwares.Add(software);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SoftwareExists(software.TokenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = software.TokenId }, software);
        }

        // DELETE: api/Softwares/5
        [ResponseType(typeof(Software))]
        public async Task<IHttpActionResult> DeleteSoftware(string id)
        {
            Software software = await db.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            db.Softwares.Remove(software);
            await db.SaveChangesAsync();

            return Ok(software);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoftwareExists(string id)
        {
            return db.Softwares.Count(e => e.TokenId == id) > 0;
        }
    }
}