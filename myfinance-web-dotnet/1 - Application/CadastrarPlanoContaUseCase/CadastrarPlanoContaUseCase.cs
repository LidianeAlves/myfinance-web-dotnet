using myfinance_web_dotnet.Application.ObterPlanoContaUseCase;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services.Interfaces;

namespace myfinance_web_dotnet.Application.CadastrarPlanoContaUseCase
{
    public class CadastrarPlanoContaUseCase : ICadastrarPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;
        public CadastrarPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public void Cadastrar(PlanoContaModel input)
        {
            _planoContaService.CadastrarPlanoConta(input);
        }
    }
}