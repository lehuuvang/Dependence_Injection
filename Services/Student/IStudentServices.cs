using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Student
{
    public interface IStudentServices
    {
        public Domain.Enities.Student get(int id);
        public List<Domain.Enities.Student> getAllStudent();
        public Domain.Enities.Student Insert(Domain.Enities.Student students);
        public Domain.Enities.Student Update(Domain.Enities.Student students);
        public Domain.Enities.Student Delete(Domain.Enities.Student students);
        public List<Domain.Enities.Student> Search(string keyword);
        public List<string> FillDataInSearch(string keyword);
    }
}
