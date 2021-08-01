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
     public class ApiPaginasController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiPaginasController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Paginas
        [HttpGet]
        [Route("/api/paginas.json")]
        public async Task<IActionResult> Index(int page=1)
        {
            return StatusCode(200,await _context.Paginas.ToPagedListAsync(page,PaginaService.ITENS_POR_PAGINA));
        }


         // GET ById: Paginas
        [HttpGet]
        [Route("/api/paginas/{id}.json")]
        public async Task<IActionResult> GetById(int id)
        {
            Pagina pag = await _context.Paginas.FindAsync(id);
            return StatusCode(200,pag);
        }


        [HttpPost]
        [Route("/api/paginas.json")]
        public async Task<IActionResult> Criar([FromBody] Pagina pagina)
        {
            _context.Add(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(201,pagina);
        }        

        [HttpPut]
        [Route("/api/paginas/{id}.json")]
        public async Task<IActionResult> Change([FromBody] Pagina pagina)
        {
            _context.Update(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }        

        [HttpDelete]
        [Route("/api/paginas/{id}.json")]
        public async Task<IActionResult> Delete(int id)
        {
              
            if (id == 0)
            {
                return StatusCode(400,new {Mensagem="O Id é Obrigatorio"});
            }

            var pagina = await _context.Paginas.FirstOrDefaultAsync(m => m.Id == id);
            if (pagina == null)
            {
                return StatusCode(404,new {Mensagem="A Pagina não foi encontrada"});
            }

            _context.Paginas.Remove(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }     

        // GET totalRegistos: Paginas
        [Route("/api/paginas/qtde_registros.json")]
        [HttpGet]
        public async Task<IActionResult> QtdeTotal()
        {
            var pags = from pag in( await _context.Paginas.ToListAsync())
                select new {
                    Id = pag.Id
                };
            int qtde_total = pags.Count();
            return StatusCode(200,qtde_total);
        }   

    }
}
