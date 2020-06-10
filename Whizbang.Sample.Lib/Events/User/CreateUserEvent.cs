using Whizbang.Core.EventSource;
using Whizbang.Sample.Lib.Domain.Entities.Models;

namespace Whizbang.Sample.Lib.Events.User
{
    public class CreateUserEvent : GenericEvent<UserModel>
    {
    }
}