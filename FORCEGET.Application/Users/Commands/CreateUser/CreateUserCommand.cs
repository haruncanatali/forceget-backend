using FORCEGET.Application.Common.Exceptions;
using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace FORCEGET.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<BaseResponseModel<long>>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, BaseResponseModel<long>>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IApplicationContext _context;

            public Handler(UserManager<User> userManager, RoleManager<Role> roleManager, IApplicationContext context)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _context = context;
            }

            public async Task<BaseResponseModel<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    bool dublicateControl = _context.Users.Any(x => x.Email == request.Email);
                    if (dublicateControl)
                    {
                        throw new BadRequestException("There is a user registered to this e-mail address in the system.");
                    }
                    
                    User entity = new()
                    {
                        FirstName = request.FirstName,
                        Surname = request.Surname,
                        UserName = request.Email,
                        Email = request.Email
                    };

                    var response = await _userManager.CreateAsync(entity, request.Password);

                    if (response.Succeeded)
                    {
                        Role? role = await _roleManager.FindByNameAsync("Admin");
                    
                        if (role != null)
                        {
                            await _userManager.AddToRoleAsync(entity, "Admin");
                        }
                        else
                        {
                            await _roleManager.CreateAsync(new Role { Name = "Admin" });
                            await _userManager.AddToRoleAsync(entity, "Admin");
                        }
                    }
                    else
                    {
                        throw new BadRequestException("An error occurred while adding a user.");
                    }
                    
                    return BaseResponseModel<long>.Success(entity.Id, $"User added successfully.");
                }
                catch (Exception e)
                {
                    throw new BadRequestException($"An error occurred while adding a user.");
                }
            }
        }
    }
}