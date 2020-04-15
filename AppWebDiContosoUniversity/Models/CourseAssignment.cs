using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebDiContosoUniversity.Models
{
    public class CourseAssignment
    {
        //L'unico modo per identificare le chiavi primarie composte in Entity Framework è l'uso di API Fluent 
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
