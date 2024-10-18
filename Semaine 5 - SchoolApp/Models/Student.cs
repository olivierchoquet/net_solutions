using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Semaine_4___SchoolApp.Models
{
    [Index("SectionId", Name = "IX_FK_StudentSection")]
    public partial class Student
    {
        [Key]
        [Column("Student_Id")]
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public long YearResult { get; set; }
        [Column("Section_Id")]
        public int? SectionId { get; set; }

        [ForeignKey("SectionId")]
        [InverseProperty("Students")]
        public virtual Section? Section { get; set; }
    }
}
