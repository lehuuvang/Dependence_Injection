using Domain.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;
using static System.Reflection.Metadata.BlobBuilder;

namespace Reponsitory.Student
{
    public class StudentReponsitory : IStudentReponsitory
    {
        private readonly MvcContext mvcContext;
        public StudentReponsitory(MvcContext mvcContext)
        {
            this.mvcContext = mvcContext;
        }
        public Domain.Enities.Student get(int id)
        {
            try
            {              
                return mvcContext.Students.Where(x => x.Id == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception("not existed with : " + id);
            }
        }
        //search student
        public List<Domain.Enities.Student> search(string keyword)
        {
            try
            {
                List<Domain.Enities.Student> listStudentBySearch = (from s in mvcContext.Students
                                                                    orderby s.Id
                                                                    select s).ToList();

                if (!string.IsNullOrEmpty(keyword))
                {
                    listStudentBySearch = listStudentBySearch.Where(x => x.FirstName.ToLower().Contains(keyword.ToLower().Trim()) || x.Name.ToLower().Contains(keyword.ToLower().Trim()))
                                                             .ToList();                    
                }
                return listStudentBySearch;
            }
            catch(Exception ex)
            {
                throw new Exception("Not find student!");
            }
        }
        //Autocomplete
        public List<string> FillDataInSearch(string keyword)
        {
                List<string> students = mvcContext.Students.Where(x => x.Name.ToLower().Contains(keyword.ToLower().Trim())).Select(x => x.Name).ToList();
                return students; 
        }
        //getListStudent
        public List<Domain.Enities.Student> getAllStudent()
        {
            try
            {
                List<Domain.Enities.Student> listStudent = (from s in mvcContext.Students
                                                            orderby s.Id
                                                            select s).ToList();
                return listStudent;
            }catch(Exception ex)
            {
                throw new Exception("Add list not successfully!");
            }
        }
        //pageigation
        public Domain.Enities.Student Insert(Domain.Enities.Student students)
        {
            mvcContext.Students.Add(students);
            mvcContext.SaveChanges();
            return students;
        }
        public Domain.Enities.Student Update(Domain.Enities.Student students)
        {
            mvcContext.Students.Update(students);
            mvcContext.SaveChanges();
            return students;
        }
        public Domain.Enities.Student Delete(Domain.Enities.Student students)
        {
            mvcContext.Students.Remove(students);
            mvcContext.SaveChanges();
            return students;
        }
    }
}
