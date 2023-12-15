using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Commands.UpdateRole
{
    public class UpdateRoleInUserService : IUpdateRoleInUserService
    {
        private readonly AppDbContex _contex;
        public UpdateRoleInUserService(AppDbContex contex) => _contex = contex;

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
            var userInRole = await _contex.UserInRoles
                            .Where(u => !u.IsRemoved
                                && u.UserId == userId
                                && OldRole == u.Role)
                            .FirstOrDefaultAsync();
            if (userInRole is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This roles user not exite!!!"
                };
            }

            userInRole.Role = RoleUpdate;
            userInRole.UpdateTime = DateTime.Now;
            await _contex.SaveChangesAsync();
            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This updated roles user successfully..."
            };
        }
    }

}