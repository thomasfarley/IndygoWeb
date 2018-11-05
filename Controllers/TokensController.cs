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
    public class TokensController : ApiController
    {
        private IndygoContext db = new IndygoContext();

        // GET: api/Tokens
        public IQueryable<Token> GetTokens()
        {
            return db.Tokens;
        }

        // GET: api/Tokens/5
        [ResponseType(typeof(Token))]
        public async Task<IHttpActionResult> GetToken(string id)
        {
            Token token = await db.Tokens.FindAsync(id);

            return Ok(token);
        }

        // PUT: api/Tokens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutToken(string id, Token token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != token.TokenId)
            {
                return BadRequest();
            }

            db.Entry(token).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TokenExists(id))
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

        // POST: api/Tokens
        [ResponseType(typeof(Token))]
        public async Task<IHttpActionResult> PostToken(Token token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tokens.Add(token);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TokenExists(token.TokenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = token.TokenId }, token);
        }

        // DELETE: api/Tokens/5
        [ResponseType(typeof(Token))]
        public async Task<IHttpActionResult> DeleteToken(string id)
        {
            Token token = await db.Tokens.FindAsync(id);
            if (token == null)
            {
                return NotFound();
            }

            db.Tokens.Remove(token);
            await db.SaveChangesAsync();

            return Ok(token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TokenExists(string id)
        {
            return db.Tokens.Count(e => e.TokenId == id) > 0;
        }
    }
}