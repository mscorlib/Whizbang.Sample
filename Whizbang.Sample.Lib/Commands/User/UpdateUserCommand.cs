using System;
using Whizbang.Core.Commands;

namespace Whizbang.Sample.Lib.Commands.User
{
    public class UpdateUserCommand : Command
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}