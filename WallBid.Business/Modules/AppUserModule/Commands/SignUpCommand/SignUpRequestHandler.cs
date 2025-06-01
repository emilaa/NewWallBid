using MediatR;
using Microsoft.AspNetCore.Identity;
using WallBid.Infrastructure.Entities;

namespace WallBid.Business.Modules.AppUserModule.Commands.SignUpCommand
{
    internal class SignUpRequestHandler : IRequestHandler<SignUpRequest, IdentityResult>
    {
        private readonly UserManager<AppUser> _userManager;

        public SignUpRequestHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            return result;
        }
    }
}
