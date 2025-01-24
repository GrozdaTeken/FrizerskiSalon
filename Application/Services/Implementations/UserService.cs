using Application.DTOs.Create;
using Application.DTOs.Returnable;
using Application.Extensions;
using Application.Services.Interfaces;
using Domain.Repositories.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IUserValidator _UserValidator;
        private readonly IEncryptionService _encryptionService;

        public UserService(IUserRepository UserRepository, IEncryptionService encryptionService)
        {
            _userRepository = UserRepository;
            //_UserValidator = UserValidator;
            _encryptionService = encryptionService;
        }

        public async Task<UserReturnable> GetUserByIdAsync(Guid id)
        {
            var User = await _userRepository.GetUserByIdAsync(id);
            return User.ConvertToReturnable();
        }

        public async Task<UserReturnable> AddUserAsync(UserCreate UserCreate)
        {

            if (string.IsNullOrEmpty(UserCreate.Password))
            {
                UserCreate.Password = "00000000";
            }

            //var validationErrors = _UserValidator.Validate(UserCreate);

            //if (validationErrors != null && validationErrors.Any())
            //{
            //    throw new ArgumentException("Validation failed.", nameof(UserCreate));
            //}

            var hashedPassword = _encryptionService.GenerateHashedPassword(UserCreate.Password);

            var User = UserCreate.ConvertToEntity(hashedPassword);

            try
            {
                await _userRepository.AddUserAsync(User);
                var UserReturnable = User.ConvertToReturnable();

                return UserReturnable;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add User.", ex);
            }
        }

        public async Task<UserReturnable> UpdateUserAsync(UserCreate UserCreate)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(UserCreate.UserId) ?? throw new Exception("User doesn't exist.");
            //var validationErrors = _UserValidator.Validate(UserCreate);

            //if (validationErrors != null && validationErrors.Any())
            //{
            //    throw new ArgumentException("Validation failed.", nameof(UserCreate));
            //}

            existingUser.Username = UserCreate.Username;
            existingUser.Email = UserCreate.Email;
            existingUser.Role = UserCreate.Role;

            await _userRepository.UpdateUserAsync();

            return existingUser.ConvertToReturnable();
        }

        public async Task<bool> DeleteUserAsync(Guid memId)
        {

            if (memId == Guid.Empty)
            {
                return false;
            }

            return await _userRepository.DeleteUserAsync(memId);
        }

        public async Task<IEnumerable<UserReturnable>> GetAllUsersAsync(Guid? staId)
        {
            var Users = await _userRepository.GetAllUsersAsync(staId);

            return Users.Select(User => User.ConvertToReturnable());
        }

        public async Task<UserReturnable> GetUserByEmailAndPasswordAsync(string email, string password)
        {

            var hashedPassword = _encryptionService.GenerateHashedPassword(password);

            var User = await _userRepository.GetUserByEmailAndPasswordAsync(email, hashedPassword);

            if (User == null)
            {
                return null;
            }

            return User.ConvertToReturnable();
        }

        public async Task<UserReturnable> GetUserByUsernameAndPasswordAsync(string username, string password)
        {

            var hashedPassword = _encryptionService.GenerateHashedPassword(password);

            var User = await _userRepository.GetUserByUsernameAndPasswordAsync(username, hashedPassword);

            if (User == null)
            {
                return null;
            }

            return User.ConvertToReturnable();
        }

        public async Task<bool> EmailExistAsync(string email)
        {

            var UserExists = await _userRepository.EmailExistAsync(email);

            return UserExists;
        }
        public async Task<UserReturnable> GetUserByEmailAsync(string email)
        {
            var User = await _userRepository.GetUserByEmailAsync(email);
            return User.ConvertToReturnable();
        }
    }
}
