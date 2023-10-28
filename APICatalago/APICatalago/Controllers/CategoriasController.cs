using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly AppDbContext dbCategoria;

        public CategoriasController(AppDbContext DbCategoria)
        {
            dbCategoria = DbCategoria;
        }

        //Rota para consultar.
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {

            try
            {

                var categoria = dbCategoria.Categorias.ToList();
                if (categoria is null)
                {
                    return NotFound("Nenhuma Categoria encontrada!");
                }
                else
                {
                    return categoria;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }

        }
        //Rota para conultar pelo ID
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = dbCategoria.Categorias.FirstOrDefault(dbCategoria => dbCategoria.Id == id);
            if (categoria is null)
            {
                return NotFound("Nenhuma Categoria encontrada");
            }
            else
            {
                return categoria;
            }
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            return dbCategoria.Categorias.Include(x =>x.Produtos).ToList();

        }


        //Rota para Insert
        [HttpPost]
        public ActionResult<Categoria> Post(Categoria _categoria)
        {
            if (_categoria is null)
            {
                return BadRequest();
            }
            else
            {
                dbCategoria.Categorias.Add(_categoria);
                dbCategoria.SaveChanges();

                //Método para obter outra rota.
                return new CreatedAtRouteResult("ObterCategoria", new { id = _categoria.Id }, _categoria);

            }
        }

        //Rota para Update
        [HttpPut("id:int")]
        public ActionResult<Categoria> Put(int id, Categoria _categoria)
        {
            if (id != _categoria.Id)
            {
                return BadRequest();
            }
            else
            {
                dbCategoria.Entry(_categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbCategoria.SaveChanges();
                return Ok(_categoria);
            }
        }

        //Rota para delete
        [HttpDelete("id:int")]
        public ActionResult Delete(int id)
        {
            var categoria = dbCategoria.Categorias.FirstOrDefault(dbCategoria => dbCategoria.Id == id);
            if (categoria != null) { return NotFound("Categoria não encontrada"); }
            dbCategoria.Remove(categoria); dbCategoria.SaveChanges();
            return Ok(categoria);
        }
    }
}
