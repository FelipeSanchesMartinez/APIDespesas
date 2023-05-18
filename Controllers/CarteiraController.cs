using despesas.Models;
using despesas.Services;
using despesas.ViewModels;
using Despesas.Data;
using Despesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Despesas.Controllers
{
    [ApiController]
    [Route("/carteira")]
    public class CarteiraController : ControllerBase
    {
        SqlContext _sqlContext;
        ICarteiraService _carteiraService;
        public CarteiraController(SqlContext sqlContext, ICarteiraService carteiraService)
        {
            _sqlContext = sqlContext;
            _carteiraService = carteiraService;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Carteira> carteira = _sqlContext.Carteira.Include(x => x.Banco).Where(x => x.Deletado == false).ToList();
            return Ok(carteira);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] InsertCarteiraViewModel viewModel)
        {
            
            return Ok(viewModel);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Carteira carteira = _sqlContext.Carteira.Include(x => x.Banco).FirstOrDefault(x => x.Id == id);
            return Ok(carteira);
        }
        [HttpPut("{id}")]
        public IActionResult UpDate(int id, [FromBody] Carteira carteira)
        {
            Carteira carteira1 = _sqlContext.Carteira.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (carteira1 == null)
                return NotFound();
            _sqlContext.Carteira.Update(carteira);
            _sqlContext.SaveChanges();
            return Ok(carteira);


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Carteira carteiraDeletede = _sqlContext.Carteira.FirstOrDefault(x => x.Id == id);
            if (carteiraDeletede == null)
                return NotFound();
            carteiraDeletede.Deletado = true;
            _sqlContext.SaveChanges();
            return NoContent();

        }
    }


}
