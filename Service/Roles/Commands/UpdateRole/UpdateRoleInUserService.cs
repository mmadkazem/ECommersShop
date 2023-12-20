using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Commands.UpdateRole
{
    public class UpdateRoleInUserService : IUpdateRoleInUserService
    {
        private readonly DataBaseContext _context;
        public UpdateRoleInUserService(DataBaseContext context) => _context = context;

        public async Task<ResultDto> Execute(int userId, Role? OldRole, Role? RoleUpdate)
        {
            if (OldRole == RoleUpdate)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This role has already been added"
                };
            }
            var userInRole = await _context.UserInRoles
                            .Where(u => !u.IsRemoved
                                && u.UserId == userId
                                && OldRole == u.Role)
                            .FirstOrDefaultAsync();
            if (userInRole is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This roles user does not exist!!!"
                };
            }

            userInRole.Role = RoleUpdate;
            userInRole.UpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This updated roles user successfully..."
            };
        }
    }

}