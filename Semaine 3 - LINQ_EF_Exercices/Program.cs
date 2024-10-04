// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Semaine_3___LINQ_EF_Exercices.Models;
// ne pas écrire Console.WriteLine() mais directement WriteLine()
using static System.Console;

WriteLine("Numéro d'exercice à exécuter (Exemple : B1)");
string? exerciceNumber = ReadLine();

if (exerciceNumber is not null)
{
    switch (exerciceNumber)
    {
        case "B1":
            ExB1();
            break;
        case "B2":
            ExB2();
            break;
        case "B3":
            ExB3();
            break;
        case "B4":
            ExB4();
            break;
        case "B5":
            ExB5();
            break;
        case "B6":
            ExB6();
            break;
        case "B7":
            ExB7();
            break;
        case "C1":
            ExC1();
            break;
        case "C2":
            ExC2();
            break;
        case "D1":
            ExD1();
            break;
        case "D2":
            WriteLine("A vérifier en DB -> Affichage -> Explorateur d'objets SQL Server ...");
            break;
        case "E1":
            ExE1();
            break;
        case "E2":
            WriteLine("A vérifier en DB -> Affichage -> Explorateur d'objets SQL Server ...");
            break;
        case "E3":
            ExE3();
            break;
        default:
            WriteLine("numéro d'exerice inconnu");
            break;

    }
}



static void ExB1()
{
    // Question B1
    WriteLine("B1 - Recherche clients par ville");
    WriteLine("Entrez le nom d'une ville :"); // Paris par ex
    string? city = ReadLine();

    if (city != null)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var customers = from Customer c in context.Customers
                            where (c.City == city)
                            select new { c.CustomerId, c.ContactName };

            foreach (var custo in customers)
            {
                Console.WriteLine("{0} : {1}", custo.CustomerId, custo.ContactName);
            }
        }
    }

}

static void ExB2()
{

    // Question B2 LAZY LOADING - EF var chargé automatiquement les données quand nécessaire
    // Il faut installer le package EntityFrameworkCore.Proxies et configurer le context Northwind
    // https://docs.microsoft.com/en-us/ef/core/querying/related-data/lazy
    WriteLine("B2 LAZY LOADING - Produits par categories");

    using (NorthwindContext context = new NorthwindContext())
    {

        IQueryable<Category> categories = from Category c in context.Categories
                                          where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                          select c;

        foreach (Category c in categories)
        {
            WriteLine("Catégorie :  " + c.CategoryName);
            foreach (Product p in c.Products)
            {
                WriteLine(p.ProductName);
            }
        }
    }
}


static void ExB3()
{

    // Question B3 EAGER LOADING - on sélectionne les tables voulues
    WriteLine("B3 EAGER LOADING - Produits par categories");

    using (NorthwindContext context = new NorthwindContext())
    {

        IQueryable<Category> categories = from Category c in context.Categories.Include("Products")
                                          where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                          select c;

        foreach (Category c in categories)
        {
            WriteLine("Catégorie :  " + c.CategoryName);
            foreach (Product p in c.Products)
            {
                WriteLine(p.ProductName);
            }
        }
    }


}


static void ExB4()
{
    // Question B4
    WriteLine("Entrez l'ID d'un client");
    string? _customerID = ReadLine(); // LILAS par ex.

    using (NorthwindContext context = new NorthwindContext())
    {

        var queryOrders = from Order o in context.Orders
                          where (o.CustomerId == _customerID && o.ShippedDate != null)
                          orderby o.OrderDate descending
                          select new { CustomerID = o.CustomerId, OrderDate = o.OrderDate, ShippedDate = o.ShippedDate };


        foreach (var od in queryOrders)
        {
            Console.WriteLine("CustomerID : " + od.CustomerID + " OrderDate : " + od.OrderDate + " ShippedDate :" + od.ShippedDate);
        }
    }
}

static void ExB5()
{

    // QUESTION B5

    using (NorthwindContext context = new NorthwindContext())
    {
        // AsEnumerable nécessaire depuis EF Core 3.0 car EF Core ne supporte pas d'évaluer le groupby côté serveur ce qu'il essaie par défaut
        // AsEnumerable permet de dire à EF Core d'évaluer le groupby côté client
        var query = from OrderDetail o in context.OrderDetails.AsEnumerable()
                    orderby o.ProductId
                    group o by o.ProductId;




        foreach (IGrouping<int, OrderDetail> orderDetails in query)
        {
            WriteLine(orderDetails.Key + " ----> " + orderDetails.Sum(o => o.UnitPrice * o.Quantity));
        }
    }
}


static void ExB6()
{
    WriteLine("Liste des employés de la région Western");
    // Un employé a plusieurs territoires sous sa responsabilité qui appartienne à une région
    // Any -> Determines whether any element of a sequence exists or satisfies a condition.

    using (NorthwindContext context = new NorthwindContext())
    {

        IQueryable<Employee> employees = from Employee e in context.Employees
                                         where e.Territories.Any(t => t.Region.RegionDescription.Equals("Western"))
                                         select e;

        foreach (Employee e in employees)
        {
            WriteLine(e.LastName + " " + e.FirstName);
        }
    }


}


static void ExB7()
{

    WriteLine("Les territoires gérés par le supérieur de Suyama");

    using (NorthwindContext context = new NorthwindContext())
    {
        var territories = (from Employee e in context.Employees
                           where e.LastName.Equals("Suyama")
                           select e.ReportsToNavigation.Territories).SingleOrDefault();


        foreach (Territory t in territories)
        {
            WriteLine(t.TerritoryDescription);
        }
    }

}

static void ExC1()
{
    WriteLine("Tous les clients en majuscule");


    using (NorthwindContext context = new NorthwindContext())
    {
        IQueryable<Customer> custom = (from c in context.Customers
                                       select c);


        foreach (Customer cust in custom)
        {
            cust.ContactName = cust.ContactName.ToUpper();
            //cust.ContactName = cust.ContactName.ToLower();
        }

        try
        {
            context.SaveChanges();
        }
        catch (Exception e)
        {
            WriteLine("Erreur {0}", e.Message);
        }
    }

    WriteLine("Done");
}

static void ExC2()
{
    using (NorthwindContext context = new NorthwindContext())
    {
        WriteLine("Vérifier que tous les noms des clients sont en majuscule");


        IQueryable<Customer> custom = (from c in context.Customers
                                       select c);


        foreach (Customer cust in custom)
        {
            WriteLine(cust.ContactName);
        }
    }


}

static void ExD1()
{
    // Question D1 
    // ajout d'une catégorie
    WriteLine("Entrez une catégorie à ajouter");
    string? categorieLuClavier = ReadLine();

    try
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            Category? cat = (from c in context.Categories
                             where c.CategoryName == categorieLuClavier
                             select c).SingleOrDefault<Category>();
            if (cat == null && categorieLuClavier is not null)
            {
                cat = new Category { CategoryName = categorieLuClavier };
                context.Categories.Add(cat);
                context.SaveChanges();
            }
            else
            {
                WriteLine("Une catégorie existe déjà avec ce nom");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}


static void ExE1()
{
    // Question D1 
    // suppression d'une catégorie
    WriteLine("Entrez une catégorie à effacer");
    string? categorieLuClavier = ReadLine();

    try
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            Category catSupp = (from c in context.Categories
                                where c.CategoryName == categorieLuClavier
                                select c).First<Category>();

            context.Categories.Remove(catSupp);
            context.SaveChanges();
        }
    }
    catch (Exception e)
    {
        WriteLine(e);
    }
}

static void ExE3()
{
    /* Question D3 */
    /* Exemple 
     * e1 == DAVOLIO 123 orders
     * e2 -> FULLER 96 orders
     * transfert DAVOLIO vers Fuller -> donc 219 orders au total
     * Attention les int.parse(...) doivent être en dehors de querys LINQ
     */
    WriteLine("Entrez l'ID de l'employé à supprimer");
    string? emp1 = ReadLine();

    WriteLine("Entrez l'ID de l'employé qui reprend les Orders de celui à supprimer");
    string? emp2 = ReadLine();

    //int e1 = int.Parse(emp1);  ou mieux TryParse
    if (!int.TryParse(emp1, out int e1))
    {
        WriteLine("Employé 1 inconnu");
    }
    if (!int.TryParse(emp2, out int e2))
    {
        WriteLine("Employé 2 inconnu");
    }

    using (NorthwindContext context = new NorthwindContext())
    {
        // include Territories and inverseReportsToNavigation to load them and delete them via clear after
        Employee employee1 = (from e in context.Employees.Include("Territories").Include("InverseReportsToNavigation")
                              where e.EmployeeId == e1
                              select e).Single<Employee>();


        Employee employee2 = (from e in context.Employees
                              where e.EmployeeId == e2
                              select e).Single<Employee>();

        IQueryable<Order> employee1Orders = (from o in context.Orders
                                             where o.EmployeeId == e1
                                             select o);

        foreach (Order o in employee1Orders)
        {
            employee2.Orders.Add(o);
            employee1.Orders.Remove(o);

        }

        employee1.Territories.Clear();
        employee1.InverseReportsToNavigation.Clear();



        context.Employees.Remove(employee1);
        int affected = context.SaveChanges();
        WriteLine("Nombre de lignes affectées " + affected);


    }



}


