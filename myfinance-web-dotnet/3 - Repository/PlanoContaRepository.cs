using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Repository.Interfaces;

namespace myfinance_web_dotnet.Repository
{

    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(MyFinanceDbController myFinanceDbContext): base(myFinanceDbContext)
        {
            
        }

    }
}