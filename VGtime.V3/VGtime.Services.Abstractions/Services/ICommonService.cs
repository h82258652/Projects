using System.Threading.Tasks;

namespace VGtime.Services
{
    public interface ICommonService
    {
        Task GetCodeAsync(string account, int type);

        Task LoginAsync(string account, string password);

        Task RegisterAsync(string account, string password, string code);

        Task ResetPasswordAsync(string account, string password);

        Task VerifyCodeAsync(string account, string code);
    }
}