using System.Data;

namespace Beg.Dapper.Data
{
    public interface IDbContextFactory : IFactory<(IDbConnection connection, IDbTransaction transaction)>
    {
       
    }
}
