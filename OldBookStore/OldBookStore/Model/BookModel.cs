using System.ComponentModel.DataAnnotations;

namespace OldBookStore.Model
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the title")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
