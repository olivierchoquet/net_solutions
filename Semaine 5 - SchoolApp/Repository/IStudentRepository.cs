using Semaine_4___SchoolApp.Models;

namespace School.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
       
        IList<Student> GetStudentBySectionOrderByYearResult();
    }
}
