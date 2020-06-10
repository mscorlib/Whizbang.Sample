using System;
using System.Collections.Generic;
using System.Text;

namespace Whizbang.Sample.Lib.Domain.Entities.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
    }
}
