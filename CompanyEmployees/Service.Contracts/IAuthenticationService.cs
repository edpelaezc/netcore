using System;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IAuthenticationService
	{
        Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthentication);
        Task<string> CreateToken();
    }
}

