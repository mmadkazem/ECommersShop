
using ECommersShop.Service.Users.Commands.HardRemoveUser;
using ECommersShop.Service.Users.Commands.RegisterUser;
using ECommersShop.Service.Users.Commands.RemoveUser;
using ECommersShop.Service.Users.Commands.ReturnUser;
using ECommersShop.Service.Users.Commands.UpdateUser;
using ECommersShop.Service.Users.Queries.GetAllUser;
using ECommersShop.Service.Users.Queries.GetAllUserRemoved;
using ECommersShop.Service.Users.Queries.GetUserById;
using ECommersShop.Service.Users.Queries.GetUserReomvedById;

namespace ECommersShop.FacadPattern
{
    public interface IUsersServicesFacad
    {
        // Queries Services
        IGetAllUsersService GetAllUsers { get; }
        IGetUserByIdService GetUserById { get; }
        IGetAllUserRemovedService GetAllUserRemoved { get; }
        IGetUserRemovedByIdService GetUserRemovedById { get; }

        // Commands Services
        IRegisterUserService RegisterUser { get; }
        IUpdateUserService UpdateUser { get; }
        IRemoveUserService RemoveUser { get; }
        IReturnRemovedUserService ReturnRemovedUser { get; }
        IHardRemovedUserService HardRemovedUser { get; }
    }
}