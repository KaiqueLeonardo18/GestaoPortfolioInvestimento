using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enums;
using GestaoPortfolioInvestimentos.Infrastructure.Context;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly SqlDbContext _context;

        public UserRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
            _context = sqlDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> ExistsUser(string username, Roles role)
        {
            return await _context.Users.AnyAsync(u => u.Username == username && u.Role == role);
        }
    }
}
