using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaAi.Models;
using AgendaAi.DB;

namespace AgendaAi.Controllers
{
    [Route("persons/[controller]")]
    [ApiController]
    public class NaturalPersonController : ControllerBase
    {
        private readonly AgendaDB _context;

        public NaturalPersonController(AgendaDB context)
        {
            _context = context;
        }

        // GET: persons/natural
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaturalPersonDTO>>> GetNaturalPersons() =>
            await _context.NaturalPersons.Select(naturalPerson => NaturalPersonToDTO(naturalPerson)).ToListAsync();

        // Get: persons/natural/1
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<NaturalPersonDTO>> GetNaturalPerson(int id)
        {
            var naturalPerson = await _context.NaturalPersons.FindAsync(id);

            if (naturalPerson == null) NotFound();

            return NaturalPersonToDTO(naturalPerson);
        }
        // </snippet_GetByID>

        // POST: persons/natural
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<NaturalPersonDTO>> PostNaturalPerson(NaturalPersonDTO input)
        {
            NaturalPerson newNaturalPerson = DTOToNaturalPerson(input);

            await _context.NaturalPersons.AddAsync(newNaturalPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNaturalPerson),
                new { id = newNaturalPerson.Id },
                NaturalPersonToDTO(newNaturalPerson));
        }
        // </snippet_Create>

        // PUT: persons/natural/1
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaturalPerson(int id, NaturalPersonDTO naturalPersonDTO)
        {
            if (id != naturalPersonDTO.Id) BadRequest();

            var naturalPerson = await _context.NaturalPersons.FindAsync(id);
            if (naturalPerson == null) NotFound();

            naturalPerson = DTOToNaturalPerson(naturalPersonDTO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!NaturalPersonExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        // </snippet_Update>

        //DELETE: persons/natural/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaturalPerson(int id)
        {
            var naturalPerson = await _context.NaturalPersons.FindAsync(id);
            if (naturalPerson == null) NotFound();

            _context.NaturalPersons.Remove(naturalPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaturalPersonExists(int id) => _context.NaturalPersons.Any(lp => lp.Id == id);
        private static NaturalPersonDTO NaturalPersonToDTO(NaturalPerson input) =>
            new NaturalPersonDTO
            {
                Id = input.Id,
                Name = input.Name,
                Email = input.Email,
                Password = input.Password,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                Cpf = input.Cpf,
                BirthDate = input.BirthDate,
            };
        private static NaturalPerson DTOToNaturalPerson(NaturalPersonDTO naturalPersonDTo) =>
            new NaturalPerson
            {
                Id = naturalPersonDTo.Id,
                Name = naturalPersonDTo.Name,
                Email = naturalPersonDTo.Email,
                Password = naturalPersonDTo.Password,
                PhoneNumber = naturalPersonDTo.PhoneNumber,
                Address = naturalPersonDTo.Address,
                Cpf = naturalPersonDTo.Cpf,
                BirthDate = naturalPersonDTo.BirthDate,
            };
    }
}
