using DomainLayer.Models;

namespace BusinessLayer.Auth
{
    public interface IAuthentication
    {
        int Authenticate(AuthModel obj);
        string Register(UserModel obj);
    }
}