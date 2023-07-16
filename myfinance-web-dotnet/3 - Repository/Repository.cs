using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Repository.Interfaces;

namespace myfinance_web_dotnet.Repository
{

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected DbContext DB;
        protected DbSet<TEntity> DBSetContext;

        protected Repository(DbContext DBContext)
        {
            DB = DBContext;
            DBSetContext = DB.Set<TEntity>();
        }
        public void Cadastrar(TEntity Entidade)
        {
            if (Entidade.Id == null)
            {
                DBSetContext.Add(Entidade);
            }
            else
            {
                DBSetContext.Attach(Entidade);
                DB.Entry(Entidade).State = EntityState.Modified;
            }
            DB.SaveChanges();
        }

        public void Excluir(int id)
        {
            var Entidade = new TEntity() { Id = id };
            DB.Attach(Entidade);
            DB.Remove(Entidade);
            DB.SaveChanges();
        }

        public List<TEntity> ListarRegistros()
        {
            return DBSetContext.ToList();
        }

        public TEntity RetornarRegistro(int Id)
        {
            return null;
        }
    }
}