using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace CoursesAPI.Model
{
    public class UserModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
