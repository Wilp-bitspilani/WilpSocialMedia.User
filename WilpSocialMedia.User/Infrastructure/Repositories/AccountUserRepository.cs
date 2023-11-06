using WilpSocialMedia.Common;
using WilpSocialMedia.Common.Infrastructure.Interface;
using WilpSocialMedia.Common.Repositories;
using WilpSocialMedia.User.Domain.Model;
using WilpSocialMedia.User.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilpSocialMedia.User.Infrastructure.Repositories
{
    public class AccountUserRepository : EfRepository<AccountUser>, IAccountUserRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly Wilpsocialmedia_UserContext _userContext;
        public AccountUserRepository(Wilpsocialmedia_UserContext userContext, IDbContextFactory dbContextFactory) : base(userContext)
        {
            _dbContextFactory = dbContextFactory;
            _userContext = userContext;
        }

        public IEnumerable<AccountUser> ListParents(Guid IdAccountUser)
        {
            var parents = _userContext.AccountUser.Where(x => x.Id == IdAccountUser)
                .Select(x => x.Parent);

            var result = _userContext.AccountUser.Where(x => parents.Contains(x.Id));

            return result;
        }


        public IEnumerable<AccountUser> ListSubordinates(Guid IdAccountUser)
            => _userContext.AccountUser.Where(x => x.Parent == IdAccountUser);

        public IEnumerable<AccountUser> ListUsers(string keyword)
        {
            var result = new DapperMicroOrmRepository<AccountUser>(_dbContextFactory.GetDbConnection(Global.DbConnection.UserConnection))
                            .FromSql("SELECT * FROM AccountUser where Name like @keyword", new { keyword = "%" + keyword + "%" });

            return result;
        }
    }
}
