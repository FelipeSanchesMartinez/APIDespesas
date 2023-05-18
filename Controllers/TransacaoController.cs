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
    [Route("/transacao")]
    public class TransacaoController : ControllerBase
    {
        SqlContext _sqlContext;
        ITransacaoService _transacaoService;

        public TransacaoController(SqlContext sqlContext, ITransacaoService transacaoService)
        {
            _sqlContext = sqlContext;
            _transacaoService = transacaoService;


        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Transacao> transacoes = _sqlContext.Transacao.Include(x => x.Categoria).Where(x => x.Deletado == false).ToList();
            return Ok(transacoes);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] InsertTransacaoViewModel viewModel)
        {
            _transacaoService.Insert(viewModel);

            return Ok(viewModel);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Transacao trasacao = _sqlContext.Transacao.Include(x => x.Categoria).FirstOrDefault(x => x.Id == id);
            return Ok(trasacao);
        }
        [HttpPut("{id}")]
        public IActionResult UpDate(int id, [FromBody] Transacao transacao)
        {
            Transacao transacao1 = _sqlContext.Transacao.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (transacao1 == null)
                return NotFound();
            _sqlContext.Transacao.Update(transacao);
            _sqlContext.SaveChanges();
            return Ok(transacao);


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Transacao transacaoDeleted = _sqlContext.Transacao.FirstOrDefault(x => x.Id == id);
            if (transacaoDeleted == null)
                return NotFound();
            transacaoDeleted.Deletado = true;
            _sqlContext.SaveChanges();
            return NoContent();

        }
    }


}
