using Domain.Enities;

namespace Demo_DI.Models
{
    public class StudentsViewModel
    {
        public IEnumerable<Student> students { get; set; }
        public string Keyword { get; set; }
        //public List<Student> students { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
