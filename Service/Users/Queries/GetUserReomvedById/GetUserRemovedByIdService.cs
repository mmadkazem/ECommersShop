using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using ECommersShop.Service.Users.Queries.GetAllUserRemoved;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Users.Queries.GetUserReomvedById
{
    public class GetUserRemovedByIdService : IGetUserRemovedByIdService
    {
        private readonly AppDbContex _context;
        public GetUserRemovedByIdService(AppDbContex context) => _context = context;

        public async Task<ResultDto<GetRemovedUserDto>> Execute(int id)
        {
            var user = await _context.Users
                        .Where(u => u.Id == id && u.IsRemoved == true)
                        .Select(u => new GetRemovedUserDto(u.Id, u.FullName, u.Email, u.RemoveTime, u.InsertTime))
                        .FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResultDto<GetRemovedUserDto>
                {
                    IsSucssecc = false,
                    Message = "Not user removed exited!!!"
                };
            }
            return new ResultDto<GetRemovedUserDto>
            {
                Data = user,
                IsSucssecc = true,
                Message = "This found removed user..."
            };
        }
    }

}