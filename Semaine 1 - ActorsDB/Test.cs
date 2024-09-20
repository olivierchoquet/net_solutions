using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using be.ipl.domaine;

namespace be.ipl.client;

internal class Test
{
    public static void Main(String[] args)
    {

        Actor[] myActors =  {
                new Actor( "Assange", "Julian", new DateTime(1961, 7, 3), 187),
        // Pay attention that Calendar type in Java have month start with zero -> 0 == january
                new Actor( "Paul", "Newmann", new DateTime(1925, 1, 26), 187),
                new Actor( "Becker", "Norma Jean", new DateTime(1926, 6, 1), 187)
        };

        Director[] myDirectors = {
                new Director("Spielberg", "Steven", new DateTime(1946, 12, 18)),
                new Director("Coen", "Ettan", new DateTime(1957, 9, 21)),
                new Director("Coppolla", "Francis Ford", new DateTime(1939, 4, 7))
        };


        Movie bigLebow = new Movie("The Big Lebowski", 1996);
        Movie eT = new Movie("E.T.", 1982);

        eT.AddActor(myActors[0]);
        eT.AddActor(myActors[2]);
        eT.Director = myDirectors[0];

        bigLebow.AddActor(myActors[1]);
        bigLebow.AddActor(myActors[2]);
        bigLebow.Director = myDirectors[1];

        PersonList myPersons = PersonList.getInstance();

        // for -> foreach (... in ...)
        foreach (Actor act in myActors)
        {
            myPersons.AddPerson(act);
        }

        foreach (Director director in myDirectors)
        {
            myPersons.AddPerson(director);
        }

        // Iterator -> IEnumerator
        IEnumerator<Person> ActorIt = myPersons.personList();
        // hasNext() -> MoveNext()
        while (ActorIt.MoveNext())
        {
            // next() -> Current properties
            Person person = ActorIt.Current;
            // Sysout -> Console.WriteLine
            Console.WriteLine(person);

            IEnumerator<Movie> MoviesIt;
            if (person is Actor) {
                Console.WriteLine("a joué dans les films suivants ");
                MoviesIt = ((Actor)person).Movies();
            }
            else
            {
                if (person is Director) {
                   Console.WriteLine("a dirigé les films suivants :");
                    MoviesIt = ((Director)person).Movies();
                }
                else
                {
                    Console.WriteLine("est inconnu et n'a rien à faire ici !!! ");
                    continue;
                }
            }
            while (MoviesIt.MoveNext())
            {
                Movie Movie = MoviesIt.Current;
                Console.WriteLine(Movie);
            }

        }
    }
}
