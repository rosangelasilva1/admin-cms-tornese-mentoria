
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Infraestrutura.Database;


namespace admin_cms.Controllers.API
{

    public class ApiAdministradoresController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiAdministradoresController(ContextoCms context)
        {
            _context = context;
        }
        
        
        // GET: Administradores
        [Route("/api/administradores.json")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200,await _context.Administradores.ToListAsync());
        }

    }
}
