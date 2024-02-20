namespace UsersCrud.ServiceModels.UserList
{
    public class UserListRequest
    {

        public int? Take { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public int Page { get; set; } = 1;
    }
}
