using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Model
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Add the Title Property")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
