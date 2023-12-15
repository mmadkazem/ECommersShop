using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Commands
{
    public class AddNewRoleInUserService : IAddNewRoleInUserService
    {
        private readonly AppDbContex _contex;
        public AddNewRoleInUserService(AppDbContex contex) => _contex = contex;

        public async Task<ResultDto> Execute(int userId, Role role)
        {
            var roles = await _contex.UserInRoles
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
            var user = await _contex.Users
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

            await _contex.UserInRoles.AddAsync(userInRole);
            await _contex.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "User added successfully..."
            };
        }
    }
}