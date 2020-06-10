using Whizbang.Core;
using Whizbang.Core.Commands;
using Whizbang.Core.EventSource.Storage;
using Whizbang.Sample.Lib.Commands.User;
using Whizbang.Sample.Lib.Domain.Entities.Entities;

namespace Whizbang.Sample.Lib.CommandHandlers
{
    public class UserCommandHandler :
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<UpdateUserCommand>,
        ICommandHandler<DeleteUserCommand>

    {
        private readonly IDomainRepository<User> _repository;

        public UserCommandHandler()
        {
            _repository = App.Container.Resolve<IDomainRepository<User>>();
        }

        public void Handle(CreateUserCommand message)
        {
            var user = User.CreateUser(message.Data);

            _repository.Save(user, Constants.InitialAggregateRootVersion);
        }

        public void Handle(UpdateUserCommand message)
        {
            //todo: is there need to lock the aggregate root?

            var user = _repository.GetById(message.UserId);

            if (!string.IsNullOrWhiteSpace(message.Password))
                user.UpdatePassword(message.Password);

            if (0 < message.Age)
                user.UpdateAge(message.Age);

            _repository.Save(user, user.Version);
        }

        public void Handle(DeleteUserCommand message)
        {
            var user = _repository.GetById(message.SourceId);

            user.Delete(message.SourceId);

            _repository.Save(user, user.Version);
        }
    }
}