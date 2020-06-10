using System;
using Whizbang.Core.EventSource;
using Whizbang.Core.Domain;
using Whizbang.Sample.Lib.Domain.Entities.Models;
using Whizbang.Sample.Lib.Domain.Entities.Snapshots;
using Whizbang.Sample.Lib.Events.User;

namespace Whizbang.Sample.Lib.Domain.Entities.Entities
{
    public class User : AggregateRoot
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }

        public static User CreateUser(UserModel obj)
        {
            var user = new User();

            var @event = new CreateUserEvent
            {
                SourceId = obj.Id,
                Data = new UserModel
                {
                    Id = obj.Id,
                    Username = obj.Username,
                    Password = obj.Password,
                    Salt = obj.Salt,
                    Age = obj.Age,
                    Male = obj.Male
                }
            };

            user.ApplyChange(@event);

            return user;
        }

        public void UpdateAge(int age)
        {
            var @event = new UpdateAgeEvent
            {
                SourceId = Id,
                Age = age
            };

            ApplyChange(@event);
        }

        public void UpdatePassword(string password)
        {
            var @event = new UpdatePasswordEvent
            {
                SourceId = Id,
                Password = password
            };

            ApplyChange(@event);
        }


        public override void Delete(Guid id)
        {
            var @event = new DeleteUserEvent {SourceId = id};

            ApplyChange(@event);
        }

        public override void BuildFromSnapshot(ISnapshot snapshot)
        {
            var obj = snapshot as UserSnapshot;

            if (null == obj)
                return;

            Username = obj.Username;
            Password = obj.Password;
            Salt = obj.Salt;
            Age = obj.Age;
            Male = obj.Male;
        }

        protected override Snapshot CreateSnapshot()
        {
            var snapshot = new UserSnapshot
            {
                SourceId = Id,
                Username = Username,
                Password = Password,
                Salt = Salt,
                Age = Age,
                Male = Male

            };

            return snapshot;
        }

        private void Apply(CreateUserEvent @event)
        {
            Id = @event.SourceId;
            Username = @event.Data.Username;
            Password = @event.Data.Password;
            Salt = @event.Data.Salt;
            Age = @event.Data.Age;
            Male = @event.Data.Male;
        }

        private void Apply(UpdateAgeEvent @event)
        {
            Age = @event.Age;
        }

        private void Apply(UpdatePasswordEvent @event)
        {
            Password = @event.Password;
        }
    }
}