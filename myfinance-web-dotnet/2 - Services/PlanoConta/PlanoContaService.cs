using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Repository.Interfaces;
using myfinance_web_dotnet.Services.Interfaces;

namespace myfinance_web_dotnet.Service.PlanoContaService
{

    public class PlanoContaService : IPlanoContaService
    {
        IPlanoContaRepository _planoContaRepository;
        public PlanoContaService(IPlanoContaRepository planoContaRepository)
        {
            _planoContaRepository = planoContaRepository;
        }

        public void CadastrarPlanoConta(PlanoContaModel input)
        {
            var planoConta = new PlanoConta(){
                    Id = input.Id,
                    Descricao = input.Descricao,
                    Tipo = input.Tipo
                };
                _planoContaRepository.Cadastrar(planoConta);
        }

        public List<PlanoContaModel> ListaPlanoContaModel()
        {

            var lista = new List<PlanoContaModel>();
            var listaPlanoContas = _planoContaRepository.ListarRegistros();
            foreach (var item in listaPlanoContas)
            {
                var planoContaModel = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };
                lista.Add(planoContaModel);
            }
            return lista;
        }
    }
}