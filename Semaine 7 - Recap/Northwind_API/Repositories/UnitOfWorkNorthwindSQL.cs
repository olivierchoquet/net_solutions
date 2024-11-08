using Northwind_API.Entities;

namespace Northwind_API.Repositories
{
    public class UnitOfWorkNorthwindSQL : IUnitOfWorkNorthwind
    {
        private readonly NorthwindContext _context;

        private BaseRepositorySQL<Employee> _employeesRepository;

        private BaseRepositorySQL<Order> _ordersRepository;


        public UnitOfWorkNorthwindSQL(NorthwindContext context)
        {

            this._context = context;
            this._employeesRepository = new BaseRepositorySQL<Employee>(context);
            this._ordersRepository = new BaseRepositorySQL<Order>(context);

        }

        public IRepository<Employee> EmployeesRepository
        {
            get { return this._employeesRepository; }
        }

        public IRepository<Order> OrdersRepository
        {
            get { return this._ordersRepository; }
        }
    }
}
