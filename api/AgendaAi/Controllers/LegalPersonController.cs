using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaAi.Models;
using AgendaAi.DB;

namespace AgendaAi.Controllers
{
    [Route("persons/[controller]")]
    [ApiController]
    public class LegalPersonController : ControllerBase
    {
        private readonly AgendaDB _context;

        public LegalPersonController(AgendaDB context)
        {
            _context = context;
        }

        // GET: persons/legal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalPersonDTO>>> GetLegalPersons() =>
            await _context.LegalPersons.Select(legalPerson => LegalPersonToDTO(legalPerson)).ToListAsync();

        // Get: persons/legal/1
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalPersonDTO>> GetLegalPerson(int id)
        {
            var legalPerson = await _context.LegalPersons.FindAsync(id);

            if (legalPerson == null) NotFound();

            return LegalPersonToDTO(legalPerson);
        }
        // </snippet_GetByID>

        // POST: persons/legal
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<LegalPersonDTO>> PostLegalPerson(LegalPersonDTO input)
        {
            LegalPerson newLegalPerson = DTOToLegalPerson(input);

            await _context.LegalPersons.AddAsync(newLegalPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLegalPerson),
                new { id = newLegalPerson.Id },
                LegalPersonToDTO(newLegalPerson));
        }
        // </snippet_Create>

        // PUT: persons/legal/1
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalPerson(int id, LegalPerson legalPerson)
        {
            _context.Entry(legalPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalPersonExists(id))
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
        // </snippet_Update>

        //DELETE: persons/legal/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegalPerson(int id)
        {
            var legalPerson = await _context.LegalPersons.FindAsync(id);
            if (legalPerson == null) NotFound();

            _context.LegalPersons.Remove(legalPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LegalPersonExists(int id) => _context.LegalPersons.Any(lp => lp.Id == id);
        private static LegalPersonDTO LegalPersonToDTO(LegalPerson input) =>
            new LegalPersonDTO
            {
                Name = input.Name,
                Email = input.Email,
                Password = input.Password,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                Cnpj = input.Cnpj,
                SocialName = input.SocialName,
            };
        private static LegalPerson DTOToLegalPerson(LegalPersonDTO legalPersonDTo) =>
            new LegalPerson
            {
                Name = legalPersonDTo.Name,
                Email = legalPersonDTo.Email,
                Password = legalPersonDTo.Password,
                PhoneNumber = legalPersonDTo.PhoneNumber,
                Address = legalPersonDTo.Address,
                Cnpj = legalPersonDTo.Cnpj,
                SocialName = legalPersonDTo.SocialName,
            };
    }
}
