using Microsoft.AspNetCore.Identity;
using Practice_1.Model;
using System.Threading.Tasks;

namespace Practice_1.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}
