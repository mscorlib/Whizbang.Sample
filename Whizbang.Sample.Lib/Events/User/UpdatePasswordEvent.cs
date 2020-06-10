using Whizbang.Core.EventSource;

namespace Whizbang.Sample.Lib.Events.User
{
    public class UpdatePasswordEvent : DomainEvent
    {
        public string Password { get; set; }
    }
}