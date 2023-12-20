using ECommersShop.Persistance;
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
    public class UsersServicesFacad : IUsersServicesFacad
    {
        private readonly DataBaseContext _context;
        public UsersServicesFacad(DataBaseContext context) => _context = context;

        IGetAllUsersService _getAllUsers;
        IGetAllUsersService IUsersServicesFacad.GetAllUsers
        {
            get
            {
                return _getAllUsers = _getAllUsers ??
                    new GetAllUsersService(_context);
            }
        }
        private IGetUserByIdService _getUserById;
        IGetUserByIdService IUsersServicesFacad.GetUserById
        {
            get
            {
                return _getUserById = _getUserById ??
                    new GetUserByIdService(_context);
            }
        }

        private IGetAllUserRemovedService _getAllUserRemoved;
        IGetAllUserRemovedService IUsersServicesFacad.GetAllUserRemoved
        {
            get
            {
                return _getAllUserRemoved = _getAllUserRemoved ??
                    new GetAllUserRemovedService(_context);
            }
        }

        private IGetUserRemovedByIdService _getUserRemovedById;
        IGetUserRemovedByIdService IUsersServicesFacad.GetUserRemovedById
        {
            get
            {
                return _getUserRemovedById = _getUserRemovedById ??
                    new GetUserRemovedByIdService(_context);
            }
        }

        // Commands Services

        private IRegisterUserService _registerUser;
        IRegisterUserService IUsersServicesFacad.RegisterUser
        {
            get
            {
                return _registerUser = _registerUser ??
                    new RegisterUserService(_context);
            }
        }

        private IUpdateUserService _updateUser;
        IUpdateUserService IUsersServicesFacad.UpdateUser
        {
            get
            {
                return _updateUser = _updateUser ??
                    new UpdateUserService(_context);
            }
        }
        private IRemoveUserService _removeUser;
        IRemoveUserService IUsersServicesFacad.RemoveUser {
            get{
                return _removeUser = _removeUser ??
                    new RemoveUserService(_context);
            }
        }
        private IReturnRemovedUserService _returnRemovedUser;
        IReturnRemovedUserService IUsersServicesFacad.ReturnRemovedUser {
            get{
                return _returnRemovedUser = _returnRemovedUser ??
                    new ReturnRemovedUserService(_context);
            }
        }
        private IHardRemovedUserService _hardRemovedUser;
        IHardRemovedUserService IUsersServicesFacad.HardRemovedUser {
            get{
                return _hardRemovedUser = _hardRemovedUser ??
                    new HardRemovedUserService(_context);
            }
        }
    }
}