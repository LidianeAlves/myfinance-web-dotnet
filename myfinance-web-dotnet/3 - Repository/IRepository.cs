using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
namespace myfinance_web_dotnet.Repository
{

    public interface IRepository<TEntity> where TEntity:class
    {
                void Cadastrar(TEntity Entidade);
                void Excluir(int id);
                List<TEntity> ListarRegistros();
                TEntity RetornarRegistro(int Id);
    }
}