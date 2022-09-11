using VHaaSh.Models.Account;

namespace VHaaSh.BusinessLogicLayer.Interfaces.Account
{
    public interface IAuthenticationBL
    {
        int Register(User user);
        User Authenticate(User user);
    }
}
