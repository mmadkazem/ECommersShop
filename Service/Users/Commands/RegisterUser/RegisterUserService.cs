using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Persistance;

namespace ECommersShop.Service.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly AppDbContex _context;
        public RegisterUserService(AppDbContex context) => _context = context;

        public async Task<ResultDto> Execute(RegisterUserDto model)
        {
            if (model is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "this user is null!!!"
                };
            }
            var user = new User
            {
                FullName = model.FullName,
                Password = model.Password,
                Email = model.Email
            };

            List<UserInRole> userInRole = new List<UserInRole>();


            userInRole.Add(new UserInRole
            {
                User = user,
                UserId = user.Id,
                Role = Role.Customer,
            });
            user.UserInRoles = userInRole;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "User registered successfully..."
            };
        }
    }
}