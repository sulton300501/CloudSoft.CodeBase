using CloudSoft.Data.Entities.Auth;
using System.Threading.Tasks;

namespace CloudSoft.Service.Abstractions.AuthServices
{
    public interface IAuthService
    {
        Task<string> GenerateToken(UserApp user);
    }
}
