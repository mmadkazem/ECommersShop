using ECommersShop.Entity;

namespace ECommersShop.Service.Users.Commands.RegisterUser
{
    public record RegisterUserDto(string? FullName, string? Email, string? Password);
}