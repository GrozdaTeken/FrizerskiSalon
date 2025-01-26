using Domain.Entities;
using Domain.Repositories.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User User)
        {
            try
            {
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return User;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add User. See inner exception for details.", ex);
            }
        }

        public async Task UpdateUserAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(Guid memId)
        {
            try
            {
                var User = await GetUserByIdAsync(memId);
                _context.Users.Remove(User);
                var finished = await _context.SaveChangesAsync();
                return finished > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(Guid? staId)
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid? id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(User => User.UserId == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(m => m.Email == email && m.Password == password);
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(m => m.Username == username && m.Password == password);
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            var User = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == email);

            if (User == null)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(m => m.Email == email);
        }
    }
}
