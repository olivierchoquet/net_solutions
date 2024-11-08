
using Northwind_API.Entities;

namespace Northwind_API.Repositories
{
    interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }

        IRepository<Order> OrdersRepository { get; }
    }
}
