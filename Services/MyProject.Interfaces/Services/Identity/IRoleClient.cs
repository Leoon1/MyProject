using Microsoft.AspNetCore.Identity;
using MyProject.Domain.Entities.Identity;

namespace MyProject.Interfaces.Services.Identity
{
    public interface IRoleClient : IRoleStore<Role>
    {

    }
}