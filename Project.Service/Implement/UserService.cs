using Project.Domain;
using Project.Infrastructure.Dapper;

namespace Project.Service.Implement
{
    public class UserService: IUserService
    {
        private readonly IDapperRepository<User> _userRepository;
        public UserService(IDapperRepository<User> userRepository){
            this._userRepository = userRepository;
        }
        public long Add(User user){
            return _userRepository.Insert(user);
        }
    }
}
