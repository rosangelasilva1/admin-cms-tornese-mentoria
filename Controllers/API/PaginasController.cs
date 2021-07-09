using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Infraestrutura.Database;

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
        [Route("/api/paginas.json")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200,await _context.Paginas.ToListAsync());
        }

    }
}
