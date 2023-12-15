using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Commands.RemovedRolesUser
{
    public class RemovedRolesUserService : IRemovedRolesUserService
    {
        private readonly AppDbContex _contex;
        public RemovedRolesUserService(AppDbContex contex) => _contex = contex;

        public async Task<ResultDto> Execute(int userId, Role roleRemoved)
        {
            var userInRole = await _contex.UserInRoles
                        .Where(u => !u.IsRemoved &&
                            u.UserId == userId &&
                            u.Role == roleRemoved)
                        .FirstOrDefaultAsync();

            if (userInRole is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }
            userInRole.IsRemoved = true;
            userInRole.RemoveTime = DateTime.Now;
            await _contex.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "User removed successfully..."
            };
        }
    }
}