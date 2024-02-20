namespace UsersCrud.ServiceModels.UserList
{
    public class UserListResponse
    {
        public List<UserListDto> Users { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }

        public int CurrentTake { get; set; }

        public UserListRequest Request { get; set; }

    }
}
