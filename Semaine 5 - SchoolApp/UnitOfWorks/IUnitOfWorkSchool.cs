using School.Repository;
using Semaine_4___SchoolApp.Models;

namespace School.UnitOfWork
{
    interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepository { get; }

        IStudentRepository StudentsRepository { get; }
    }
}
