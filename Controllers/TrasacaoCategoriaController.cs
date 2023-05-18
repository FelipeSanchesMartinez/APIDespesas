using despesas.Services;
using despesas.ViewModels;
using Despesas.Data;
using Despesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Despesas.Controllers
{
    [ApiController]
    [Route("/transicao-categoria")]
    public class TransacaoCategoriaController : ControllerBase
    {
        SqlContext _sqlContext;
        ITransacaoCategoriaService _transacaoCategoriaService;
        public TransacaoCategoriaController(SqlContext sqlContext,ITransacaoCategoriaService transacaoCategoriaService)
        {
            _sqlContext = sqlContext;
            _transacaoCategoriaService = transacaoCategoriaService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Models.TransacaoCategoria> transacaoCategorias = _sqlContext.TransacaoCategoria.Where(x => x.Deletado == false).ToList();
            return Ok(transacaoCategorias);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] InsertTransacaoCategoriaViewModel viewModel)
        {
        
            return Ok(viewModel);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TransacaoCategoria transacaoCategoria = _sqlContext.TransacaoCategoria.FirstOrDefault(x => x.Id == id);
            return Ok(transacaoCategoria);
        }
        [HttpPut("{id}")]
        public IActionResult UpDate(int id, [FromBody] TransacaoCategoria transacaoCategoria)
        {
            TransacaoCategoria transacaoCategoria1 = _sqlContext.TransacaoCategoria.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (transacaoCategoria1 == null)
                return NotFound();
            _sqlContext.TransacaoCategoria.Update(transacaoCategoria);
            _sqlContext.SaveChanges();
            return Ok(transacaoCategoria);


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            TransacaoCategoria transacaoCategoriaDelete = _sqlContext.TransacaoCategoria.FirstOrDefault(x => x.Id == id);
            if (transacaoCategoriaDelete == null)
                return NotFound();
            transacaoCategoriaDelete.Deletado = true;
            _sqlContext.SaveChanges();
            return NoContent();

        }
    }


}
