using System.ComponentModel.DataAnnotations;

namespace UsersCrud.ServiceModels.UserAdd
{
    public class UserAddRequest
    {
        [Required(ErrorMessage = "Ad boş qala bilməz.")]
        [MaxLength(100, ErrorMessage = "Ad maksimum 100 uzunluğunda ola bilər.")]
        [MinLength(3,ErrorMessage = "Ad minimum 3 uzunluğunda ola bilər.")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Soyad boş qala bilməz.")]
        [MaxLength(100, ErrorMessage = "Soyad maksimum 100 uzunluğunda ola bilər.")]
        [MinLength(3, ErrorMessage = "Soyad minimum 3 uzunluğunda ola bilər.")]
        [DataType(DataType.Text)]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "E-poçt boş qala bilməz.")]
        [MaxLength(100, ErrorMessage = "E-poçt maksimum 100 uzunluğunda ola bilər.")]
        [MinLength(10, ErrorMessage = "E-poçt minimum 10 uzunluğunda ola bilər.")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

    }
}
