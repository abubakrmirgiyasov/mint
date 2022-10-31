using Mint.Domain.BindingModels;

namespace Mint.Middleware.Services.Interfaces;

public interface IAdminRequestService
{
    Task<string> Login(AdminBindingModel admin);
}
