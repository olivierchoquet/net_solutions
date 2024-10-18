using School.Repository;
using Semaine_4___SchoolApp.Models;

namespace School.UnitOfWork
{
    class UnitOfWorkSchoolSQLServer : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;

        private StudentRepositorySQLServer _studentRepository;

        private BaseRepositorySQL<Section> _sectionsRepository;


        public UnitOfWorkSchoolSQLServer(SchoolContext context)
        {
            this._context = context;
            this._studentRepository = new StudentRepositorySQLServer(context);
            this._sectionsRepository = new BaseRepositorySQL<Section>(context);

        }

        public IStudentRepository StudentsRepository
        {
            get { return this._studentRepository; }
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }
    }
}
