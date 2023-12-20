using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Users.Queries.GetAllUserRemoved
{
    public class GetAllUserRemovedService : IGetAllUserRemovedService
    {
        private readonly DataBaseContext _context;
        public GetAllUserRemovedService(DataBaseContext context) => _context = context;
        public async Task<ResultsDto<GetRemovedUserDto>> Execute()
        {
            var user = await _context.Users
            .Where(u => u.IsRemoved == true)
            .Select(u => new GetRemovedUserDto(u.Id, u.FullName, u.Email, u.RemoveTime, u.InsertTime))
            .ToListAsync();
            if (user is null)
            {
                return new ResultsDto<GetRemovedUserDto>
                {
                    IsSucssecc = false,
                    Message = "users does not exist!!!"
                };
            }
            return new ResultsDto<GetRemovedUserDto>
            {
                Data = user,
                IsSucssecc = true,
                Message = "This all users removed..."
            };
        }
    }
}