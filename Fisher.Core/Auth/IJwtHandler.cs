using System.Collections.Generic;
using Fisher.Core.Data.Dtos;

namespace Fisher.Core.Utilities
{
    public interface IJwtHandler
    {
        JwtDto GetToken(string userName, string roles);
    }
}