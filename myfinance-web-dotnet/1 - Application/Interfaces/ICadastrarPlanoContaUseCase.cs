using myfinance_web_dotnet.Models;
namespace myfinance_web_dotnet.Application.ObterPlanoContaUseCase
{
    public interface ICadastrarPlanoContaUseCase
    {
        void Cadastrar(PlanoContaModel input);
    }
}