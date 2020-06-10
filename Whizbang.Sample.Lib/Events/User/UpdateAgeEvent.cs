using Whizbang.Core.EventSource;

namespace Whizbang.Sample.Lib.Events.User
{
    public class UpdateAgeEvent : DomainEvent
    {
        public int Age { get; set; }
    }
}