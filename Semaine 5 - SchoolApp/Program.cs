// See https://aka.ms/new-console-template for more information


using School.Repository;
using School.UnitOfWork;
using Semaine_4___SchoolApp.Models;

SchoolContext context = new SchoolContext();

// création repositories

// version avec uniquement Repository
//BaseRepository<Section> repoSect = new BaseRepositorySQL<Section>(context);
//StudentRepositorySQLServer repoStud = new StudentRepositorySQLServer(context);

// AVEC DB SQL Server 
IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolSQLServer(context);
// AVEC DB MEMORY IDEAL POUR TESTER DANS UN PIPELINE 
//IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolMemory();
IRepository<Section> repoSect = unitOfWorkSchool.SectionsRepository;
IStudentRepository repoStud = unitOfWorkSchool.StudentsRepository;


// ajout de 2 sections
Section sectInfo = new Section { Name = "Info" };
repoSect.Save(sectInfo, s => s.Name.Equals(sectInfo.Name));
Section sectDiet = new Section { Name = "Diet" };
repoSect.Save(sectDiet, s => s.Name.Equals(sectDiet.Name));

// renvoyer toutes les sections

IList<Section> sections = repoSect.GetAll().ToList();

Console.WriteLine("----------- SECTIONS --------------------");
foreach (Section s in sections)
{
    Console.WriteLine(s.Name);
}
Console.WriteLine("-----------------------------------------");


// ajout de 3 étudiants
Student studinfo = new Student
{
    Firstname = "studinfo",
    Name = "studinfo",
    Section = sectInfo,
    YearResult = 100
};

Student studdiet = new Student
{
    Firstname = "studdiet",
    Name = "studdiet",
    Section = sectDiet,
    YearResult = 120
};


Student studinfo2 = new Student
{
    Firstname = "studinfo2",
    Name = "studinfo2",
    Section = sectInfo,
    YearResult = 110
};

repoStud.Save(studinfo, s => s.Name.Equals(studinfo.Name) && s.Firstname.Equals(studinfo.Firstname));
repoStud.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
repoStud.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));

IList<Student> studs = repoStud.GetStudentBySectionOrderByYearResult();

foreach (Student s in studs)
{
    Console.WriteLine("SECTION : " + s.Section.Name + " STUD : " + s.Name + " YEAR_RESULT : " + s.YearResult);
}


Console.ReadLine();