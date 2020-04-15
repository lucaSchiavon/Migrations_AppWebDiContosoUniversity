using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebDiContosoUniversity.Models
{
    public class OfficeAssignment
    {
        //Tuttavia Entity Framework non riconosce automaticamente InstructorID come chiave primaria di questa entità, 
        //perché il nome non rispetta la convenzione di denominazione ID o classnameID
        //quindi è necessario l'attributo key
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
