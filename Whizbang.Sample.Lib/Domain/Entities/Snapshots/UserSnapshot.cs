using System;
using Whizbang.Core.EventSource;

namespace Whizbang.Sample.Lib.Domain.Entities.Snapshots
{
    public class UserSnapshot : Snapshot
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
    }
}