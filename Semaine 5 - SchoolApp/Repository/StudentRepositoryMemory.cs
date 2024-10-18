using School.Repository;
using Semaine_4___SchoolApp.Models;
using System.Linq.Expressions;

namespace SchoolProject.Repository
{
    class StudentRepositoryMemory : IStudentRepository
    {
        private List<Student> _students;

        public StudentRepositoryMemory()
        {
            this._students = new List<Student>();
        }

        public void Delete(Student entity)
        {
            this._students.Remove(entity);
        }

        public IList<Student> GetAll()
        {
            return this._students;
        }

        public Student GetById(int id)
        {
            return this._students.Where(s => s.StudentId == id).SingleOrDefault();
        }

        public void Insert(Student entity)
        {
            this._students.Add(entity);
        }

        public bool Save(Student entity, Expression<Func<Student, bool>> predicate)
        {
            Student s = (SearchFor(predicate)).FirstOrDefault();

            if (s == null)
            {
                Insert(entity);
                return true;
            }
            //SaveChanges();

            return false;
        }

        public IList<Student> SearchFor(Expression<Func<Student, bool>> predicate)
        {
            return this._students.AsQueryable().Where(predicate).ToList();
        }

        public IList<Student> GetStudentBySectionOrderByYearResult()
        {
            IList<Student> students = (from Student s in this._students
                                       orderby s.Section.Name, s.YearResult descending
                                       select s).ToList();

            return students;
        }

    }
}
