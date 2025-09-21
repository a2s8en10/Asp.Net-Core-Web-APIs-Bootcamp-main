using Microsoft.AspNetCore.Identity;
using OldBookStore.Model;
using System.Threading.Tasks;

namespace OldBookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
