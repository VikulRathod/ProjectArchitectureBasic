using VHaaSh.BusinessLogicLayer.Interfaces.Account;
using VHaaSh.DataAccessLayer.DatabaseLogic.Account;
using VHaaSh.DataAccessLayer.Interfaces.Account;
using VHaaSh.Models.Account;

namespace VHaaSh.BusinessLogicLayer.BusinessLogic.Account
{
    public class AuthenticationBL : IAuthenticationBL
    {
        private IAuthenticationDB _dal;

        public AuthenticationBL()
        {
            _dal = new AuthenticationDB();
        }

        public int Register(User user)
        {
            return _dal.Register(user);
        }

        public User Authenticate(User user)
        {
            return _dal.Authenticate(user);
        }
    }
}
