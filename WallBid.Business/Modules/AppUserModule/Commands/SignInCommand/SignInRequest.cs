using MediatR;

namespace WallBid.Business.Modules.AppUserModule.Commands.SignInCommand
{
    public class SignInRequest : IRequest<string?>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
