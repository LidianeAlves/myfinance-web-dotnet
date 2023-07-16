using myfinance_web_dotnet.Models;
namespace myfinance_web_dotnet.Services.Interfaces
{

    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListaPlanoContaModel();
        void CadastrarPlanoConta(PlanoContaModel input);
    }
}