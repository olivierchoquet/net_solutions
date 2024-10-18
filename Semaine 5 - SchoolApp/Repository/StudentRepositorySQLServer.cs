using Semaine_4___SchoolApp.Models;
using System.Linq.Expressions;

namespace School.Repository
{
    public class StudentRepositorySQLServer : BaseRepositorySQL<Student>, IStudentRepository
    {

        public StudentRepositorySQLServer(SchoolContext dbcontext) : base(dbcontext) { }

        public IList<Student> GetStudentBySectionOrderByYearResult()
        {
            IList<Student> students = (from Student s in _dbContext.Set<Student>()
                                       orderby s.Section.Name, s.YearResult descending
                                       select s).ToList();

            return students;
        }

    }
}
