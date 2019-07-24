using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IkeyPro_WebAPI_V22_2.Context;
using IkeyPro_WebAPI_V22_2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IkeyPro_WebAPI_V22_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IkeyProContext ikeyProContext;

        public ValuesController(IkeyProContext pc)
        {
            ikeyProContext = pc;
            //if (ikeyProContext.Produits.ToList().Count() == 0)
            //{
            //    //ikeyProContext.Produits.Add(new Produit("Sisteme Operative", 10, 125.25));
            //    //ikeyProContext.Produits.Add(new Produit("Antivirus", 5, 50.25));
            //    //ikeyProContext.Produits.Add(new Produit("Office", 3, 25.25));
            //    //ikeyProContext.SaveChanges();
            //}
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetListProduits()
        {
            return await ikeyProContext.Produits.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetTodoItem(long id)
        {
            var todoItem = await ikeyProContext.Produits.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Produit>> PostTodoItem(Produit item)
        {
            ikeyProContext.Produits.Add(item);
            await ikeyProContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetListProduits), new { id = item.Id }, item);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await ikeyProContext.Produits.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            ikeyProContext.Produits.Remove(todoItem);
            await ikeyProContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Produit item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            ikeyProContext.Entry(item).State = EntityState.Modified;
            await ikeyProContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
