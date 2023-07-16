using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services.Interfaces;

namespace myfinance_web_dotnet.Application.ObterPlanoContaUseCase
{
    public class ObterPlanoContaUseCase : IObterPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;
        public ObterPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }
        List<PlanoContaModel> IObterPlanoContaUseCase.GetListaPlanoContaModel()
        {

            return _planoContaService.ListaPlanoContaModel();
        }
    }
}