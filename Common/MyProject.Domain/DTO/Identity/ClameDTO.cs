using System.Collections.Generic;
using System.Security.Claims;

namespace MyProject.Domain.DTO.Identity
{
    public abstract class ClameDTO : UserDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class  AddClaimDTO : ClameDTO { }

    public class RemoveClaimDTO : ClameDTO { }

    public class ReplaceClaimDTO : UserDTO
    {
        public Claim Claim { get; set; }

        public Claim NewClaim { get; set; }
    }
}
