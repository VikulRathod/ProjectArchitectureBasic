namespace VHaaSh.Utilities
{
    public interface ILoginHelper
    {
        string GenerateRandomOtp();
        string GeneratePassword(int passLength);
    }
}
