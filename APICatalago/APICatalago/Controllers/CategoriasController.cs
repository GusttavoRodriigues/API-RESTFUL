using APICatalago.Context;
using Microsoft.AspNetCore.Mvc;

namespace APICatalago.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext dbCategoria;

        public CategoriasController(AppDbContext DbCategoria)
        {
            dbCategoria = DbCategoria;
        }


    }
}
