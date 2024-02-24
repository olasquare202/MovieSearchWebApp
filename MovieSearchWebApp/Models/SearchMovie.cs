using System.ComponentModel.DataAnnotations;

namespace MovieSearchWebApp.Models
{
    public class SearchMovie
    {
        [Required(ErrorMessage = "Enter Movie Title")]
        public string Title { get; set; }
    }
}
