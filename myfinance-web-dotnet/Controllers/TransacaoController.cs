using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly MyFinanceDbController _myFinanceDbContext;

        public TransacaoController(
            ILogger<TransacaoController> logger,
            MyFinanceDbController myFinanceDbContext
        )
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        public IActionResult Index()
        {
            var listaTransacoes = _myFinanceDbContext.Transacao.Include(x => x.PlanoConta);
            var listaTransacaoModel = new List<TransacaoModel>();
            foreach (var item in listaTransacoes)
            {
                var planoContaModel = new PlanoContaModel()
                {
                    Id = item.PlanoConta.Id,
                    Descricao = item.PlanoConta.Descricao,
                    Tipo = item.PlanoConta.Tipo
                };
                var transacaoModel = new TransacaoModel()
                {
                    Id = item.Id,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    PlanoContaId = item.PlanoContaId,
                    ItemPlanoConta = planoContaModel
                };
                listaTransacaoModel.Add(transacaoModel);
            }
            ViewBag.listaPlanoConta = listaTransacaoModel;
            return View();
        }

        // [HttpGet]
        // [Route("Transacao/Cadastro")]
        // [Route("Transacao/Cadastro/{id}")]
        // public IActionResult Cadastro(int id)
        // {
        //     var transacao = new TransacaoModel();
        //     if (id != null)
        //     {
        //         //var transacaoDomain = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
        //         var transacaoDomain = _myFinanceDbContext.Transacao.Find(id);
        //         if (transacaoDomain != null)
        //         {
        //             transacao.Id = transacaoDomain.Id;
        //             transacao.Historico = transacaoDomain.Historico;
        //             transacao.Valor = transacaoDomain.Valor;
        //             transacao.Data = transacaoDomain.Data;
        //             transacao.PlanoContaId = transacaoDomain.PlanoContaId;
        //         }

        //     }
        //     return View(transacao);
        // }

        [HttpGet]
        [Route("Transacao/Cadastro")]
        [Route("Transacao/Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
var itensPlanoConta = _myFinanceDbContext.PlanoConta;
            var transacaoModel = new TransacaoModel();
            List<SelectListItem> itensPlano = new List<SelectListItem> ();
            foreach (var item in itensPlanoConta)
            {
                itensPlano.Add(new SelectListItem(){Text = item.Descricao, Value = ""+item.Id});
            }
            
            transacaoModel.PlanoContas = itensPlano;

            if (id != null)
            {
                var transacao = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
                transacaoModel.Data = transacao.Data;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;
            }
            return View(transacaoModel);
        }

        [HttpPost]
        [Route("Transacao/Cadastro")]
        [Route("Transacao/Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel input)
        {
            var transacao = new Transacao()
            {
                Id = input.Id,
                Historico = input.Historico,
                Valor = (decimal)input.Valor,
                Data = (DateTime)input.Data,
                PlanoContaId = (int)input.PlanoContaId
            };

            if (transacao.Id == null)
            {
                _myFinanceDbContext.Transacao.Add(transacao);
            }
            else
            {
                _myFinanceDbContext.Transacao.Attach(transacao);
                _myFinanceDbContext.Entry(transacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Transacao/Excluir/{id}")]
        public IActionResult Excluir(int? id)
        {
            Console.WriteLine("--------------EXCLUIR-------------");
            var transacao = new Transacao() { Id = id };
            _myFinanceDbContext.Transacao.Remove(transacao);
            _myFinanceDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
