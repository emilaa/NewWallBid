﻿using MediatR;
using Microsoft.AspNetCore.Identity;

namespace WallBid.Business.Modules.AppUserModule.Commands.SignUpCommand
{
    public class SignUpRequest : IRequest<IdentityResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
