using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Semaine_4___SchoolApp.Models
{
    [Index("SectionId", Name = "IX_FK_SectionProfessor")]
    public partial class Professor
    {
        public Professor()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        [Column("Professor_Id")]
        public int ProfessorId { get; set; }
        public string Name { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        [Column("Section_Id")]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        [InverseProperty("Professors")]
        public virtual Section Section { get; set; } = null!;
        [InverseProperty("Professor")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
