using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaAi.Models;
using AgendaAi.DB;

namespace AgendaAi.Controllers
{
    [Route("persons/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly AgendaDB _context;

        public SuperAdminController(AgendaDB context)
        {
            _context = context;
        }

        // GET: persons/superAdmin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperAdminDTO>>> GetSuperAdmins() =>
            await _context.SuperAdmins.Select(superAdminPerson => SuperAdminToDTO(superAdminPerson)).ToListAsync();

        // Get: persons/superAdmin/1
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperAdminDTO>> GetSuperAdmin(int id)
        {
            var superAdmin = await _context.SuperAdmins.FindAsync(id);

            if (superAdmin == null) NotFound();

            return SuperAdminToDTO(superAdmin);
        }
        // </snippet_GetByID>

        // POST: persons/superAdmin
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<SuperAdminDTO>> PostSuperAdmin(SuperAdminDTO input)
        {
            SuperAdmin newSuperAdmin = DTOToSuperAdmin(input);

            await _context.SuperAdmins.AddAsync(newSuperAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSuperAdmin),
                new { id = newSuperAdmin.Id },
                SuperAdminToDTO(newSuperAdmin));
        }
        // </snippet_Create>

        // PUT: persons/superAdmin/1
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperAdmin(int id, SuperAdminDTO superAdminDTO)
        {
            var superAdmin = await _context.SuperAdmins.FindAsync(id);
            if (superAdmin == null) NotFound();

            superAdmin = DTOToSuperAdmin(superAdminDTO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SuperAdminExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        // </snippet_Update>

        //DELETE: persons/superAdmin/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperAdmin(int id)
        {
            var superAdmin = await _context.SuperAdmins.FindAsync(id);
            if (superAdmin == null) NotFound();

            _context.SuperAdmins.Remove(superAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperAdminExists(int id) => _context.SuperAdmins.Any(lp => lp.Id == id);
        private static SuperAdminDTO SuperAdminToDTO(SuperAdmin input) =>
            new SuperAdminDTO
            {
                Email = input.Email,
                Password = input.Password,
            };
        private static SuperAdmin DTOToSuperAdmin(SuperAdminDTO SuperAdminDTO) =>
            new SuperAdmin
            {
                Email = SuperAdminDTO.Email,
                Password = SuperAdminDTO.Password,
            };
     }
}
