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
    public class UserCompaniesController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/UserCompanies
        public IQueryable<UserCompany> GetUserCompanies()
        {
            return db.UserCompanies;
        }

        // GET: api/UserCompanies/5
        [ResponseType(typeof(UserCompany))]
        public async Task<IHttpActionResult> GetUserCompany(int id)
        {
            UserCompany userCompany = await db.UserCompanies.FindAsync(id);
            if (userCompany == null)
            {
                return NotFound();
            }

            return Ok(userCompany);
        }

        // PUT: api/UserCompanies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserCompany(int id, UserCompany userCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userCompany.CompanyId)
            {
                return BadRequest();
            }

            db.Entry(userCompany).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCompanyExists(id))
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

        // POST: api/UserCompanies
        [ResponseType(typeof(UserCompany))]
        public async Task<IHttpActionResult> PostUserCompany(UserCompany userCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserCompanies.Add(userCompany);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCompanyExists(userCompany.CompanyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userCompany.CompanyId }, userCompany);
        }

        // DELETE: api/UserCompanies/5
        [ResponseType(typeof(UserCompany))]
        public async Task<IHttpActionResult> DeleteUserCompany(int id)
        {
            UserCompany userCompany = await db.UserCompanies.FindAsync(id);
            if (userCompany == null)
            {
                return NotFound();
            }

            db.UserCompanies.Remove(userCompany);
            await db.SaveChangesAsync();

            return Ok(userCompany);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserCompanyExists(int id)
        {
            return db.UserCompanies.Count(e => e.CompanyId == id) > 0;
        }
    }
}