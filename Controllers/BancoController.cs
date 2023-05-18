using despesas.Services;
using despesas.ViewModels;
using Despesas.Data;
using Despesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Despesas.Controllers
{
    [ApiController]
    [Route("/banco")]
    public class BancoController : ControllerBase
    {
        SqlContext _sqlContext;
        IBancoService _bancoService;
        
        public BancoController(SqlContext sqlContext, IBancoService bancoService)
        {
            _sqlContext = sqlContext;
            _bancoService = bancoService;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Banco> banco = _sqlContext.Banco.Where(x => x.Deletado == false).ToList();
            return Ok(banco);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] InsertBancoViewModel viewModel)
        {
           
            return Ok(viewModel);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Banco banco = _sqlContext.Banco.FirstOrDefault(x => x.Id == id);
            return Ok(banco);
        }
        [HttpPut("{id}")]
        public IActionResult UpDate(int id, [FromBody] Banco banco)
        {
            Banco banco1 = _sqlContext.Banco.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (banco1 == null)
                return NotFound();
            _sqlContext.Banco.Update(banco);
            _sqlContext.SaveChanges();
            return Ok(banco);


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Banco bancoDelete = _sqlContext.Banco.FirstOrDefault(x => x.Id == id);
            if (bancoDelete == null)
                return NotFound();
            bancoDelete.Deletado = true;
            _sqlContext.SaveChanges();
            return NoContent();

        }
    }


}
