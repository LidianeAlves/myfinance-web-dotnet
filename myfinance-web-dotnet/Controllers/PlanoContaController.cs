
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Domain;
namespace myfinance_web_dotnet.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly MyFinanceDbController _myFinanceDbContext;

        public PlanoContaController(
            ILogger<PlanoContaController> logger,
            MyFinanceDbController myFinanceDbContext
        )
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        public IActionResult Index()
        {
            var listaPlanoContas = _myFinanceDbContext.PlanoConta;
            var listaPlanoContaModel = new List<PlanoContaModel>();
            foreach (var item in listaPlanoContas)
            {
                var planoContaModel = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };
                listaPlanoContaModel.Add(planoContaModel);
            }
            ViewBag.listaPlanoConta = listaPlanoContaModel;
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int id)
        {
            var planoConta = new PlanoContaModel();
            if (id != null)
            {
                var planoContaDomain = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
                planoConta.Id = planoContaDomain.Id;
                planoConta.Descricao = planoContaDomain.Descricao;
                planoConta.Tipo = planoContaDomain.Tipo;

            }
            return View(planoConta);
        }


        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{input}")]
        public IActionResult Cadastro(PlanoContaModel input)
        {
            var planoConta = new PlanoConta()
            {
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };
            _myFinanceDbContext.PlanoConta.Add(planoConta);
            _myFinanceDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
