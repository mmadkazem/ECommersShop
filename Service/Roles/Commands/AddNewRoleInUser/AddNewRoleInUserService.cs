using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Commands
{
    public class AddNewRoleInUserService : IAddNewRoleInUserService
    {
        private readonly DataBaseContext _context;
        public AddNewRoleInUserService(DataBaseContext context) => _context = context;

        public async Task<ResultDto> Execute(int userId, Role role)
        {
            var roles = await _context.UserInRoles
                        .Where(u => !u.IsRemoved && u.UserId == userId)
                        .ToListAsync();
            if (roles.Count == 3)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user's roles have been filled!!!"
                };
            }
            foreach (var item in roles)
            {
                if (item.Role == role)
                {
                    return new ResultDto
                    {
                        IsSucssecc = false,
                        Message = "This role has already been added"
                    };
                }
            }
            var user = await _context.Users
                        .Where(u => !u.IsRemoved && u.Id == userId)
                        .FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }

            var userInRole = new UserInRole
            {
                User = user,
                UserId = userId,
                Role = role
            };

            await _context.UserInRoles.AddAsync(userInRole);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "User added successfully..."
            };
        }
    }
}