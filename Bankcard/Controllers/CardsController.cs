using Bankcard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bankcard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly BankContext _context;

        public CardsController(BankContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        /*
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }
        */
        
        public ActionResult<IQueryable> GetCards()
        {
            
            //with Linque
            //var cr = from card in _context.Cards
                     //join ca in _context.CardTypes on card.CardTypeId equals ca.CardTypeId
                     //select new
                     //{  card.CardId,
                        //card.CardTypeId,
                        //card.CardImage,
                        //ca.CardTypeName
                     //};
            
            var cr = _context.Cards.Join
                (
                    _context.CardTypes,
                    x => x.CardTypeId,
                    y => y.CardTypeId,
                    (x, y) => new
                    {
                        x.CardId,
                        x.CardImage,
                        x.CardBussinessCategory,
                        x.CardNumber,
                        x.CardType,
                        x.CardExpirationDate,
                        x.CardTypeId,
                        y.CardTypeName,
                        CardCount = _context.Cards.Count()
                    }
                ).ToList();
            return Ok(cr);
        }
    
        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCards(int id)
        {
            var cards = await _context.Cards.FindAsync(id);

            if (cards == null)
            {
                return NotFound();
            }

            return cards;
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCards(int id, Card cards)
        {
            if (id != cards.CardId)
            {
                return BadRequest();
            }

            _context.Entry(cards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardsExists(id))
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

        // POST: api/Cards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Card>> PostCards(Card cards)
        {
            _context.Cards.Add(cards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCards", new { id = cards.CardId }, cards);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteCards(int id)
        {
            var cards = await _context.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(cards);
            await _context.SaveChangesAsync();

            return cards;
        }

        private bool CardsExists(int id)
        {
            return _context.Cards.Any(e => e.CardId == id);
        }
    }
}
