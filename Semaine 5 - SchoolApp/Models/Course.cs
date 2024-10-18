using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Semaine_4___SchoolApp.Models
{
    [Index("ProfessorId", Name = "IX_FK_ProfessorCourse")]
    public partial class Course
    {
        [Key]
        [Column("Course_Id")]
        public int CourseId { get; set; }
        public string Name { get; set; } = null!;
        [Column("Professor_Id")]
        public int ProfessorId { get; set; }

        [ForeignKey("ProfessorId")]
        [InverseProperty("Courses")]
        public virtual Professor Professor { get; set; } = null!;
    }
}
