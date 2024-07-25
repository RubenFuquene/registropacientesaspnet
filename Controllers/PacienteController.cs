using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pacientes.Data;
using pacientes.Models;
using System.Threading.Tasks;

namespace pacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteContext _context;

        public PacienteController(PacienteContext context)
        {
            _context = context;
        }

        /*
         * Método que lista y devuelve todos los pacientes registrados
         * 
         * api/paciente
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var tasks = await _context.Pacientes.ToListAsync();
            return Ok(tasks);
        }

        /*
         * Método que devuelve un paciente buscado por su identificador
         * api/paciente/5
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        /*
         * Método que registra un paciente
         * api/paciente
         */
        [HttpPost]
        public async Task<ActionResult<Paciente>> AddPaciente(Paciente nuevoPaciente)
        {
            _context.Pacientes.Add(nuevoPaciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaciente), new { id = nuevoPaciente.Id }, nuevoPaciente);
        }

        /*
         * Método que actualiza un paciente
         * api/paciente
         */
        [HttpPut]
        public async Task<ActionResult> UpdatePaciente(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PacienteExist(paciente.Id)) {
                    return NotFound();
                } else { throw; }
            }

            return NoContent();
        }

        /*
         * Método que elimina un paciente del registtro en BD
         * api/paciente/5
         */
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if(paciente == null)
            {
                return NotFound();
            }

            _context.Entry(paciente).State = EntityState.Deleted;
            _context.SaveChanges();

            return NoContent();
        }

        //Función auxiliar para evaluar si un identificador ya está asignado a algun Paciente
        private bool PacienteExist(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
