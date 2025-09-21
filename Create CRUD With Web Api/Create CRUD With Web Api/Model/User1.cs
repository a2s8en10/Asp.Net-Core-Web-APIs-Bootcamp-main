using System.ComponentModel.DataAnnotations;
namespace Create_CRUD_With_Web_Api.Model
{
    public class User1
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
