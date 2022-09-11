using VHaaSh.Models.Account;

namespace VHaaSh.DataAccessLayer.Interfaces.Account
{
    public interface IAuthenticationDB
    {
        int Register(User user);
        User Authenticate(User user);
    }
}
