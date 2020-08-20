using Dapper;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Beg.Dapper.Data
{
    public class UserRepository
    {
        readonly IDbContextFactory dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public Task<Beg.User.Data.User> Get(Guid id)
        {
            var dbContext = dbContextFactory.GetInstance();
            var sql = new StringBuilder(@"SELECT * FROM projects.""Document""");
            sql.Append(@" WHERE ""ObjId"" = @Id AND ""UpdateDatetime"" IS NULL LIMIT 1;");
            return dbContext.connection.QueryFirstOrDefaultAsync<Beg.User.Data.User>(sql.ToString(), new { Id = id }, dbContext.transaction);
        }
    }
}
