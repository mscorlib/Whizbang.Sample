using System;
using Whizbang.Core;
using Whizbang.Core.Commands;
using Whizbang.Core.EventSource.Storage;
using Whizbang.Sample.Lib.Commands.User;
using Whizbang.Sample.Lib.Domain.Entities.Entities;
using Whizbang.Sample.Lib.Domain.Entities.Models;

namespace Whizbang.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            App.Init();

            var bus = App.Container.Resolve<ICommandBus>();

            var id3 = Guid.NewGuid();


            var cmd3 = new CreateUserCommand
            {
                Id = id3,
                Data = new UserModel
                {
                    Id = id3,
                    Username = "Hank",
                    Password = "hello777",
                    Salt = "e2dw",
                    Age = 32,
                    Male = true
                }
            };

            bus.Publish(cmd3);

            for (int i = 0; i < 10; i++)
            {
                var cmd2 = new UpdateUserCommand
                {
                    UserId = id3,
                    Password = "newdd" + i,
                    Age = 23 + i
                };

                bus.Publish(cmd2);
            }


            var u3 = App.Container.Resolve<IDomainRepository<User>>().GetById(id3);

            Console.WriteLine(u3.Password);

            Console.WriteLine("done.");
        }
    }
}
