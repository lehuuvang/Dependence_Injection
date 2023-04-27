using Domain.Enities;

namespace Demo_DI.Models
{
    public class SearchViewModel
    {
        public string Keyword { get; set; }
        public IEnumerable<Student> Results { get; set; }
    }
}
