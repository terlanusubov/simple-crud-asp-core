using Microsoft.AspNetCore.Mvc;
using UsersCrud.Data;
using UsersCrud.DTOs;
using UsersCrud.Interfaces;
using UsersCrud.Models;
using UsersCrud.ServiceModels.UserAdd;
using UsersCrud.ServiceModels.UserEdit;
using UsersCrud.ServiceModels.UserList;
namespace UsersCrud.Controllers
{
    public class UserController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(
                             IConfiguration configuration,
                             IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public IActionResult List([FromQuery] UserListRequest request)
        {
            request.Take ??= Convert.ToInt32(_configuration["Lists:Users"]);

            request.Take = (int)request.Take == 0 ? 1 : request.Take;

            (List<UserListDto>, int) result = _userService.GetUsers(request);

            UserListResponse response = new UserListResponse();

            response.Users = result.Item1;

            response.TotalPage = result.Item2;

            response.CurrentPage = request.Page;

            response.CurrentTake = (int)request.Take;

            response.Request = request;

            return View(response);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAddRequest request)
        {

            if (!ModelState.IsValid)
                return View(request);

            User user = new User();

            user.Name = request.UserName;

            user.Surname = request.UserSurname;

            user.Email = request.UserEmail;

            _userService.AddUser(user);

            TempData["success"] = "true";

            return RedirectToAction("List", "User");
        }


        [HttpGet]
        public IActionResult Edit(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user is null)
            {
                TempData["notfound"] = "true";
                return RedirectToAction("List", "User");
            }

            UserEditRequest editRequest = new UserEditRequest();

            editRequest.UserName = user.Name;
           
            editRequest.UserSurname = user.Surname;
            
            editRequest.UserEmail = user.Email;
            
            editRequest.UserId = userId;

            return View(editRequest);
        }

        [HttpPost]
        public IActionResult Edit(UserEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = _userService.UpdateUser(request);

            if (!result.Item1)
            {
                TempData["editerror"] = result.Item2;
               
                return View(request);
            }

            TempData["success"] = "true";

            return RedirectToAction("List","User");
        }

        [HttpGet]
        public IActionResult Delete(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user is null)
            {
                TempData["notfound"] = "true";
                return RedirectToAction("List", "User");
            }

             _userService.DeleteUser(user);

            TempData["success"] = "true";

            return RedirectToAction("List", "User");
        }
    }
}
