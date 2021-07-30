
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Infraestrutura.Database;
using admin_cms.Models.Dominio.Entidades;
using admin_cms.Models.Dominio.Services;
using System.Linq;
using X.PagedList;



namespace admin_cms.Controllers.API
{

    public class ApiAdministradoresController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiAdministradoresController(ContextoCms context)
        {
            _context = context;
        }
                
        // GET All: Administradores
        [Route("/api/administradores.json")]
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var adms = from adm in( await _context.Administradores.ToPagedListAsync(page,AdministradorService.ITENS_POR_PAGINA))
                select new {
                    Id = adm.Id,
                    Nome = adm.Nome,
                    Telefone = adm.Telefone,
                    Email = adm.Email
                };

            return StatusCode(200,adms);
        }

         // GET ById: Administradores
        [Route("/api/administradores/{id}.json")]
        [HttpGet]
        public async Task<IActionResult> getById(int id)
        {
            Administrador adm = await _context.Administradores.FindAsync(id);
            return StatusCode(200,adm);
        }

        // POST: Administradores
        [Route("/api/administradores.json")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(200,administrador);
        }

         // PUT: Administradores
        [Route("/api/administradores/{id}.json")]
        [HttpPut]
        public async Task<IActionResult> Change([FromBody] Administrador administrador)
        {
            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(200,administrador);
        }

          // DELETE: Administradores
        [Route("/api/administradores/{id}.json")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Administrador adm = await _context.Administradores.FindAsync(id);
            _context.Administradores.Remove(adm);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }
    }
}
