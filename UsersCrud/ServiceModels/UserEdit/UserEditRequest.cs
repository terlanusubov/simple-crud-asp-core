using System.ComponentModel.DataAnnotations;

namespace UsersCrud.ServiceModels.UserEdit
{
    public class UserEditRequest
    {
        [Required(ErrorMessage = "Boş qala bilməz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş qala bilməz.")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Boş qala bilməz.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Boş qala bilməz.")]
        public int UserId { get; set; }
    }
}
