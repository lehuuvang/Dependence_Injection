using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Domain.Enities
{
    public class Student
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Student id is required")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(30, ErrorMessage = ("StudentName must be less than 30 characters"))]
        [Required(ErrorMessage = "Student Name is required")]
        public string Name { get; set; }
        [Column("FirstName")]
        [Display(Name = "FirstName")]
        [StringLength(30, ErrorMessage = ("FirstName must be less than 30 characters"))]
        [Required(ErrorMessage = "Student FirstName is required")]
        public string FirstName { get; set; }
        [Column("BirthDate")]
        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "Student Birthday is required")]
        public DateTime BirthDate { get; set; }
        [Column("MatchScore")]
        [Display(Name = "MatchScore")]
        [Required(ErrorMessage = "Student MatchScore is required")]
        [Range(0, 10)]
        public int MatchScore { get; set; }
        [Column("PhysicScore")]
        [Display(Name = "PhysicScore")]
        [Required(ErrorMessage = "Student physicScore is required")]
        [Range(0, 10)]
        public int PhysicScore { get; set; }
        [Column("Notes")]
        [Display(Name = "Notes")]
        [StringLength(200, ErrorMessage = ("Notes must be less than 200 characters"))]
        [Required(ErrorMessage = "Student Notes is required")]
        public string Notes { get; set; }
        public Student() { }
        public Student(int id, string name, string firstName, DateTime birthDate, int matchScore, int physicScore, string notes)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            BirthDate = birthDate;
            MatchScore = matchScore;
            PhysicScore = physicScore;
            Notes = notes;
        }
    }
}
