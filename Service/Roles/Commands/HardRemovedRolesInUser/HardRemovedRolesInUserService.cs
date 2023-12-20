using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Commands.HardRemovedRolesInUser
{
    public class HardRemovedRolesInUserService : IHardRemovedRolesInUserService
    {
        private readonly DataBaseContext _context;

        public HardRemovedRolesInUserService(DataBaseContext context) => _context = context;

        public async Task<ResultDto> Execute(int userId, Role roleRemoved)
        {
            var roles = await _context.UserInRoles
                        .Where(u => u.UserId == userId)
                        .ToListAsync();

            if (roles.Count == 1)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "There is one role for this user!!!"
                };
            }

            var role = await _context.UserInRoles.Where(u => 
                        u.UserId == userId &&
                        u.Role == roleRemoved)
                        .FirstOrDefaultAsync();

            if (role is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This roles user not exite!!!"
                };
            }
            _context.UserInRoles.Remove(role);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "User hard removed successfully..."
            };
        }
    }
}