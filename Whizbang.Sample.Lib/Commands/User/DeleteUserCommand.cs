using System;
using Whizbang.Core.Commands;

namespace Whizbang.Sample.Lib.Commands.User
{
    public class DeleteUserCommand : Command
    {
        public Guid SourceId { get; set; }
    }
}