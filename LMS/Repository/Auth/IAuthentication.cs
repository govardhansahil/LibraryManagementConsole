using DomainLayer.Models;

namespace Repository.Auth
{
    public interface IAuthentication
    {
        int Authenticate(AuthModel obj);
        string Register(UserModel obj);
    }
}