using UsersCrud.Models;
using UsersCrud.ServiceModels.UserEdit;
using UsersCrud.ServiceModels.UserList;

namespace UsersCrud.Interfaces
{
    public interface IUserService
    {
        (List<UserListDto>, int) GetUsers(UserListRequest request);

        int AddUser(User user);

        User GetUserById(int userId);

        (bool, string) UpdateUser(UserEditRequest request);  

        void DeleteUser(User user);
    }
}
