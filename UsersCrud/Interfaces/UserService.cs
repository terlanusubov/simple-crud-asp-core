using UsersCrud.Data;
using UsersCrud.Models;
using UsersCrud.ServiceModels.UserEdit;
using UsersCrud.ServiceModels.UserList;

namespace UsersCrud.Interfaces
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context,
                           IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();

            return user.Id;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);

            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

            return user;
        }

        public (List<UserListDto>, int) GetUsers(UserListRequest request)
        {
            var query = _context.Users
                                 .Where(u =>
                                 (String.IsNullOrEmpty(request.UserName) || u.Name.ToLower().StartsWith(request.UserName)) &&
                                 (String.IsNullOrEmpty(request.UserSurname) || u.Surname.ToLower().StartsWith(request.UserSurname)) &&
                                 (String.IsNullOrEmpty(request.UserEmail) || u.Email.ToLower().StartsWith(request.UserEmail)));




            var countOfUsers = query.Count();

            var users = query.Select(u => new UserListDto
                                     {
                                         UserId = u.Id,
                                         Name = u.Name,
                                         Surname = u.Surname,
                                         Email = u.Email,
                                     })
                                     .OrderByDescending(u => u.UserId)
                                     .Skip((request.Page - 1) * (int)request.Take)
                                     .Take((int)request.Take)
                                     .ToList();

            int TotalPage = (int)Math.Ceiling(countOfUsers / (decimal)request.Take);

            return (users, TotalPage);
        }

        public (bool,string) UpdateUser(UserEditRequest request)
        {
            var user = _context.Users.Where(u => u.Id == request.UserId).FirstOrDefault();
            
            if (user is null) return (false,"Belə bir istifadəçi yoxdur.");

            user.Name = request.UserName;
           
            user.Surname = request.UserSurname;
            
            user.Email = request.UserEmail;

            _context.SaveChanges();

            return (true, "Uğurlu əməliyyat");
        }
    }
}
