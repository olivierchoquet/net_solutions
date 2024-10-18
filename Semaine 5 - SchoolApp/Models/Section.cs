using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Semaine_4___SchoolApp.Models
{
    public partial class Section
    {
        public Section()
        {
            Professors = new HashSet<Professor>();
            Students = new HashSet<Student>();
        }

        [Key]
        [Column("Section_Id")]
        public int SectionId { get; set; }
        public string Name { get; set; } = null!;

        [InverseProperty("Section")]
        public virtual ICollection<Professor> Professors { get; set; }
        [InverseProperty("Section")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
