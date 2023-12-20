using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Users.Commands.UpdateUser
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly DataBaseContext _context;
        public UpdateUserService(DataBaseContext context) => _context = context;

        public async Task<ResultDto> Execute(int id, UpdateUserDto model)
        {

            var user = await _context.Users
                        .Where(u => u.Id == id && u.IsRemoved == false)
                        .FirstOrDefaultAsync();

            if (user is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }
            user.FullName = model.FullName;
            user.Email = model.Email;
            user.UpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This user Fullname and Email updated..."
            };
        }
    }
}