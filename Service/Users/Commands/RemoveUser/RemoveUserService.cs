using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly DataBaseContext _context;
        public RemoveUserService(DataBaseContext context) => _context = context;
        public async Task<ResultDto> Execute(int id)
        {
            var user = await _context.Users
                        .Include(u => u.UserInRoles)
                        .Where(u => u.Id == id)
                        .FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }
            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            if (user.UserInRoles is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "User is Not Rols!!!"
                };
            }
            foreach (var item in user.UserInRoles)
            {
                item.IsRemoved = true;
                item.RemoveTime = DateTime.Now;
            }
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This user is Removed..."
            };
        }
    }
}