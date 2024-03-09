using FORCEGET.Application.Auth.Queries.Login.Dtos;
using FORCEGET.Application.Common.Exceptions;
using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Managers;
using FORCEGET.Application.Common.Mappings;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FORCEGET.Application.Auth.Queries.Login
{
    public class LoginCommand : IRequest<BaseResponseModel<LoginDto>>, IMapFrom<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<LoginCommand, BaseResponseModel<LoginDto>>
        {
            private readonly SignInManager<User> _signInManager;

            private readonly TokenManager _tokenManager;
            private readonly UserManager<User> _userManager;
            private readonly IApplicationContext _context;

            public Handler(SignInManager<User> signInManager, TokenManager tokenManager, UserManager<User> userManager,
                IApplicationContext context)
            {
                _signInManager = signInManager;
                _tokenManager = tokenManager;
                _userManager = userManager;
                _context = context;
            }

            public async Task<BaseResponseModel<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                LoginDto loginViewModel = new LoginDto();
                User? appUser = await _userManager.FindByEmailAsync(request.Email);
                if (appUser != null)
                {
                    SignInResult result = await _signInManager.PasswordSignInAsync(appUser.UserName, request.Password,
                        false, false);

                    if (result.Succeeded)
                    {
                        loginViewModel = await _tokenManager.GenerateToken(appUser);
                        return BaseResponseModel<LoginDto>.Success(data: loginViewModel,$"Login was successful.");
                    }
                }
                
                throw new BadRequestException($"Login failed.");
            }
        }
    }
}