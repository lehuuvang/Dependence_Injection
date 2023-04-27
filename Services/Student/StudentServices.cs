using Reponsitory.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Student
{
    public class StudentServices : IStudentServices
    {
        public readonly IStudentReponsitory studentReponsitory;
        public StudentServices(IStudentReponsitory studentReponsitory)
        {
            this.studentReponsitory = studentReponsitory;
        }
        public Domain.Enities.Student get(int id)
        {
            //Domain.Enities.Student std = new Domain.Enities.Student(1, "1", "1");
            //return std;
            return studentReponsitory.get(id);
        }
        public List<Domain.Enities.Student> getAllStudent()
        {
            return studentReponsitory.getAllStudent();
        }
        public Domain.Enities.Student Insert(Domain.Enities.Student students) 
        {
            return studentReponsitory.Insert(students);
        }
        public Domain.Enities.Student Update(Domain.Enities.Student students)
        {
            return studentReponsitory.Update(students);
        }
        public Domain.Enities.Student Delete(Domain.Enities.Student students)
        {
            return studentReponsitory.Delete(students);
        }
        public List<Domain.Enities.Student> Search(string keyword)
        {
            return studentReponsitory.search(keyword);
        }
        public List<string> FillDataInSearch(string keyword)
        {
            return studentReponsitory.FillDataInSearch(keyword);
        }
    }
}
