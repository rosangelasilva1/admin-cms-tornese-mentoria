using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Infraestrutura.Database;
using admin_cms.Models.Dominio.Entidades;

namespace admin_cms.Controllers.API
{
    public class PaginasController : ControllerBase
    {
        private readonly ContextoCms _context;

        public PaginasController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Paginas
        [HttpGet]
        [Route("/api/paginas.json")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200,await _context.Paginas.ToListAsync());
        }

        [HttpPost]
        [Route("/api/paginas.json")]
        public async Task<IActionResult> Create([FromBody] Pagina pagina)
        {
            _context.Add(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }        

        [HttpPut]
        [Route("/api/paginas/{id}.json")]
        public async Task<IActionResult> Update(int id,[FromBody] Pagina pagina)
        {
            pagina.Id = id;
            _context.Update(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }        

    }
}
